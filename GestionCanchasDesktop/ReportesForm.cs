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

        // Esto se ejecuta cuando le damos clic al botón de buscar.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Agarro las fechas de los calendarios. Si el checkbox no está marcado, la fecha es null.
            DateTime? desde = dtpDesde.Checked ? dtpDesde.Value.Date : null;
            // A la fecha 'hasta' le sumo un día para que el filtro incluya el día completo.
            DateTime? hasta = dtpHasta.Checked ? dtpHasta.Value.Date.AddDays(1) : null;

            // Agarro lo que seleccionaron en el desplegable. Si no eligió nada, por defecto es "DIA".
            string agrupacion = cmbAgrupar.SelectedItem?.ToString() ?? "DIA";

            try
            {
                DataTable dt; // Una tabla para guardar los resultados que vengan del Service.

                // Me fijo qué reporte quiere ver el usuario según el radio button que marcó.
                if (rbRecaudacion.Checked)
                    dt = ReportesService.GetRecaudacion(desde, hasta, agrupacion);
                else if (rbHorarios.Checked)
                    dt = ReportesService.GetHorariosMasReservados(desde, hasta);
                else
                    dt = ReportesService.GetCancheroTop(desde, hasta);

                // Muestro los datos en la grilla.
                dgvReportes.DataSource = dt;

                // Este loop es para que los números en la tabla se vean más prolijos.
                foreach (DataGridViewColumn col in dgvReportes.Columns)
                {
                    // Si la columna es de tipo numérico...
                    if (col.ValueType == typeof(decimal) ||
                        col.ValueType == typeof(double) ||
                        col.ValueType == typeof(float))
                    {
                        // ...le pongo formato para que muestre 2 decimales y se alinee a la derecha.
                        col.DefaultCellStyle.Format = "N2";
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                // Si algo sale mal (ej: no se puede conectar a la DB), muestro un mensaje de error.
                MessageBox.Show("Error al obtener reporte: " + ex.Message);
            }
        }
    }
}