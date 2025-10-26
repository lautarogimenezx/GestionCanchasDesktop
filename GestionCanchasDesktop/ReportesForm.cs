using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

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

                foreach (DataGridViewColumn col in dgvReportes.Columns)
                {
                    if (col.ValueType == typeof(decimal) ||
                        col.ValueType == typeof(double) ||
                        col.ValueType == typeof(float))
                    {
                        col.DefaultCellStyle.Format = "N2";
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener reporte: " + ex.Message);
            }
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            if (dgvReportes.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmm}.pdf",
                Title = "Guardar reporte como PDF"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var doc = new Document(PageSize.A4, 40, 40, 40, 40);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    var fontTitulo = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD);
                    var fontSub = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL);
                    var fontTh = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);
                    var fontTd = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL);

                    var titulo = new Paragraph("Reporte de Gestión de Canchas", fontTitulo)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    doc.Add(titulo);
                    doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}", fontSub));
                    doc.Add(new Paragraph(" ", fontSub));

                    var table = new PdfPTable(dgvReportes.Columns.Count)
                    {
                        WidthPercentage = 100
                    };

                    foreach (DataGridViewColumn col in dgvReportes.Columns)
                    {
                        table.AddCell(new Phrase(col.HeaderText, fontTh));
                    }

                    foreach (DataGridViewRow row in dgvReportes.Rows)
                    {
                        if (row.IsNewRow) continue;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(new Phrase(cell.Value?.ToString() ?? string.Empty, fontTd));
                        }
                    }

                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
