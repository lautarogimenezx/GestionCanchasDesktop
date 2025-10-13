using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    // Este es el formulario para dar de alta, baja y modificar los usuarios.
    public partial class UsuariosForm : Form
    {
        // Usamos esto para que la grilla no se configure más de una vez.
        private bool _gridConfigurada = false;

        // Guardamos el ID del usuario que estamos editando. Si es null, es uno nuevo.
        private int? _editandoId = null;

        // El constructor del formulario, acá conectamos todos los eventos.
        public UsuariosForm()
        {
            InitializeComponent();

            // Eventos de los botones y del formulario
            this.Load += UsuariosForm_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnCancelar.Click += btnCancelar_Click;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;

            // Eventos para validar lo que se escribe en los TextBox
            txtNombre.KeyPress += txtLetras_KeyPress;
            txtApellido.KeyPress += txtLetras_KeyPress;
        }

        // Esto se dispara cuando el form se abre por primera vez.
        private void UsuariosForm_Load(object? sender, EventArgs e)
        {
            ConfigurarGrilla();   // 1. Arma la tabla (grilla).
            CargarRoles();        // 2. Llena el desplegable de roles.
            CargarGrilla();       // 3. Carga los usuarios en la tabla.
            LimpiarForm();        // 4. Limpia los campos para empezar.
        }

        // Este método arma la grilla la primera vez, define las columnas y los botones.
        private void ConfigurarGrilla()
        {
            if (_gridConfigurada) return;

            var g = dgvUsuarios;

            g.AutoGenerateColumns = false; // Importante para poner las columnas que nosotros queremos.
            g.AllowUserToAddRows = false;  // Saca la fila vacía de abajo.
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.ReadOnly = true;
            g.Columns.Clear();

            // Columnas que se llenan con los datos
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", DataPropertyName = "Nombre", Width = 140, HeaderText = "Nombre" });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido", DataPropertyName = "Apellido", Width = 140, HeaderText = "Apellido" });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", DataPropertyName = "Email", Width = 180, HeaderText = "Email" });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Rol", DataPropertyName = "Rol", Width = 120, HeaderText = "Rol" });
            g.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Estado", DataPropertyName = "Activo", HeaderText = "Estado", Width = 70 });

            // Columnas con los botones de acción
            g.Columns.Add(new DataGridViewButtonColumn { Name = "Editar", Text = "Editar", UseColumnTextForButtonValue = true, Width = 70 });
            g.Columns.Add(new DataGridViewButtonColumn { Name = "Baja_Alta", Text = "Baja/Alta", UseColumnTextForButtonValue = true, Width = 80 });

            _gridConfigurada = true;
        }

        // Trae los roles de la base de datos y los pone en el desplegable (ComboBox).
        private void CargarRoles()
        {
            var roles = AuthService.GetRoles()
                                     .Select(r => new { r.Id, r.Nombre })
                                     .ToList();

            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "Nombre"; // Lo que el usuario ve en la lista.
            cmbRol.ValueMember = "Id";       // El valor que usamos por detrás (el ID).
        }

        // Pide la lista de usuarios al service y la muestra en la grilla.
        private void CargarGrilla()
        {
            var dt = AuthService.ListarUsuarios(incluirInactivos: true);
            dgvUsuarios.DataSource = null;   // Limpiamos antes de recargar para que se refresque bien.
            dgvUsuarios.DataSource = dt;
        }

        // Limpia todos los campos del formulario y lo deja listo para empezar de nuevo.
        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            chkActivo.Checked = true;
            if (cmbRol.Items.Count > 0) cmbRol.SelectedIndex = 0;

            // Salimos del "modo edición".
            _editandoId = null;
            btnGuardar.Text = "Guardar";
            txtNombre.Focus(); // Dejamos el cursor en el primer campo.
        }

        // Revisa que no haya campos importantes vacíos antes de guardar.
        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("El campo Nombre es requerido."); return false; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { MessageBox.Show("El campo Apellido es requerido."); return false; }
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { MessageBox.Show("El campo Email es requerido."); return false; }
            if (cmbRol.SelectedItem == null) { MessageBox.Show("Debe seleccionar un rol."); return false; }

            // La contraseña es obligatoria solo cuando creamos un usuario nuevo.
            if (_editandoId == null && string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña para el nuevo usuario.");
                return false;
            }

            return true;
        }

        // Se ejecuta al hacer clic en "Guardar" o "Actualizar".
        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return; // Si la validación falla, no hacemos nada más.

            try
            {
                int rolId = (int)cmbRol.SelectedValue;

                if (_editandoId is null)
                {
                    // Si no hay ID, estamos CREANDO un usuario.
                    AuthService.CrearUsuario(
                        nombre: txtNombre.Text.Trim(),
                        apellido: txtApellido.Text.Trim(),
                        email: txtEmail.Text.Trim(),
                        password: txtPassword.Text,
                        rolId: rolId,
                        activo: chkActivo.Checked
                    );
                    MessageBox.Show("✅ Usuario creado correctamente.");
                }
                else
                {
                    // Si hay un ID, estamos ACTUALIZANDO uno que ya existe.
                    AuthService.ActualizarUsuario(
                        id: _editandoId.Value,
                        nombre: txtNombre.Text.Trim(),
                        apellido: txtApellido.Text.Trim(),
                        email: txtEmail.Text.Trim(),
                        rolId: rolId,
                        activo: chkActivo.Checked,
                        // Si el campo de contraseña está vacío, no la cambiamos (mandamos null).
                        nuevaPassword: string.IsNullOrEmpty(txtPassword.Text) ? null : txtPassword.Text
                    );
                    MessageBox.Show("✅ Usuario actualizado correctamente.");
                }

                CargarGrilla(); // Actualizamos la tabla.
                LimpiarForm();  // Limpiamos los campos.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Llama al método para limpiar el formulario.
        private void btnLimpiar_Click(object? sender, EventArgs e) => LimpiarForm();
        private void btnCancelar_Click(object? sender, EventArgs e) => LimpiarForm();

        // Este método se activa cuando se hace clic en cualquier celda de la grilla.
        private void dgvUsuarios_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Para que no tire error si se hace clic en la cabecera.

            string nombreCol = dgvUsuarios.Columns[e.ColumnIndex].Name;
            var row = dgvUsuarios.Rows[e.RowIndex];

            // Si se hizo clic en el botón "Editar".
            if (nombreCol.Equals("Editar"))
            {
                _editandoId = Convert.ToInt32(row.Cells["Id"].Value);

                // Pasamos los datos de la fila a los campos del formulario.
                txtNombre.Text = Convert.ToString(row.Cells["Nombre"].Value);
                txtApellido.Text = Convert.ToString(row.Cells["Apellido"].Value);
                txtEmail.Text = Convert.ToString(row.Cells["Email"].Value);
                chkActivo.Checked = Convert.ToBoolean(row.Cells["Estado"].Value);
                txtPassword.Clear(); // La contraseña nunca se muestra, solo se puede cambiar.

                // Buscamos el rol en el ComboBox para que quede seleccionado.
                string rolNombre = Convert.ToString(row.Cells["Rol"].Value);
                for (int i = 0; i < cmbRol.Items.Count; i++)
                {
                    dynamic item = cmbRol.Items[i];
                    if (item.Nombre == rolNombre)
                    {
                        cmbRol.SelectedIndex = i;
                        break;
                    }
                }

                btnGuardar.Text = "Actualizar";
            }

            // Si se hizo clic en el botón "Baja/Alta".
            if (nombreCol.Equals("Baja_Alta"))
            {
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                bool activo = Convert.ToBoolean(row.Cells["Estado"].Value);

                string msg = activo ? "¿Desactivar este usuario?" : "¿Activar este usuario?";
                if (MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    AuthService.SetActivo(id, !activo);
                    CargarGrilla(); // Recargamos la grilla para ver el cambio de estado.

                    // Si justo estábamos editando el usuario que desactivamos, limpiamos el form.
                    if (_editandoId == id)
                    {
                        LimpiarForm();
                    }
                }
            }
        }

        // Valida en tiempo real que solo se puedan escribir letras, espacios o usar la tecla de borrar.
        private void txtLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si la tecla presionada NO es una letra Y TAMPOCO es una tecla de control (como borrar)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                // Le decimos al sistema que "ignore" esa tecla, así que no se escribe.
                e.Handled = true;
            }
        }
    }
}