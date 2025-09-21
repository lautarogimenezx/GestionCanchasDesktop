using GestionCanchasDesktop;
using System;
using System.Data;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    public partial class ReportesForm : Form
    {
        public ReportesForm()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime? desde = dtpDesde.Checked ? dtpDesde.Value.Date : null;
            DateTime? hasta = dtpHasta.Checked ? dtpHasta.Value.Date.AddDays(1) : null;
            string agrupacion = cmbAgrupar.SelectedItem?.ToString() ?? "DIA";

            try
            {
                DataTable dt;
                if (rbRecaudacion.Checked)
                    dt = ReportesService.GetRecaudacion(desde, hasta, agrupacion);
                else if (rbHorarios.Checked)
                    dt = ReportesService.GetHorariosMasReservados(desde, hasta);
                else
                    dt = ReportesService.GetCancheroTop(desde, hasta);

                dgvReportes.DataSource = dt;

                // 👉 Mostrar siempre 2 decimales en columnas numéricas
                foreach (DataGridViewColumn col in dgvReportes.Columns)
                {
                    if (col.ValueType == typeof(decimal) ||
                        col.ValueType == typeof(double) ||
                        col.ValueType == typeof(float))
                    {
                        col.DefaultCellStyle.Format = "N2"; // dos decimales
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener reporte: " + ex.Message);
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpDesde.Checked = true;
            dtpHasta.Value = DateTime.Today;
            dtpHasta.Checked = true;
            btnBuscar.PerformClick();
        }

        private void btnUltimos7_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpDesde.Checked = true;
            dtpHasta.Value = DateTime.Today;
            dtpHasta.Checked = true;
            btnBuscar.PerformClick();
        }

        private void btnEsteMes_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDesde.Checked = true;
            dtpHasta.Value = DateTime.Today;
            dtpHasta.Checked = true;
            btnBuscar.PerformClick();
        }
    }
}
