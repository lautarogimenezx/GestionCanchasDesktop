using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    public partial class CanchasForm : Form
    {
        private bool _gridCfg = false;
        private int? _editandoId = null;

        public CanchasForm()
        {
            InitializeComponent();

            // enganches (si ya están en Designer, podés omitir)
            this.Load += CanchasForm_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            if (btnCancelar != null) btnCancelar.Click += btnCancelar_Click;
            dgvCanchas.CellClick += dgvCanchas_CellClick;
        }

        private void CanchasForm_Load(object? sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarTipos();
            CargarGrilla();
            LimpiarForm();
        }

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

            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nro", DataPropertyName = "NroCancha", HeaderText = "N°", Width = 60 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tipo", DataPropertyName = "Tipo", HeaderText = "Tipo", Width = 140 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Ubicacion", DataPropertyName = "Ubicacion", HeaderText = "Ubicación", Width = 220 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "Precio", DataPropertyName = "PrecioHora", HeaderText = "Precio/h", Width = 90, DefaultCellStyle = { Format = "C2" } });
            g.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Estado", DataPropertyName = "Activo", HeaderText = "Estado", Width = 70 });

            g.Columns.Add(new DataGridViewButtonColumn { Name = "Editar", Text = "Editar", UseColumnTextForButtonValue = true, Width = 70 });
            g.Columns.Add(new DataGridViewButtonColumn { Name = "Baja_Alta", Text = "Baja/Alta", UseColumnTextForButtonValue = true, Width = 80 });

            _gridCfg = true;
        }

        private void CargarTipos()
        {
            // Tipos predefinidos; si querés, podés habilitar edición libre
            var tipos = new[] { "Fútbol 5", "Fútbol 7", "Fútbol 11", "Pádel", "Tenis", "Básquet", "Vóley" };
            cmbTipo.DataSource = tipos;
        }

        private void CargarGrilla()
        {
            var dt = CanchasService.Listar(incluirInactivos: true);
            dgvCanchas.DataSource = null;
            dgvCanchas.DataSource = dt;
        }

        private void LimpiarForm()
        {
            txtNro.Clear();
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
            txtUbicacion.Clear();
            txtPrecio.Clear();
            chkActivo.Checked = true;
            _editandoId = null;
            btnGuardar.Text = "Guardar";
            txtNro.Focus();
        }

        private bool Validar()
        {
            if (!int.TryParse(txtNro.Text.Trim(), out int nro) || nro <= 0)
            {
                MessageBox.Show("Ingresá un número de cancha válido."); return false;
            }
            if (cmbTipo.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná el tipo de cancha."); return false;
            }
            if (!decimal.TryParse(txtPrecio.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingresá un precio/hora válido."); return false;
            }
            return true;
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

            int nro = int.Parse(txtNro.Text.Trim());
            string tipo = cmbTipo.SelectedItem!.ToString()!;
            string? ubic = string.IsNullOrWhiteSpace(txtUbicacion.Text) ? null : txtUbicacion.Text.Trim();
            decimal precio = decimal.Parse(txtPrecio.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture);
            bool activo = chkActivo.Checked;

            try
            {
                if (_editandoId is null)
                {
                    CanchasService.Crear(nro, tipo, ubic, precio, activo);
                    MessageBox.Show("✅ Cancha creada.");
                }
                else
                {
                    CanchasService.Actualizar(_editandoId.Value, nro, tipo, ubic, precio, activo);
                    MessageBox.Show("✅ Cancha actualizada.");
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

        private void btnCancelar_Click(object? sender, EventArgs e) => this.Close();

        private void dgvCanchas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dgvCanchas.Columns[e.ColumnIndex].Name;

            if (col.Equals("Editar", StringComparison.OrdinalIgnoreCase))
            {
                var row = dgvCanchas.Rows[e.RowIndex];
                _editandoId = Convert.ToInt32(row.Cells["Id"].Value);
                txtNro.Text = Convert.ToString(row.Cells["Nro"].Value) ?? "";
                cmbTipo.SelectedItem = Convert.ToString(row.Cells["Tipo"].Value) ?? null;
                txtUbicacion.Text = Convert.ToString(row.Cells["Ubicacion"].Value) ?? "";
                txtPrecio.Text = Convert.ToDecimal(row.Cells["Precio"].Value).ToString("0.##");
                chkActivo.Checked = Convert.ToBoolean(row.Cells["Estado"].Value);
                btnGuardar.Text = "Actualizar";
            }

            if (col.Equals("Baja_Alta", StringComparison.OrdinalIgnoreCase))
            {
                int id = Convert.ToInt32(dgvCanchas.Rows[e.RowIndex].Cells["Id"].Value);
                bool activo = Convert.ToBoolean(dgvCanchas.Rows[e.RowIndex].Cells["Estado"].Value);
                var msg = activo ? "¿Dar de baja esta cancha?" : "¿Reactivar esta cancha?";
                if (MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        CanchasService.SetActivo(id, !activo);
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
    }

}

