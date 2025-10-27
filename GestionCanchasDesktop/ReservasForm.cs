using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GestionCanchasDesktop
{
    public partial class ReservasForm : Form
    {
        // --- Campos del Formulario

        // ID del Canchero que está operando el formulario.
        private readonly int _cancheroId;
        private bool _gridCfg = false;

        //horario de incio y de fin de la jornada
        private readonly TimeSpan _apertura = new TimeSpan(8, 0, 0);
        private readonly TimeSpan _cierre = new TimeSpan(23, 0, 0);

        private List<(DateTime inicio, int durMin)> _reservasDelDia = new();
        private bool _silenciarHorarioChange = false;
        private int _idReservaEditando = -1;
        private bool _handlingGridAction = false;


        public ReservasForm(int cancheroId)
        {
            InitializeComponent();
            _cancheroId = cancheroId;

            this.Load += ReservasForm_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar2.Click += (_, __) => LimpiarForm();

            dgvReservas.CellClick -= dgvReservas_CellClick;
            dgvReservas.CellContentClick -= dgvReservas_CellClick;
            dgvReservas.CellContentClick -= dgvReservas_CellContentClick;
            dgvReservas.CellClick += dgvReservas_CellClick;
            dgvReservas.DataBindingComplete += (_, __) => DecorarBotones();
            cmbCancha.SelectedIndexChanged += (_, __) => RefrescarHorarios();
            dtpFecha.ValueChanged += (_, __) => RefrescarHorarios();
            numDuracion.ValueChanged += (_, __) => RefrescarHorarios();
            cmbEstado.SelectedIndexChanged += (_, __) => ToggleMetodoPago();
            cmbHorario.DropDownStyle = ComboBoxStyle.DropDownList; // Evita que el usuario escriba texto

            ConfigurarComboBoxGrid();
        }

        // Configura el ComboBox 'cmbMetodoPagoGrid', que aparece dinámicamente
        // sobre la grilla para seleccionar el método de pago.
        private void ConfigurarComboBoxGrid()
        {
            cmbMetodoPagoGrid.Items.AddRange(new[] { "Efectivo", "Tarjeta", "Transferencia", "QR" });
            cmbMetodoPagoGrid.SelectionChangeCommitted += cmbMetodoPagoGrid_SelectionChangeCommitted;
            cmbMetodoPagoGrid.Leave += (_, __) => OcultarComboBoxGrid(); // Se oculta si pierde el foco
            cmbMetodoPagoGrid.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) OcultarComboBoxGrid(); }; // Se oculta con ESC
        }

        // Función de utilidad para detectar si dos intervalos de tiempo se solapan.
        private static bool SeSolapa(DateTime slotInicio, int durSlot, DateTime resInicio, int durRes)
        {
            var slotFin = slotInicio.AddMinutes(durSlot);
            var resFin = resInicio.AddMinutes(durRes);
            // Lógica estándar de solapamiento: (InicioA < FinB) y (FinA > InicioB)
            return slotInicio < resFin && slotFin > resInicio;
        }

        // Manejador del evento Load del formulario. Se ejecuta al abrir el form.
        private void ReservasForm_Load(object? sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarCombos();
            LimpiarForm();
            RefrescarHorarios(); // Carga horarios disponibles
            CargarGrilla(); // Carga reservas existentes
        }

        // Carga los datos iniciales en los ComboBox del formulario (Jugadores, Canchas, Estados).
        private void CargarCombos()
        {
            // Carga Jugadores
            var jug = ReservasService.GetJugadoresActivos();
            cmbJugador.DataSource = jug;
            cmbJugador.DisplayMember = "Nombre";
            cmbJugador.ValueMember = "Id";

            // Carga Canchas
            var can = ReservasService.GetCanchasActivas();
            cmbCancha.DataSource = can;
            cmbCancha.DisplayMember = "Nombre";
            cmbCancha.ValueMember = "Id";

            // Carga Estados
            var est = ReservasService.GetEstados();
            cmbEstado.DataSource = est;
            cmbEstado.DisplayMember = "Nombre";
            cmbEstado.ValueMember = "Id";

            // Carga Métodos de Pago (estático)
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.AddRange(new[] { "Efectivo", "Tarjeta", "Transferencia", "QR" });
            cmbMetodoPago.SelectedIndex = -1;
            cmbMetodoPago.Enabled = false; // Deshabilitado por defecto
        }

        // Habilita o deshabilita el ComboBox de Método de Pago basado en si
        // el estado seleccionado es "Pagado".
        private void ToggleMetodoPago()
        {
            if (cmbEstado.SelectedItem is DataRowView drv)
            {
                var nombre = (string)drv.Row["Nombre"];
                bool pagado = string.Equals(nombre, "Pagado", StringComparison.OrdinalIgnoreCase);
                cmbMetodoPago.Enabled = pagado;
                if (!pagado) cmbMetodoPago.SelectedIndex = -1; // Limpia la selección si no está pagado
            }
        }

        // Define la estructura (columnas, estilos, comportamiento) del DataGridView 'dgvReservas'.
        private void ConfigurarGrilla()
        {
            if (_gridCfg) return;
            var g = dgvReservas;
            g.AutoGenerateColumns = false;
            g.AllowUserToAddRows = false;
            g.ReadOnly = true;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.Columns.Clear();

            // Columnas de Datos
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

            // Columnas de Acciones (Botones)
            g.Columns.Add(new DataGridViewButtonColumn { Name = "MarcarPagado", Text = "Marcar pagado", UseColumnTextForButtonValue = true, Width = 120 });
            g.Columns.Add(new DataGridViewButtonColumn { Name = "Cancelar", Text = "Cancelar", UseColumnTextForButtonValue = true, Width = 90 });
            g.Columns.Add(new DataGridViewButtonColumn { Name = "Recibo", Text = "Generar PDF", UseColumnTextForButtonValue = true, Width = 110 });

            _gridCfg = true;
        }

        // Carga (o recarga) los datos de las reservas en la grilla.
        private void CargarGrilla()
        {
            // Carga un rango de fechas: 7 días atrás y 1 mes adelante
            dgvReservas.DataSource = ReservasService.Listar(DateTime.Today.AddDays(-7), DateTime.Today.AddMonths(1), true);
            DecorarBotones(); // Aplica estilo a los botones después de cargar
        }

        // Resetea los campos del formulario de nueva reserva a sus valores por defecto.
        private void LimpiarForm()
        {
            if (cmbJugador.Items.Count > 0) cmbJugador.SelectedIndex = 0;
            if (cmbCancha.Items.Count > 0) cmbCancha.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Today;
            numDuracion.Value = 1;
            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedIndex = 0;
            cmbMetodoPago.SelectedIndex = -1;
            ToggleMetodoPago(); // Asegura que el combo de pago esté en el estado correcto
        }

        // Actualiza el ComboBox de Horarios. Obtiene las reservas existentes para
        // la cancha y día seleccionados y las usa para deshabilitar visualmente
        // los horarios ocupados (ver cmbHorario_DrawItem).
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
                return; // Si no hay cancha seleccionada, no hace nada
            }

            int duracionEnMinutos = (int)numDuracion.Value * 60;
            var fecha = dtpFecha.Value.Date;

            // Obtiene las reservas del día para validar solapamientos
            _reservasDelDia = ReservasService.GetReservasDeCanchaPorDia(canchaId, fecha);

            // Genera la lista de todos los slots de horarios posibles (cada 60 min)
            var todos = new List<DateTime>();
            DateTime inicioVentana = fecha + _apertura;
            DateTime finVentana = fecha + _cierre;
            DateTime ultimoInicio = finVentana.AddMinutes(-duracionEnMinutos);

            for (var s = inicioVentana; s <= ultimoInicio; s = s.AddMinutes(60))
                todos.Add(s);

            // Carga los items en el ComboBox
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

   
        // cada horario se coloreá de gris si el horario se solapa con una reserva existente.
        private void cmbHorario_DrawItem(object? sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index < 0) return;

            var combo = (ComboBox)sender!;
            var item = combo.Items[e.Index];

            // Extrae el valor DateTime
            var dt = (DateTime)item.GetType().GetProperty("Valor")!.GetValue(item)!;
            int duracionEnMinutos = (int)numDuracion.Value * 60;

            // Comprueba si este slot está ocupado
            bool ocupado = _reservasDelDia.Any(r => SeSolapa(dt, duracionEnMinutos, r.inicio, r.durMin));

            // Pinta el texto en el color correspondiente
            var color = ocupado ? SystemBrushes.GrayText : SystemBrushes.ControlText;
            e.Graphics.DrawString((string)item.GetType().GetProperty("Texto")!.GetValue(item)!, e.Font!, color, e.Bounds);
            e.DrawFocusRectangle();
        }

        // Valida si el horario seleccionado por el usuario está realmente disponible.
        private void cmbHorario_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_silenciarHorarioChange || cmbHorario.SelectedIndex < 0) return;

            var item = cmbHorario.SelectedItem!;
            var dt = (DateTime)item.GetType().GetProperty("Valor")!.GetValue(item)!;
            int duracionEnMinutos = (int)numDuracion.Value * 60;

            bool ocupado = _reservasDelDia.Any(r => SeSolapa(dt, duracionEnMinutos, r.inicio, r.durMin));

            // Si está ocupado, informa al usuario y resetea la selección
            if (ocupado)
            {
                MessageBox.Show("Ese horario ya está reservado o se superpone con otra reserva.");
                cmbHorario.SelectedIndex = -1;
            }
        }

        // Valida que todos los campos del formulario de reserva sean correctos antes de guardar.
        private bool Validar()
        {
            if (cmbJugador.SelectedValue is not int) { MessageBox.Show("Seleccione un jugador."); return false; }
            if (cmbCancha.SelectedValue is not int) { MessageBox.Show("Seleccione una cancha."); return false; }
            if (cmbHorario.SelectedValue is not DateTime) { MessageBox.Show("Seleccione un horario disponible."); return false; }
            if (numDuracion.Value <= 0) { MessageBox.Show("La duración debe ser de al menos 1 hora."); return false; }

            // Validación específica para estado "Pagado"
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

        // Manejador del evento Click del botón Guardar.
        // Valida los datos y crea la nueva reserva.
        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

            // Recopila datos del formulario
            int jugadorId = (int)cmbJugador.SelectedValue;
            int canchaId = (int)cmbCancha.SelectedValue;
            DateTime inicio = (DateTime)cmbHorario.SelectedValue;
            int duracionEnMinutos = (int)numDuracion.Value * 60;

            // Doble chequeo de solapamiento (por si acaso la data cambió)
            if (_reservasDelDia.Any(r => SeSolapa(inicio, duracionEnMinutos, r.inicio, r.durMin)))
            {
                MessageBox.Show("La cancha ya está reservada en ese horario.");
                RefrescarHorarios();
                return;
            }

            int estadoId = (int)cmbEstado.SelectedValue;
            string? metodoPago = (cmbMetodoPago.Enabled && cmbMetodoPago.SelectedItem != null) ? cmbMetodoPago.SelectedItem.ToString() : null;

            // Intenta crear la reserva
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
                // Muestra un ícono diferente si es una advertencia de negocio o un error fatal
                MessageBox.Show("Error al guardar: " + ex.Message, ex is InvalidOperationException ? "Atención" : "Error", MessageBoxButtons.OK, ex is InvalidOperationException ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
                RefrescarHorarios();
            }
        }

        // Manejador principal para todos los clics en la grilla.
        // Detecta qué columna (botón) se presionó y ejecuta la acción correspondiente.
        private void dgvReservas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Evita re-entrada si la acción anterior no ha terminado
            if (_handlingGridAction) return;
            _handlingGridAction = true;
            try
            {
                // Ignora clics en el encabezado
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                var colName = dgvReservas.Columns[e.ColumnIndex].Name;
                var row = dgvReservas.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                string estado = Convert.ToString(row.Cells["Estado"].Value) ?? "";
                bool activa = row.Cells["Activa"].Value as bool? ?? false;

                // --- ACCIÓN: Marcar Pagado ---
                if (colName == "MarcarPagado")
                {
                    // No hacer nada si ya está pagada o inactiva
                    if (!activa || estado.Equals("Pagado", StringComparison.OrdinalIgnoreCase)) return;

                    _idReservaEditando = id; // Guarda el ID de la reserva que estamos editando

                    // Calcula la posición de la celda "MetodoPago" en esa fila
                    var cellRectangle = dgvReservas.GetCellDisplayRectangle(
                        dgvReservas.Columns["MetodoPago"].Index, e.RowIndex, false);

                    // Mueve y muestra el ComboBox oculto sobre la celda
                    cmbMetodoPagoGrid.Location = cellRectangle.Location;
                    cmbMetodoPagoGrid.Size = cellRectangle.Size;
                    cmbMetodoPagoGrid.Visible = true;
                    cmbMetodoPagoGrid.BringToFront();
                    cmbMetodoPagoGrid.Focus();
                    cmbMetodoPagoGrid.DroppedDown = true; // Despliega la lista
                }
                // --- ACCIÓN: Cancelar ---
                else if (colName == "Cancelar")
                {
                    if (!activa) return; // No se puede cancelar una reserva ya inactiva

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
                // --- ACCIÓN: Generar Recibo PDF ---
                else if (colName == "Recibo")
                {
                    // Solo se pueden generar recibos de reservas activas y pagadas
                    if (!activa || !estado.Equals("Pagado", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Solo disponible para reservas activas y pagadas.");
                        return;
                    }

                    // Abre el diálogo para guardar el archivo
                    using var sfd = new SaveFileDialog
                    {
                        Filter = "PDF (*.pdf)|*.pdf",
                        FileName = $"Recibo_Reserva_{id}_{DateTime.Now:yyyyMMdd_HHmm}.pdf",
                        Title = "Guardar recibo PDF"
                    };

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Obtiene los datos y llama al generador de PDF
                            var info = ReservasService.GetReciboInfo(id);
                            GenerarReciboPdf(sfd.FileName, id, info);
                            MessageBox.Show("Recibo generado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al generar recibo: " + ex.Message);
                        }
                    }
                }
            }
            finally
            {
                _handlingGridAction = false;
            }
        }

        // Manejador que se dispara cuando el usuario selecciona un método de pago.
        private void cmbMetodoPagoGrid_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            if (cmbMetodoPagoGrid.SelectedItem == null || _idReservaEditando == -1) return;

            if (cmbEstado.DataSource is not DataTable est)
            {
                MessageBox.Show("No se pudo acceder a la lista de estados.");
                return;
            }

            string metodo = cmbMetodoPagoGrid.SelectedItem.ToString()!;

            try
            {
                // Busca el ID del estado "Pagado"
                int estadoPagadoId = est.AsEnumerable()
                    .First(r => string.Equals(r.Field<string>("Nombre"), "Pagado", StringComparison.OrdinalIgnoreCase))
                    .Field<int>("Id");

                // Actualiza el estado y método de pago
                ReservasService.SetEstado(_idReservaEditando, estadoPagadoId, metodo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la reserva: " + ex.Message);
            }
            finally
            {
                OcultarComboBoxGrid();
                CargarGrilla(); // Recarga la grilla para mostrar el cambio
            }
        }

        // Oculta el ComboBox de pago de la grilla y resetea el ID de edición.
        private void OcultarComboBoxGrid()
        {
            _idReservaEditando = -1;
            cmbMetodoPagoGrid.Visible = false;
        }

        // Recorre las filas y deshabilita visualmente los botones de acción
        // según el estado de cada reserva.
        private void DecorarBotones()
        {
            foreach (DataGridViewRow row in dgvReservas.Rows)
            {
                string estado = Convert.ToString(row.Cells["Estado"].Value) ?? "";
                bool activa = row.Cells["Activa"].Value as bool? ?? false;

                // Lógica para el botón "MarcarPagado"
                if (row.Cells["MarcarPagado"] is DataGridViewButtonCell btnPagar)
                {
                    bool deshabilitar = !activa || estado.Equals("Pagado", StringComparison.OrdinalIgnoreCase);
                    btnPagar.ReadOnly = deshabilitar;
                    btnPagar.FlatStyle = FlatStyle.Standard;
                    btnPagar.Style.ForeColor = deshabilitar ? Color.Gray : Color.Black;
                    btnPagar.Style.SelectionForeColor = btnPagar.Style.ForeColor;
                    btnPagar.Value = deshabilitar ? "—" : "Marcar pagado";
                }

                // Lógica para el botón "Cancelar"
                if (row.Cells["Cancelar"] is DataGridViewButtonCell btnCanc)
                {
                    bool deshabilitar = !activa;
                    btnCanc.ReadOnly = deshabilitar;
                    btnCanc.FlatStyle = FlatStyle.Standard;
                    btnCanc.Style.ForeColor = deshabilitar ? Color.Gray : Color.Black;
                    btnCanc.Style.SelectionForeColor = btnCanc.Style.ForeColor;
                    btnCanc.Value = deshabilitar ? "—" : "Cancelar";
                }

                // Lógica para el botón "Recibo"
                if (row.Cells["Recibo"] is DataGridViewButtonCell btnRec)
                {
                    bool habilitar = activa && estado.Equals("Pagado", StringComparison.OrdinalIgnoreCase);
                    btnRec.ReadOnly = !habilitar;
                    btnRec.FlatStyle = FlatStyle.Standard;
                    btnRec.Style.ForeColor = habilitar ? Color.Black : Color.Gray;
                    btnRec.Style.SelectionForeColor = btnRec.Style.ForeColor;
                    btnRec.Value = habilitar ? "Generar PDF" : "—";
                }
            }
        }

        // Genera un archivo PDF de recibo para una reserva específica usando iTextSharp.
        private static void GenerarReciboPdf(string path, int reservaId,
            (string Jugador, string Cancha, DateTime Inicio, DateTime Fin, int DuracionMin,
             decimal PrecioHora, string Estado, string? MetodoPago, string Canchero) info)
        {
            var horas = Math.Round(info.DuracionMin / 60m, 2);
            var subtotal = Math.Round(info.PrecioHora * horas, 2);

            using var fs = new FileStream(path, FileMode.Create);
            var doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(doc, fs);
            doc.Open();

            // Definición de fuentes
            var fTitulo = FontFactory.GetFont("Arial", 16f, iTextSharp.text.Font.BOLD);
            var fLabel = FontFactory.GetFont("Arial", 10f, iTextSharp.text.Font.BOLD);
            var fText = FontFactory.GetFont("Arial", 10f);

            // Encabezado
            var titulo = new Paragraph("Recibo de Reserva", fTitulo) { Alignment = Element.ALIGN_CENTER };
            doc.Add(titulo);
            doc.Add(new Paragraph($"Número: #{reservaId}", fText));
            doc.Add(new Paragraph($"Fecha emisión: {DateTime.Now:dd/MM/yyyy HH:mm}", fText));
            doc.Add(new Paragraph(" ")); // Espacio

            // Tabla de detalles
            var tabla = new PdfPTable(2) { WidthPercentage = 100 };

            // Función local para agregar celdas fácilmente
            void Cell(string label, string value)
            {
                tabla.AddCell(new Phrase(label, fLabel));
                tabla.AddCell(new Phrase(value, fText));
            }

            // Agregado de datos
            Cell("Jugador", info.Jugador);
            Cell("Cancha", info.Cancha);
            Cell("Inicio", info.Inicio.ToString("dd/MM/yyyy HH:mm"));
            Cell("Fin", info.Fin.ToString("dd/MM/yyyy HH:mm"));
            Cell("Duración (hs)", horas.ToString("0.##"));
            Cell("Precio por hora", $"$ {info.PrecioHora:N2}");
            Cell("Importe", $"$ {subtotal:N2}");
            Cell("Estado", info.Estado);
            Cell("Método de pago", string.IsNullOrWhiteSpace(info.MetodoPago) ? "-" : info.MetodoPago);
            Cell("Atendido por", info.Canchero);

            doc.Add(tabla);
            doc.Close();
        }

        // --- Manejadores de eventos vacíos (requeridos por el Diseñador) ---

        private void dgvReservas_CellContentClick(object? sender, DataGridViewCellEventArgs e) { }
        private void cmbHorario_SelectedIndexChanged_1(object sender, EventArgs e) { }
        private void btnLimpiar2_Click(object sender, EventArgs e) { }
        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}