using System;
using System.Data;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    public partial class JugadoresForm : Form
    {
        private bool _gridCfg = false;
        private int? _editandoId = null;

        public JugadoresForm()
        {
            InitializeComponent();

            
            this.Load += JugadoresForm_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            if (btnCancelar != null) btnCancelar.Click += btnCancelar_Click;
            dgvJugadores.CellClick += dgvJugadores_CellClick;
        }

        private void JugadoresForm_Load(object? sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarGrilla();
            LimpiarForm();
        }

        private void ConfigurarGrilla()
        {
            if (_gridCfg) return;

            var g = dgvJugadores;
            g.AutoGenerateColumns = false;
            g.AllowUserToAddRows = false;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.ReadOnly = true;
            g.Columns.Clear();

            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", DataPropertyName = "Nombre", HeaderText = "Nombre", Width = 180 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido", DataPropertyName = "Apellido", HeaderText = "Apellido", Width = 180 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", DataPropertyName = "Telefono", HeaderText = "Teléfono", Width = 140 });
            g.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Estado", DataPropertyName = "Activo", HeaderText = "Estado", Width = 70 });

            g.Columns.Add(new DataGridViewButtonColumn { Name = "Editar", Text = "Editar", UseColumnTextForButtonValue = true, Width = 70 });
            g.Columns.Add(new DataGridViewButtonColumn { Name = "Eliminar", Text = "Baja", UseColumnTextForButtonValue = true, Width = 70 });

            _gridCfg = true;
        }

        private void CargarGrilla()
        {
            var dt = JugadoresService.Listar(incluirInactivos: true);
            dgvJugadores.DataSource = null;
            dgvJugadores.DataSource = dt;
        }

        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            _editandoId = null;
            btnGuardar.Text = "Guardar";
            txtNombre.Focus();
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("Nombre requerido"); return false; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { MessageBox.Show("Apellido requerido"); return false; }

            return true;
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                if (_editandoId is null)
                {
                    JugadoresService.Crear(
                        nombre: txtNombre.Text.Trim(),
                        apellido: txtApellido.Text.Trim(),
                        telefono: string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim()
                    );
                    MessageBox.Show("✅ Jugador creado.");
                }
                else
                {
                    JugadoresService.Actualizar(
                        id: _editandoId.Value,
                        nombre: txtNombre.Text.Trim(),
                        apellido: txtApellido.Text.Trim(),
                        telefono: string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                        activo: true // al editar lo dejamos activo; podés exponer un checkbox si querés
                    );
                    MessageBox.Show("✅ Jugador actualizado.");
                }

                CargarGrilla();
                LimpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e) => LimpiarForm();

        private void btnCancelar_Click(object? sender, EventArgs e) => this.Close();

        private void dgvJugadores_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dgvJugadores.Columns[e.ColumnIndex].Name;

            if (col.Equals("Editar", StringComparison.OrdinalIgnoreCase))
            {
                var row = dgvJugadores.Rows[e.RowIndex];
                _editandoId = Convert.ToInt32(row.Cells["Id"].Value);
                txtNombre.Text = Convert.ToString(row.Cells["Nombre"].Value) ?? "";
                txtApellido.Text = Convert.ToString(row.Cells["Apellido"].Value) ?? "";
                txtTelefono.Text = Convert.ToString(row.Cells["Telefono"].Value) ?? "";
                btnGuardar.Text = "Actualizar";
            }

            if (col.Equals("Eliminar", StringComparison.OrdinalIgnoreCase))
            {
                int id = Convert.ToInt32(dgvJugadores.Rows[e.RowIndex].Cells["Id"].Value);
                bool activo = Convert.ToBoolean(dgvJugadores.Rows[e.RowIndex].Cells["Estado"].Value);

                var msg = activo ? "¿Dar de baja este jugador?" : "¿Reactivar este jugador?";
                if (MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        JugadoresService.SetActivo(id, !activo);
                        CargarGrilla();
                        if (_editandoId == id) LimpiarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar estado: " + ex.Message);
                    }
                }
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
