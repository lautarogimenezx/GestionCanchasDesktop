using System;
using System.Data;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    // Este es el formulario para agregar, editar o dar de baja jugadores.
    public partial class JugadoresForm : Form
    {
        // Una bandera para asegurarnos de que la grilla se configure una sola vez.
        private bool _gridCfg = false;
        // Para saber si estamos editando un jugador existente (guardamos su ID acá).
        private int? _editandoId = null;

        // El constructor, donde conectamos todos los eventos.
        public JugadoresForm()
        {
            InitializeComponent();

            // Eventos de los botones y del formulario.
            this.Load += JugadoresForm_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnCancelar.Click += btnCancelar_Click;
            dgvJugadores.CellClick += dgvJugadores_CellClick;

            // --- Validaciones para los TextBox ---
            // Solo letras para nombre y apellido.
            txtNombre.KeyPress += txtLetras_KeyPress;
            txtApellido.KeyPress += txtLetras_KeyPress;
            // Solo números para el teléfono.
            txtTelefono.KeyPress += txtNumeros_KeyPress;
        }

        // Se ejecuta cuando el formulario carga por primera vez.
        private void JugadoresForm_Load(object? sender, EventArgs e)
        {
            ConfigurarGrilla(); // 1. Prepara la tabla.
            CargarGrilla();     // 2. Carga los datos en la tabla.
            LimpiarForm();      // 3. Limpia los campos para empezar.
        }

        // Define las columnas y el estilo de la grilla de jugadores.
        private void ConfigurarGrilla()
        {
            if (_gridCfg) return; // Si ya está configurada, no hace nada.

            var g = dgvJugadores;
            g.AutoGenerateColumns = false; // Para poder definir nuestras propias columnas.
            g.AllowUserToAddRows = false;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.ReadOnly = true;
            g.Columns.Clear();

            // Columnas de datos.
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", DataPropertyName = "Nombre", HeaderText = "Nombre", Width = 180 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido", DataPropertyName = "Apellido", HeaderText = "Apellido", Width = 180 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", DataPropertyName = "Telefono", HeaderText = "Teléfono", Width = 140 });
            g.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Estado", DataPropertyName = "Activo", HeaderText = "Estado", Width = 70 });

            // Columnas con botones.
            g.Columns.Add(new DataGridViewButtonColumn { Name = "Editar", Text = "Editar", UseColumnTextForButtonValue = true, Width = 70 });
            g.Columns.Add(new DataGridViewButtonColumn { Name = "Eliminar", Text = "Baja/Alta", UseColumnTextForButtonValue = true, Width = 80 }); // Cambié el texto para que sea más claro.

            _gridCfg = true;
        }

        // Carga los jugadores desde la base de datos y los muestra en la grilla.
        private void CargarGrilla()
        {
            var dt = JugadoresService.Listar(incluirInactivos: true);
            dgvJugadores.DataSource = null; // Se limpia para que se refresque bien.
            dgvJugadores.DataSource = dt;
        }

        // Limpia todos los campos del formulario.
        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            _editandoId = null; // Sale del modo edición.
            btnGuardar.Text = "Guardar";
            txtNombre.Focus(); // Pone el cursor en el campo Nombre.
        }

        // Valida que los campos obligatorios estén completos.
        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("El Nombre es requerido."); return false; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { MessageBox.Show("El Apellido es requerido."); return false; }

            return true;
        }

        // Se ejecuta al hacer clic en "Guardar" o "Actualizar".
        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return; // Si no pasa la validación, no sigue.

            try
            {
                if (_editandoId is null)
                {
                    // Si _editandoId es null, es un jugador NUEVO.
                    JugadoresService.Crear(
                        nombre: txtNombre.Text.Trim(),
                        apellido: txtApellido.Text.Trim(),
                        // Si el teléfono está vacío, guardamos null.
                        telefono: string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim()
                    );
                    MessageBox.Show("✅ Jugador creado correctamente.");
                }
                else
                {
                    // Si tiene un valor, estamos EDITANDO un jugador existente.
                    JugadoresService.Actualizar(
                        id: _editandoId.Value,
                        nombre: txtNombre.Text.Trim(),
                        apellido: txtApellido.Text.Trim(),
                        telefono: string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                        activo: true // Al editar, lo dejamos como activo por defecto.
                    );
                    MessageBox.Show("✅ Jugador actualizado correctamente.");
                }

                CargarGrilla(); // Refrescamos la tabla.
                LimpiarForm();  // Limpiamos los campos.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e) => LimpiarForm();

        private void btnCancelar_Click(object? sender, EventArgs e) => this.Close();

        // Maneja los clics en los botones de la grilla ("Editar" y "Eliminar").
        private void dgvJugadores_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Si hacen clic en la cabecera, no hace nada.

            var col = dgvJugadores.Columns[e.ColumnIndex].Name;
            var row = dgvJugadores.Rows[e.RowIndex];

            // Si se hizo clic en el botón "Editar".
            if (col.Equals("Editar"))
            {
                _editandoId = Convert.ToInt32(row.Cells["Id"].Value);
                txtNombre.Text = Convert.ToString(row.Cells["Nombre"].Value) ?? "";
                txtApellido.Text = Convert.ToString(row.Cells["Apellido"].Value) ?? "";
                txtTelefono.Text = Convert.ToString(row.Cells["Telefono"].Value) ?? "";
                btnGuardar.Text = "Actualizar";
            }

            // Si se hizo clic en el botón "Eliminar" (que en realidad da de baja o alta).
            if (col.Equals("Eliminar"))
            {
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                bool activo = Convert.ToBoolean(row.Cells["Estado"].Value);

                var msg = activo ? "¿Dar de baja a este jugador?" : "¿Reactivar a este jugador?";
                if (MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        JugadoresService.SetActivo(id, !activo);
                        CargarGrilla();
                        // Si estábamos editando el jugador que se dio de baja, limpiamos el form.
                        if (_editandoId == id) LimpiarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar el estado: " + ex.Message);
                    }
                }
            }
        }

        // --- MÉTODOS DE VALIDACIÓN EN TIEMPO REAL ---

        // Método para permitir solo letras y teclas de control (borrar, espacio).
        private void txtLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true; // Ignora la tecla si no es una letra.
            }
        }

        // Método para permitir solo números y teclas de control (borrar).
        private void txtNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignora la tecla si no es un número.
            }
        }
    }
}