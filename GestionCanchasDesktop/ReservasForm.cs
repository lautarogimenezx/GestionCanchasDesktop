using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    public partial class ReservasForm : Form
    {
        private readonly int _cancheroId;
        private bool _gridCfg = false;
        private readonly TimeSpan _apertura = new TimeSpan(8, 0, 0);
        private readonly TimeSpan _cierre = new TimeSpan(23, 0, 0);
        private List<(DateTime inicio, int durMin)> _reservasDelDia = new();
        private bool _silenciarHorarioChange = false;

        // CAMBIO: Variable para guardar el ID de la reserva que estamos editando
        private int _idReservaEditando = -1;

        public ReservasForm(int cancheroId)
        {
            InitializeComponent();
            _cancheroId = cancheroId;

            this.Load += ReservasForm_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += (_, __) => LimpiarForm();
           
            dgvReservas.CellClick += dgvReservas_CellClick;
            dgvReservas.DataBindingComplete += (_, __) => DecorarBotones();
            cmbCancha.SelectedIndexChanged += (_, __) => RefrescarHorarios();
            dtpFecha.ValueChanged += (_, __) => RefrescarHorarios();
            numDuracion.ValueChanged += (_, __) => RefrescarHorarios();
            cmbEstado.SelectedIndexChanged += (_, __) => ToggleMetodoPago();
            cmbHorario.DropDownStyle = ComboBoxStyle.DropDownList;

            // CAMBIO: Asignar los eventos a nuestro nuevo ComboBox "fantasma"
            ConfigurarComboBoxGrid();
        }

        // CAMBIO: Nuevo método para configurar el ComboBox que aparecerá en la grilla
        private void ConfigurarComboBoxGrid()
        {
            // Llenamos el ComboBox con las opciones de pago
            cmbMetodoPagoGrid.Items.AddRange(new[] { "Efectivo", "Tarjeta", "Transferencia", "QR" });

            // Asignamos los manejadores de eventos
            cmbMetodoPagoGrid.SelectionChangeCommitted += cmbMetodoPagoGrid_SelectionChangeCommitted;
            cmbMetodoPagoGrid.Leave += (_, __) => OcultarComboBoxGrid();
            cmbMetodoPagoGrid.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) OcultarComboBoxGrid(); };
        }

        private static bool SeSolapa(DateTime slotInicio, int durSlot, DateTime resInicio, int durRes)
        {
            var slotFin = slotInicio.AddMinutes(durSlot);
            var resFin = resInicio.AddMinutes(durRes);
            return slotInicio < resFin && slotFin > resInicio;
        }

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
            var jug = ReservasService.GetJugadoresActivos();
            cmbJugador.DataSource = jug;
            cmbJugador.DisplayMember = "Nombre";
            cmbJugador.ValueMember = "Id";

            var can = ReservasService.GetCanchasActivas();
            cmbCancha.DataSource = can;
            cmbCancha.DisplayMember = "Nombre";
            cmbCancha.ValueMember = "Id";

            var est = ReservasService.GetEstados();
            cmbEstado.DataSource = est;
            cmbEstado.DisplayMember = "Nombre";
            cmbEstado.ValueMember = "Id";

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
            dgvReservas.DataSource = ReservasService.Listar(DateTime.Today.AddDays(-7), DateTime.Today.AddMonths(1), true);
            DecorarBotones();
        }

        private void LimpiarForm()
        {
            if (cmbJugador.Items.Count > 0) cmbJugador.SelectedIndex = 0;
            if (cmbCancha.Items.Count > 0) cmbCancha.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Today;
            numDuracion.Value = 1;
            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedIndex = 0;
            cmbMetodoPago.SelectedIndex = -1;
            ToggleMetodoPago();
        }

        private void RefrescarHorarios()
        {
            _silenciarHorarioChange = true;
            cmbHorario.DrawMode = DrawMode.OwnerDrawFixed;
            cmbHorario.DataSource = null;
            cmbHorario.Items.Clear();
            cmbHorario.SelectedIndex = -1;
            cmbHorario.Text = "";

            if (cmbCancha.SelectedValue is not int canchaId)
            {
                _silenciarHorarioChange = false;
                return;
            }

            int duracionEnMinutos = (int)numDuracion.Value * 60;
            var fecha = dtpFecha.Value.Date;
            _reservasDelDia = ReservasService.GetReservasDeCanchaPorDia(canchaId, fecha);

            var todos = new List<DateTime>();
            DateTime inicioVentana = fecha + _apertura;
            DateTime finVentana = fecha + _cierre;
            DateTime ultimoInicio = finVentana.AddMinutes(-duracionEnMinutos);

            for (var s = inicioVentana; s <= ultimoInicio; s = s.AddMinutes(60))
                todos.Add(s);

            var items = todos.Select(dt => new { Valor = dt, Texto = dt.ToString("HH:mm") }).ToList();
            cmbHorario.DisplayMember = "Texto";
            cmbHorario.ValueMember = "Valor";
            cmbHorario.DataSource = items;
            cmbHorario.DrawItem -= cmbHorario_DrawItem;
            cmbHorario.DrawItem += cmbHorario_DrawItem;
            cmbHorario.SelectedIndexChanged -= cmbHorario_SelectedIndexChanged;
            cmbHorario.SelectedIndexChanged += cmbHorario_SelectedIndexChanged;
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
            int duracionEnMinutos = (int)numDuracion.Value * 60;

            bool ocupado = _reservasDelDia.Any(r => SeSolapa(dt, duracionEnMinutos, r.inicio, r.durMin));

            var color = ocupado ? SystemBrushes.GrayText : SystemBrushes.ControlText;
            e.Graphics.DrawString((string)item.GetType().GetProperty("Texto")!.GetValue(item)!, e.Font!, color, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void cmbHorario_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_silenciarHorarioChange || cmbHorario.SelectedIndex < 0) return;

            var item = cmbHorario.SelectedItem!;
            var dt = (DateTime)item.GetType().GetProperty("Valor")!.GetValue(item)!;
            int duracionEnMinutos = (int)numDuracion.Value * 60;

            bool ocupado = _reservasDelDia.Any(r => SeSolapa(dt, duracionEnMinutos, r.inicio, r.durMin));
            if (ocupado)
            {
                MessageBox.Show("Ese horario ya está reservado o se superpone con otra reserva.");
                cmbHorario.SelectedIndex = -1;
            }
        }

        private bool Validar()
        {
            if (cmbJugador.SelectedValue is not int) { MessageBox.Show("Seleccione un jugador."); return false; }
            if (cmbCancha.SelectedValue is not int) { MessageBox.Show("Seleccione una cancha."); return false; }
            if (cmbHorario.SelectedValue is not DateTime) { MessageBox.Show("Seleccione un horario disponible."); return false; }
            if (numDuracion.Value <= 0) { MessageBox.Show("La duración debe ser de al menos 1 hora."); return false; }

            if (cmbEstado.SelectedItem is DataRowView drv)
            {
                var nombre = drv.Row["Nombre"].ToString();
                bool pagado = string.Equals(nombre, "Pagado", StringComparison.OrdinalIgnoreCase);
                if (pagado && string.IsNullOrWhiteSpace(cmbMetodoPago.Text))
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
            int duracionEnMinutos = (int)numDuracion.Value * 60;

            if (_reservasDelDia.Any(r => SeSolapa(inicio, duracionEnMinutos, r.inicio, r.durMin)))
            {
                MessageBox.Show("La cancha ya está reservada en ese horario.");
                RefrescarHorarios();
                return;
            }

            int estadoId = (int)cmbEstado.SelectedValue;
            string? metodoPago = (cmbMetodoPago.Enabled && cmbMetodoPago.SelectedItem != null) ? cmbMetodoPago.SelectedItem.ToString() : null;

            try
            {
                ReservasService.Crear(jugadorId, canchaId, _cancheroId, inicio, duracionEnMinutos, estadoId, metodoPago);
                MessageBox.Show("✅ Reserva creada.");
                CargarGrilla();
                RefrescarHorarios();
                LimpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, ex is InvalidOperationException ? "Atención" : "Error", MessageBoxButtons.OK, ex is InvalidOperationException ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
                RefrescarHorarios();
            }
        }

        // CAMBIO: La lógica para marcar pagado ahora es diferente.
        private void dgvReservas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = dgvReservas.Columns[e.ColumnIndex].Name;
            var row = dgvReservas.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            string estado = Convert.ToString(row.Cells["Estado"].Value) ?? "";
            bool activa = row.Cells["Activa"].Value as bool? ?? false;

            // Lógica para el botón "MarcarPagado"
            if (colName == "MarcarPagado")
            {
                if (!activa || estado.Equals("Pagado", StringComparison.OrdinalIgnoreCase)) return;

                // Guardamos el ID de la reserva que estamos por editar
                _idReservaEditando = id;

                // Obtenemos la posición de la celda "MetodoPago" para saber dónde ubicar el ComboBox
                Rectangle cellRectangle = dgvReservas.GetCellDisplayRectangle(dgvReservas.Columns["MetodoPago"].Index, e.RowIndex, false);

                // Movemos nuestro ComboBox fantasma a esa posición
                cmbMetodoPagoGrid.Location = cellRectangle.Location;
                cmbMetodoPagoGrid.Size = cellRectangle.Size;

                // Lo hacemos visible, lo traemos al frente y lo desplegamos
                cmbMetodoPagoGrid.Visible = true;
                cmbMetodoPagoGrid.BringToFront();
                cmbMetodoPagoGrid.Focus();
                cmbMetodoPagoGrid.DroppedDown = true;
            }
            // Lógica para el botón "Cancelar" (sin cambios)
            else if (colName == "Cancelar")
            {
                if (!activa) return;

                if (MessageBox.Show("¿Cancelar esta reserva?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        ReservasService.Cancelar(id);
                        CargarGrilla();
                        RefrescarHorarios();
                    }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
            }
        }

        // CAMBIO: Nuevo método que se ejecuta cuando el usuario selecciona un item del ComboBox
        private void cmbMetodoPagoGrid_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            // Si no hay item seleccionado o no estamos editando ninguna reserva, no hacemos nada
            if (cmbMetodoPagoGrid.SelectedItem == null || _idReservaEditando == -1) return;

            string metodo = cmbMetodoPagoGrid.SelectedItem.ToString()!;

            try
            {
                // Obtenemos el ID del estado "Pagado"
                var est = (DataTable)cmbEstado.DataSource;
                int estadoPagadoId = est.AsEnumerable()
                    .First(r => string.Equals(r.Field<string>("Nombre"), "Pagado", StringComparison.OrdinalIgnoreCase))
                    .Field<int>("Id");

                // Llamamos al servicio para actualizar el estado y el método de pago
                ReservasService.SetEstado(_idReservaEditando, estadoPagadoId, metodo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la reserva: " + ex.Message);
            }
            finally
            {
                // Ocultamos el ComboBox y recargamos la grilla para ver el cambio
                OcultarComboBoxGrid();
                CargarGrilla();
            }
        }

        // CAMBIO: Nuevo método para ocultar el ComboBox y limpiar la variable de estado
        private void OcultarComboBoxGrid()
        {
            _idReservaEditando = -1;
            cmbMetodoPagoGrid.Visible = false;
        }

        private void DecorarBotones()
        {
            foreach (DataGridViewRow row in dgvReservas.Rows)
            {
                string estado = Convert.ToString(row.Cells["Estado"].Value) ?? "";
                bool activa = row.Cells["Activa"].Value as bool? ?? false;

                if (row.Cells["MarcarPagado"] is DataGridViewButtonCell btnPagar)
                {
                    bool deshabilitar = !activa || estado.Equals("Pagado", StringComparison.OrdinalIgnoreCase);
                    btnPagar.ReadOnly = deshabilitar;
                    btnPagar.FlatStyle = FlatStyle.Standard;
                    btnPagar.Style.ForeColor = deshabilitar ? Color.Gray : Color.Black;
                    btnPagar.Style.SelectionForeColor = btnPagar.Style.ForeColor;
                    btnPagar.Value = deshabilitar ? "—" : "Marcar pagado";
                }

                if (row.Cells["Cancelar"] is DataGridViewButtonCell btnCanc)
                {
                    bool deshabilitar = !activa;
                    btnCanc.ReadOnly = deshabilitar;
                    btnCanc.FlatStyle = FlatStyle.Standard;
                    btnCanc.Style.ForeColor = deshabilitar ? Color.Gray : Color.Black;
                    btnCanc.Style.SelectionForeColor = btnCanc.Style.ForeColor;
                    btnCanc.Value = deshabilitar ? "—" : "Cancelar";
                }
            }
        }

        private void dgvReservas_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            dgvReservas_CellClick(sender, e);
        }
    }
}