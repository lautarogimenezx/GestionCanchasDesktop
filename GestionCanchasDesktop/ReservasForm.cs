using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    public partial class ReservasForm : Form
    {
        private readonly int _cancheroId;
        private bool _gridCfg = false;

        // horario de atención
        private readonly TimeSpan _apertura = new TimeSpan(8, 0, 0);
        private readonly TimeSpan _cierre = new TimeSpan(23, 0, 0);

        // reservas del día (para grisado/chequeo)
        private List<(DateTime inicio, int durMin)> _reservasDelDia =
            new List<(DateTime, int)>();

        // para evitar pop-ups al bindear horarios
        private bool _silenciarHorarioChange = false;

        public ReservasForm(int cancheroId)
        {
            InitializeComponent();
            _cancheroId = cancheroId;

            this.Load += ReservasForm_Load;

            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += (_, __) => LimpiarForm();
            btnCancelar.Click += (_, __) => this.Close();

            dgvReservas.CellClick += dgvReservas_CellClick;
            dgvReservas.DataBindingComplete += (_, __) => DecorarBotones();

            // recalcular horarios al cambiar selección
            cmbCancha.SelectedIndexChanged += (_, __) => RefrescarHorarios();
            dtpFecha.ValueChanged += (_, __) => RefrescarHorarios();
            numDuracion.ValueChanged += (_, __) => RefrescarHorarios();
            cmbEstado.SelectedIndexChanged += (_, __) => ToggleMetodoPago();

            // importante para que no se pueda tipear un horario arbitrario
            cmbHorario.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // ========= helpers de solape =========
        private static bool SeSolapa(DateTime slotInicio, int durSlot, DateTime resInicio, int durRes)
        {
            var slotFin = slotInicio.AddMinutes(durSlot);
            var resFin = resInicio.AddMinutes(durRes);
            return slotInicio < resFin && slotFin > resInicio;
        }
        // =====================================

        private void ReservasForm_Load(object? sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarCombos();
            LimpiarForm();
            RefrescarHorarios();
            CargarGrilla();
        }

        private void CargarCombos()
        {
            // Jugadores
            var jug = ReservasService.GetJugadoresActivos();
            cmbJugador.DataSource = jug;
            cmbJugador.DisplayMember = "Nombre";
            cmbJugador.ValueMember = "Id";

            // Canchas
            var can = ReservasService.GetCanchasActivas();
            cmbCancha.DataSource = can;
            cmbCancha.DisplayMember = "Nombre";
            cmbCancha.ValueMember = "Id";

            // Estados (desde DB)
            var est = ReservasService.GetEstados();
            cmbEstado.DataSource = est;
            cmbEstado.DisplayMember = "Nombre";
            cmbEstado.ValueMember = "Id";

            // Métodos de pago
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.AddRange(new[] { "Efectivo", "Tarjeta", "Transferencia", "QR" });
            cmbMetodoPago.SelectedIndex = -1;
            cmbMetodoPago.Enabled = false;
        }

        private void ToggleMetodoPago()
        {
            if (cmbEstado.SelectedItem is DataRowView drv)
            {
                var nombre = (string)drv.Row["Nombre"];
                bool pagado = string.Equals(nombre, "Pagado", StringComparison.OrdinalIgnoreCase);
                cmbMetodoPago.Enabled = pagado;
                if (!pagado) cmbMetodoPago.SelectedIndex = -1;
            }
        }

        private void ConfigurarGrilla()
        {
            if (_gridCfg) return;
            var g = dgvReservas;
            g.AutoGenerateColumns = false;
            g.AllowUserToAddRows = false;
            g.ReadOnly = true;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.Columns.Clear();

            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Jugador", DataPropertyName = "Jugador", Width = 180 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cancha", DataPropertyName = "Cancha", Width = 140 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Inicio", DataPropertyName = "Inicio", Width = 140, DefaultCellStyle = { Format = "g" } });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fin", DataPropertyName = "Fin", Width = 140, DefaultCellStyle = { Format = "g" } });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Duracion", DataPropertyName = "DuracionMin", HeaderText = "Dur (min)", Width = 80 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", DataPropertyName = "Estado", Width = 90 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "MetodoPago", DataPropertyName = "MetodoPago", HeaderText = "Método", Width = 90 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Canchero", DataPropertyName = "Canchero", Width = 140 });
            g.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Activa", DataPropertyName = "Activo", HeaderText = "Activa", Width = 60 });

            g.Columns.Add(new DataGridViewButtonColumn { Name = "MarcarPagado", Text = "Marcar pagado", UseColumnTextForButtonValue = true, Width = 120 });
            g.Columns.Add(new DataGridViewButtonColumn { Name = "Cancelar", Text = "Cancelar", UseColumnTextForButtonValue = true, Width = 90 });

            _gridCfg = true;
        }

        private void CargarGrilla()
        {
            var desde = DateTime.Today.AddDays(-7);
            var hasta = DateTime.Today.AddMonths(1);
            dgvReservas.DataSource = ReservasService.Listar(desde, hasta, incluirCanceladas: true);

            DecorarBotones(); // aplicar estilo/estado a botones
        }

        private void LimpiarForm()
        {
            if (cmbJugador.Items.Count > 0) cmbJugador.SelectedIndex = 0;
            if (cmbCancha.Items.Count > 0) cmbCancha.SelectedIndex = 0;

            dtpFecha.Value = DateTime.Today;
            numDuracion.Value = 60;

            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedIndex = 0;
            cmbMetodoPago.SelectedIndex = -1;
            ToggleMetodoPago();
        }

        // ==== Horarios: grisado y bloqueo por solape ====
        private void RefrescarHorarios()
        {
            _silenciarHorarioChange = true; // evitar pop-ups al bindear

            cmbHorario.DrawMode = DrawMode.OwnerDrawFixed;

            // reset completo
            cmbHorario.DataSource = null;
            cmbHorario.Items.Clear();
            cmbHorario.SelectedIndex = -1;
            cmbHorario.Text = "";

            if (cmbCancha.SelectedValue is not int canchaId)
            {
                _silenciarHorarioChange = false;
                return;
            }

            int dur = (int)numDuracion.Value;
            var fecha = dtpFecha.Value.Date;

            // reservas del día para chequeo
            _reservasDelDia = ReservasService.GetReservasDeCanchaPorDia(canchaId, fecha);

            // todos los slots candidatos (cada 30 min dentro de [apertura, cierre - dur])
            var todos = new List<DateTime>();
            DateTime inicioVentana = fecha + _apertura;
            DateTime finVentana = fecha + _cierre;
            DateTime ultimoInicio = finVentana.AddMinutes(-dur);

            for (var s = inicioVentana; s <= ultimoInicio; s = s.AddMinutes(30))
                todos.Add(s);

            // bind
            var items = todos.Select(dt => new { Valor = dt, Texto = dt.ToString("HH:mm") }).ToList();
            cmbHorario.DisplayMember = "Texto";
            cmbHorario.ValueMember = "Valor";
            cmbHorario.DataSource = items;

            // hooks (idempotentes)
            cmbHorario.DrawItem -= cmbHorario_DrawItem;
            cmbHorario.DrawItem += cmbHorario_DrawItem;
            cmbHorario.SelectedIndexChanged -= cmbHorario_SelectedIndexChanged;
            cmbHorario.SelectedIndexChanged += cmbHorario_SelectedIndexChanged;

            // no seleccionar nada al cargar
            cmbHorario.SelectedIndex = -1;

            if (items.Count == 0)
                cmbHorario.Text = "Sin horarios disponibles";

            _silenciarHorarioChange = false;
        }

        private void cmbHorario_DrawItem(object? sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index < 0) return;

            var combo = (ComboBox)sender!;
            var item = combo.Items[e.Index];
            var dt = (DateTime)item.GetType().GetProperty("Valor")!.GetValue(item)!;
            int dur = (int)numDuracion.Value;

            bool ocupado = _reservasDelDia.Any(r => SeSolapa((DateTime)dt, dur, r.inicio, r.durMin));

            var color = ocupado ? SystemBrushes.GrayText : SystemBrushes.ControlText;
            e.Graphics.DrawString(
                (string)item.GetType().GetProperty("Texto")!.GetValue(item)!,
                e.Font!, color, e.Bounds);

            e.DrawFocusRectangle();
        }

        private void cmbHorario_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_silenciarHorarioChange) return; // no molestar al bindear
            if (cmbHorario.SelectedIndex < 0) return;

            var item = cmbHorario.SelectedItem!;
            var dt = (DateTime)item.GetType().GetProperty("Valor")!.GetValue(item)!;
            int dur = (int)numDuracion.Value;

            bool ocupado = _reservasDelDia.Any(r => SeSolapa((DateTime)dt, dur, r.inicio, r.durMin));
            if (ocupado)
            {
                MessageBox.Show("Ese horario ya está reservado.");
                cmbHorario.SelectedIndex = -1;
            }
        }
        // ================================================

        private bool Validar()
        {
            if (cmbJugador.SelectedValue is not int) { MessageBox.Show("Seleccione un jugador."); return false; }
            if (cmbCancha.SelectedValue is not int) { MessageBox.Show("Seleccione una cancha."); return false; }
            if (cmbHorario.SelectedValue is not DateTime) { MessageBox.Show("Seleccione un horario disponible."); return false; }
            if (numDuracion.Value <= 0) { MessageBox.Show("Duración inválida."); return false; }

            if (cmbEstado.SelectedItem is DataRowView drv)
            {
                var nombre = drv.Row["Nombre"].ToString();
                bool pagado = string.Equals(nombre, "Pagado", StringComparison.OrdinalIgnoreCase);
                if (pagado && (cmbMetodoPago.SelectedItem == null || string.IsNullOrWhiteSpace(cmbMetodoPago.Text)))
                {
                    MessageBox.Show("Debe indicar Método de Pago cuando el estado es Pagado.");
                    return false;
                }
            }
            return true;
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

            int jugadorId = (int)cmbJugador.SelectedValue;
            int canchaId = (int)cmbCancha.SelectedValue;
            DateTime inicio = (DateTime)cmbHorario.SelectedValue;
            int dur = (int)numDuracion.Value;

            // doble check en UI
            if (_reservasDelDia.Any(r => SeSolapa(inicio, dur, r.inicio, r.durMin)))
            {
                MessageBox.Show("La cancha ya está reservada en ese horario.");
                RefrescarHorarios();
                return;
            }

            int estadoId = (int)cmbEstado.SelectedValue;
            string? metodoPago = (cmbMetodoPago.Enabled && cmbMetodoPago.SelectedItem != null)
                ? cmbMetodoPago.SelectedItem.ToString()
                : null;

            try
            {
                ReservasService.Crear(jugadorId, canchaId, _cancheroId, inicio, dur, estadoId, metodoPago);
                MessageBox.Show("✅ Reserva creada.");
                CargarGrilla();
                RefrescarHorarios(); // quita/grisa el horario recién utilizado
                LimpiarForm();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RefrescarHorarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvReservas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dgvReservas.Columns[e.ColumnIndex].Name;

            // Datos de la fila
            var row = dgvReservas.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            string estado = Convert.ToString(row.Cells["Estado"].Value) ?? "";
            bool activa = row.Cells["Activa"] is DataGridViewCheckBoxCell cb && cb.Value is bool b && b;

            // Guard-rails
            if (col == "MarcarPagado" && (!activa || estado.Equals("Pagado", StringComparison.OrdinalIgnoreCase)))
                return;

            if (col == "Cancelar" && !activa)
                return;

            if (col == "MarcarPagado")
            {
                string? metodo = Microsoft.VisualBasic.Interaction.InputBox(
                    "Método de pago (Efectivo/Tarjeta/Transferencia/QR):",
                    "Marcar Pagado", "Efectivo");
                if (string.IsNullOrWhiteSpace(metodo)) return;

                try
                {
                    var est = (DataTable)cmbEstado.DataSource;
                    int estadoPagadoId = est.AsEnumerable()
                        .First(r => string.Equals(r.Field<string>("Nombre"), "Pagado", StringComparison.OrdinalIgnoreCase))
                        .Field<int>("Id");

                    ReservasService.SetEstado(id, estadoPagadoId, metodo);
                    CargarGrilla();
                    DecorarBotones();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }

            if (col == "Cancelar")
            {
                if (MessageBox.Show("¿Cancelar esta reserva?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        ReservasService.Cancelar(id);
                        CargarGrilla();
                        RefrescarHorarios();
                        DecorarBotones();
                    }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
            }
        }

        private void DecorarBotones()
        {
            foreach (DataGridViewRow row in dgvReservas.Rows)
            {
                string estado = Convert.ToString(row.Cells["Estado"].Value) ?? "";
                bool activa = row.Cells["Activa"] is DataGridViewCheckBoxCell cb && cb.Value is bool b && b;

                var btnPagar = row.Cells["MarcarPagado"] as DataGridViewButtonCell;
                var btnCanc = row.Cells["Cancelar"] as DataGridViewButtonCell;

                if (btnPagar != null)
                {
                    bool deshabilitar = !activa || estado.Equals("Pagado", StringComparison.OrdinalIgnoreCase);
                    btnPagar.ReadOnly = deshabilitar;
                    btnPagar.FlatStyle = FlatStyle.Standard;
                    btnPagar.Style.ForeColor = deshabilitar ? System.Drawing.Color.Gray : System.Drawing.Color.Black;
                    btnPagar.Style.SelectionForeColor = btnPagar.Style.ForeColor;
                    btnPagar.Value = deshabilitar ? "Pagado" : "Marcar pagado";
                }

                if (btnCanc != null)
                {
                    bool deshabilitar = !activa;
                    btnCanc.ReadOnly = deshabilitar;
                    btnCanc.FlatStyle = FlatStyle.Standard;
                    btnCanc.Style.ForeColor = deshabilitar ? System.Drawing.Color.Gray : System.Drawing.Color.Black;
                    btnCanc.Style.SelectionForeColor = btnCanc.Style.ForeColor;
                    btnCanc.Value = deshabilitar ? "—" : "Cancelar";
                }
            }
        }

        // (por si el Designer dejó enganchado CellContentClick)
        private void dgvReservas_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            dgvReservas_CellClick(sender, e);
        }
    }
}
