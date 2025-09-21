using System;
using System.Data;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    public partial class ReportesForm : Form
    {
        private bool _gridCfg = false;

        public ReportesForm()
        {
            InitializeComponent();
            this.Load += ReportesForm_Load;
            btnBuscar.Click += BtnBuscar_Click;
        }

        private void ReportesForm_Load(object? sender, EventArgs e)
        {
            ConfigurarGrilla();
            cmbAgrupar.Items.AddRange(new[] { "DIA", "SEMANA", "MES" });
            cmbAgrupar.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;
        }

        private void ConfigurarGrilla()
        {
            if (_gridCfg) return;
            var g = dgvReportes;
            g.AutoGenerateColumns = true;
            g.AllowUserToAddRows = false;
            g.ReadOnly = true;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.Columns.Clear();
            _gridCfg = true;
        }

        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            DateTime? desde = dtpDesde.Checked ? dtpDesde.Value.Date : null;
            DateTime? hasta = dtpHasta.Checked ? dtpHasta.Value.Date.AddDays(1) : null;
            string agrupacion = cmbAgrupar.SelectedItem?.ToString() ?? "DIA";

            try
            {
                if (rbRecaudacion.Checked)
                    dgvReportes.DataSource = ReportesService.GetRecaudacion(desde, hasta, agrupacion);
                else if (rbHorarios.Checked)
                    dgvReportes.DataSource = ReportesService.GetHorariosMasReservados(desde, hasta);
                else if (rbCanchero.Checked)
                    dgvReportes.DataSource = ReportesService.GetCancheroTop(desde, hasta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener reporte: " + ex.Message);
            }
        }
    }
}
