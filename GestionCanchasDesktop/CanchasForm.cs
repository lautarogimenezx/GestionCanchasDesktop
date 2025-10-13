using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    // Formulario para administrar las canchas (crear, editar, activar/desactivar).
    public partial class CanchasForm : Form
    {
        // Bandera para configurar la grilla una sola vez.
        private bool _gridCfg = false;
        // Guarda el ID de la cancha que se está editando. Si es null, es una cancha nueva.
        private int? _editandoId = null;

        // Constructor del formulario.
        public CanchasForm()
        {
            InitializeComponent();

            // Conectamos los eventos de los controles a los métodos correspondientes.
            this.Load += CanchasForm_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnCancelar.Click += btnCancelar_Click;
            dgvCanchas.CellClick += dgvCanchas_CellClick;

            // --- Validaciones para los TextBox ---
            // Solo se permiten números en el N° de cancha.
            txtNro.KeyPress += txtNumeros_KeyPress;
            // Para el precio, permitimos números y un separador decimal (coma o punto).
            txtPrecio.KeyPress += txtPrecio_KeyPress;
        }

        // Se ejecuta cuando el formulario se carga.
        private void CanchasForm_Load(object? sender, EventArgs e)
        {
            ConfigurarGrilla(); // 1. Arma la tabla.
            CargarTipos();      // 2. Carga los tipos de cancha en el desplegable.
            CargarGrilla();     // 3. Llena la tabla con los datos.
            LimpiarForm();      // 4. Limpia los campos.
        }

        // Define las columnas y el estilo de la grilla.
        private void ConfigurarGrilla()
        {
            if (_gridCfg) return;

            var g = dgvCanchas;
            g.AutoGenerateColumns = false;
            g.AllowUserToAddRows = false;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.ReadOnly = true;
            g.Columns.Clear();

            // Columnas de datos.
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nro", DataPropertyName = "NroCancha", HeaderText = "N°", Width = 60 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tipo", DataPropertyName = "Tipo", HeaderText = "Tipo", Width = 140 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Ubicacion", DataPropertyName = "Ubicacion", HeaderText = "Ubicación", Width = 220 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Precio", DataPropertyName = "PrecioHora", HeaderText = "Precio/h", Width = 90, DefaultCellStyle = { Format = "C2" } });
            g.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Estado", DataPropertyName = "Activo", HeaderText = "Estado", Width = 70 });

            // Columnas de botones.
            g.Columns.Add(new DataGridViewButtonColumn { Name = "Editar", Text = "Editar", UseColumnTextForButtonValue = true, Width = 70 });
            g.Columns.Add(new DataGridViewButtonColumn { Name = "Baja_Alta", Text = "Baja/Alta", UseColumnTextForButtonValue = true, Width = 80 });

            _gridCfg = true;
        }

        // Carga los tipos de cancha en el ComboBox.
        private void CargarTipos()
        {
            // Estos tipos están fijos en el código. Si se necesitaran más, se podrían traer de una tabla.
            var tipos = new[] { "Fútbol 5", "Fútbol 7", "Fútbol 11", "Pádel", "Tenis", "Básquet", "Vóley" };
            cmbTipo.DataSource = tipos;
        }

        // Carga todas las canchas en la grilla.
        private void CargarGrilla()
        {
            var dt = CanchasService.Listar(incluirInactivos: true);
            dgvCanchas.DataSource = null;
            dgvCanchas.DataSource = dt;
        }

        // Limpia todos los campos del formulario.
        private void LimpiarForm()
        {
            txtNro.Clear();
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
            txtUbicacion.Clear();
            txtPrecio.Clear();
            chkActivo.Checked = true;
            _editandoId = null; // Sale del modo edición.
            btnGuardar.Text = "Guardar";
            txtNro.Focus();
        }

        // Valida que los campos obligatorios (Nro y Precio) sean correctos.
        private bool Validar()
        {
            // Revisa si el número de cancha es un número válido y mayor a cero.
            if (!int.TryParse(txtNro.Text.Trim(), out int nro) || nro <= 0)
            {
                MessageBox.Show("Ingresá un número de cancha válido."); return false;
            }
            if (cmbTipo.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná el tipo de cancha."); return false;
            }
            // Revisa si el precio es un número decimal válido y mayor a cero.
            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingresá un precio por hora válido."); return false;
            }
            return true;
        }

        // Se ejecuta al hacer clic en "Guardar" o "Actualizar".
        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

            // Tomamos los valores de los campos.
            int nro = int.Parse(txtNro.Text.Trim());
            string tipo = cmbTipo.SelectedItem!.ToString()!;
            string? ubic = string.IsNullOrWhiteSpace(txtUbicacion.Text) ? null : txtUbicacion.Text.Trim();
            decimal precio = decimal.Parse(txtPrecio.Text.Trim());
            bool activo = chkActivo.Checked;

            try
            {
                if (_editandoId is null)
                {
                    // Si no hay ID, es una cancha NUEVA.
                    CanchasService.Crear(nro, tipo, ubic, precio, activo);
                    MessageBox.Show("✅ Cancha creada correctamente.");
                }
                else
                {
                    // Si hay ID, estamos EDITANDO una cancha existente.
                    CanchasService.Actualizar(_editandoId.Value, nro, tipo, ubic, precio, activo);
                    MessageBox.Show("✅ Cancha actualizada correctamente.");
                }

                CargarGrilla();
                LimpiarForm();
            }
            catch (InvalidOperationException ex) // Para errores controlados, como "Nro de cancha ya existe".
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) // Para cualquier otro error.
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e) => LimpiarForm();

        private void btnCancelar_Click(object? sender, EventArgs e) => this.Close();

        // Maneja los clics en los botones de la grilla.
        private void dgvCanchas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dgvCanchas.Columns[e.ColumnIndex].Name;
            var row = dgvCanchas.Rows[e.RowIndex];

            // Si se hizo clic en "Editar".
            if (col.Equals("Editar"))
            {
                _editandoId = Convert.ToInt32(row.Cells["Id"].Value);
                txtNro.Text = Convert.ToString(row.Cells["Nro"].Value);
                cmbTipo.SelectedItem = Convert.ToString(row.Cells["Tipo"].Value);
                txtUbicacion.Text = Convert.ToString(row.Cells["Ubicacion"].Value);
                // Formateamos el precio para que no muestre ceros de más en el TextBox.
                txtPrecio.Text = Convert.ToDecimal(row.Cells["Precio"].Value).ToString("G29");
                chkActivo.Checked = Convert.ToBoolean(row.Cells["Estado"].Value);
                btnGuardar.Text = "Actualizar";
            }

            // Si se hizo clic en "Baja/Alta".
            if (col.Equals("Baja_Alta"))
            {
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                bool activo = Convert.ToBoolean(row.Cells["Estado"].Value);
                var msg = activo ? "¿Dar de baja esta cancha?" : "¿Reactivar esta cancha?";
                if (MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        CanchasService.SetActivo(id, !activo);
                        CargarGrilla();
                        if (_editandoId == id) LimpiarForm(); // Limpiamos si estábamos editando la cancha modificada.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar estado: " + ex.Message);
                    }
                }
            }
        }

        // --- MÉTODOS DE VALIDACIÓN EN TIEMPO REAL ---

        // Permite escribir solo números y teclas de control (como borrar).
        private void txtNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignora la tecla.
            }
        }

        // Permite números, teclas de control y un único separador decimal.
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // El separador puede ser ',' o '.' dependiendo de la configuración del sistema.
            string separadorDecimal = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            var txt = sender as TextBox;

            // Permite números y teclas de control.
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                return; // Deja pasar la tecla.
            }

            // Permite un solo separador decimal.
            if (e.KeyChar.ToString() == separadorDecimal && !txt.Text.Contains(separadorDecimal))
            {
                return; // Deja pasar la tecla.
            }

            // Si no es ninguna de las anteriores, la ignora.
            e.Handled = true;
        }
    }
}