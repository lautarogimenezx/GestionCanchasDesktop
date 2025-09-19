using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    public partial class UsuariosForm : Form
    {
        private bool _gridConfigurada = false;
        private Form? _formActual; // si lo usás para cargar subforms; no es crítico acá
        private int? _editandoId = null;


        public UsuariosForm()
        {
            InitializeComponent();

            // Si estos eventos ya están conectados en el Designer, podés comentar estas líneas.
            this.Load += UsuariosForm_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            if (btnCancelar != null) btnCancelar.Click += btnCancelar_Click;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
        }

        // =========================================================
        // Load
        // =========================================================
        private void UsuariosForm_Load(object? sender, EventArgs e)
        {
            ConfigurarGrilla();   // 1) columnas y comportamiento (solo una vez)
            CargarRoles();        // 2) combo de roles
            CargarGrilla();       // 3) datos
            LimpiarForm();        // 4) limpiar campos
        }

        // =========================================================
        // Configurar grilla (solo una vez) -> SIN duplicar columnas
        // =========================================================
        private void ConfigurarGrilla()
        {
            if (_gridConfigurada) return;

            var g = dgvUsuarios;

            g.AutoGenerateColumns = false;          // importante: no autogenerar
            g.AllowUserToAddRows = false;           // sin fila vacía al final
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.ReadOnly = true;
            g.Columns.Clear();

            // Columnas enlazadas (coinciden con ListarUsuarios)
            g.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });
            g.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                DataPropertyName = "Nombre",
                Width = 140,
                HeaderText = "Nombre"
            });
            g.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Apellido",
                DataPropertyName = "Apellido",
                Width = 140,
                HeaderText = "Apellido"
            });
            g.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                DataPropertyName = "Email",
                Width = 180,
                HeaderText = "Email"
            });
            g.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Rol",
                DataPropertyName = "Rol",
                Width = 120,
                HeaderText = "Rol"
            });
            g.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Estado",
                DataPropertyName = "Activo",
                HeaderText = "Estado",
                Width = 70
            });

            // Botones
            g.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                Width = 70
            });
            g.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Baja_Alta",
                Text = "Baja/Alta",
                UseColumnTextForButtonValue = true,
                Width = 80
            });

            _gridConfigurada = true;
        }

        // =========================================================
        // Cargar roles en el combo (ValueMember = Id / DisplayMember = Nombre)
        // =========================================================
        private void CargarRoles()
        {
            var roles = AuthService.GetRoles()
                                   .Select(r => new { Id = r.Id, Nombre = r.Nombre })
                                   .ToList();

            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "Id";
        }

        // =========================================================
        // Cargar datos en la grilla (solo setear DataSource, no tocar columnas)
        // =========================================================
        private void CargarGrilla()
        {
            var dt = AuthService.ListarUsuarios(incluirInactivos: true);
            dgvUsuarios.DataSource = null;     // limpiar binding previo
            dgvUsuarios.DataSource = dt;
        }

        // =========================================================
        // Helpers
        // =========================================================
        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            chkActivo.Checked = true;
            if (cmbRol.Items.Count > 0) cmbRol.SelectedIndex = 0;
            _editandoId = null;                 // ← salir de edición
            btnGuardar.Text = "Guardar";        // ← texto default
            txtNombre.Focus();
        }


        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("Nombre requerido"); return false; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { MessageBox.Show("Apellido requerido"); return false; }
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { MessageBox.Show("Email requerido"); return false; }
            if (cmbRol.SelectedItem == null) { MessageBox.Show("Seleccione un rol"); return false; }
            if (string.IsNullOrEmpty(txtPassword.Text)) { MessageBox.Show("Ingrese una contraseña"); return false; }
            return true;
        }

        // =========================================================
        // Botones
        // =========================================================
        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                if (cmbRol.SelectedValue is not int rolId)
                {
                    MessageBox.Show("Seleccione un rol válido.");
                    return;
                }

                if (_editandoId is null)
                {
                    // CREAR
                    AuthService.CrearUsuario(
                        nombre: txtNombre.Text.Trim(),
                        apellido: txtApellido.Text.Trim(),
                        email: txtEmail.Text.Trim(),
                        password: txtPassword.Text,      // no trim
                        rolId: rolId,
                        activo: chkActivo.Checked
                    );
                    MessageBox.Show("✅ Usuario creado correctamente.");
                }
                else
                {
                    // ACTUALIZAR (si el password está vacío, no lo cambia)
                    AuthService.ActualizarUsuario(
                        id: _editandoId.Value,
                        nombre: txtNombre.Text.Trim(),
                        apellido: txtApellido.Text.Trim(),
                        email: txtEmail.Text.Trim(),
                        rolId: rolId,
                        activo: chkActivo.Checked,
                        nuevaPassword: string.IsNullOrEmpty(txtPassword.Text) ? null : txtPassword.Text
                    );
                    MessageBox.Show("✅ Usuario actualizado.");
                }

                CargarGrilla();
                LimpiarForm();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e) => LimpiarForm();

        private void btnCancelar_Click(object? sender, EventArgs e) => LimpiarForm();

        // =========================================================
        // Grilla: acciones por fila (Editar / Baja_Alta)
        // =========================================================

        private void dgvUsuarios_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var nombreCol = dgvUsuarios.Columns[e.ColumnIndex].Name;

            // ===== EDITAR =====
            if (nombreCol.Equals("Editar", StringComparison.OrdinalIgnoreCase))
            {
                var row = dgvUsuarios.Rows[e.RowIndex];

                // Guardamos el Id para modo edición
                _editandoId = Convert.ToInt32(row.Cells["Id"].Value);

                // Cargar campos
                txtNombre.Text = Convert.ToString(row.Cells["Nombre"].Value) ?? "";
                txtApellido.Text = Convert.ToString(row.Cells["Apellido"].Value) ?? "";
                txtEmail.Text = Convert.ToString(row.Cells["Email"].Value) ?? "";
                chkActivo.Checked = Convert.ToBoolean(row.Cells["Estado"].Value);

                // Limpiar password: si el usuario escribe algo, se actualizará la clave.
                txtPassword.Clear();

                // Seleccionar el Rol en el combo por NOMBRE que trae la grilla
                string rolNombre = Convert.ToString(row.Cells["Rol"].Value) ?? "";
                for (int i = 0; i < cmbRol.Items.Count; i++)
                {
                    dynamic it = cmbRol.Items[i]; // items son anónimos { Id, Nombre }
                    if (string.Equals((string)it.Nombre, rolNombre, StringComparison.OrdinalIgnoreCase))
                    {
                        cmbRol.SelectedIndex = i;
                        break;
                    }
                }

                // Feedback visual
                btnGuardar.Text = "Actualizar";
            }

            // ===== BAJA / ALTA =====
            if (nombreCol.Equals("Baja_Alta", StringComparison.OrdinalIgnoreCase))
            {
                int id = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["Id"].Value);
                bool activo = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["Estado"].Value);

                var msg = activo ? "¿Desactivar este usuario?" : "¿Activar este usuario?";
                if (MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        AuthService.SetActivo(id, !activo);
                        CargarGrilla();

                        // Si estabas editando justo este, salí de edición
                        if (_editandoId == id)
                        {
                            _editandoId = null;
                            btnGuardar.Text = "Guardar";
                            txtPassword.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar estado: " + ex.Message);
                    }
                }
            }
        }

    }
}
