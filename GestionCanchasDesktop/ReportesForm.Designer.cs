using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    partial class ReportesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.Drawing.Color COLOR_ACENTO = System.Drawing.Color.FromArgb(139, 38, 56);
            System.Drawing.Color COLOR_FONDO_PRIMARIO = System.Drawing.Color.FromArgb(248, 248, 248);
            System.Drawing.Color COLOR_FONDO_TARJETA = System.Drawing.Color.White;
            System.Drawing.Color COLOR_TEXTO_OSCURO = System.Drawing.Color.FromArgb(30, 30, 30);
            System.Drawing.Color COLOR_TEXTO_SECUNDARIO = System.Drawing.Color.FromArgb(100, 100, 100);

            panelFiltros = new Panel();
            btnBuscar = new Button();
            btnExportarPdf = new Button();            // <-- ¡instanciado!
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            cmbAgrupar = new ComboBox();
            rbRecaudacion = new RadioButton();
            rbHorarios = new RadioButton();
            rbCanchero = new RadioButton();
            dgvReportes = new DataGridView();
            lblTituloFiltros = new Label();
            lblDesde = new Label();
            lblHasta = new Label();
            lblAgrupar = new Label();
            lblTipoReporte = new Label();

            panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            SuspendLayout();

            // ReportesForm
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = COLOR_FONDO_PRIMARIO;
            ClientSize = new System.Drawing.Size(780, 500);
            Controls.Add(dgvReportes);
            Controls.Add(panelFiltros);
            Name = "ReportesForm";
            Text = "Reportes";
            Padding = new System.Windows.Forms.Padding(15);

            // panelFiltros
            panelFiltros.BackColor = COLOR_FONDO_TARJETA;
            panelFiltros.Controls.Add(lblTipoReporte);
            panelFiltros.Controls.Add(lblAgrupar);
            panelFiltros.Controls.Add(lblHasta);
            panelFiltros.Controls.Add(lblDesde);
            panelFiltros.Controls.Add(lblTituloFiltros);
            panelFiltros.Controls.Add(btnExportarPdf); // agregar antes o después da igual, ya está instanciado
            panelFiltros.Controls.Add(btnBuscar);
            panelFiltros.Controls.Add(dtpDesde);
            panelFiltros.Controls.Add(dtpHasta);
            panelFiltros.Controls.Add(cmbAgrupar);
            panelFiltros.Controls.Add(rbRecaudacion);
            panelFiltros.Controls.Add(rbHorarios);
            panelFiltros.Controls.Add(rbCanchero);
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Location = new System.Drawing.Point(15, 15);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Padding = new System.Windows.Forms.Padding(20);
            panelFiltros.Size = new System.Drawing.Size(750, 150);
            panelFiltros.TabIndex = 0;

            // lblTituloFiltros
            lblTituloFiltros.AutoSize = true;
            lblTituloFiltros.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTituloFiltros.ForeColor = COLOR_TEXTO_OSCURO;
            lblTituloFiltros.Location = new System.Drawing.Point(20, 15);
            lblTituloFiltros.Name = "lblTituloFiltros";
            lblTituloFiltros.Size = new System.Drawing.Size(161, 25);
            lblTituloFiltros.TabIndex = 12;
            lblTituloFiltros.Text = "Filtros de Reporte";

            // lblDesde
            lblDesde.AutoSize = true;
            lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblDesde.ForeColor = COLOR_TEXTO_SECUNDARIO;
            lblDesde.Location = new System.Drawing.Point(20, 50);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new System.Drawing.Size(42, 15);
            lblDesde.Text = "Desde:";

            // dtpDesde
            dtpDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new System.Drawing.Point(20, 68);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.ShowCheckBox = true;
            dtpDesde.Size = new System.Drawing.Size(120, 25);
            dtpDesde.TabIndex = 1;

            // lblHasta
            lblHasta.AutoSize = true;
            lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblHasta.ForeColor = COLOR_TEXTO_SECUNDARIO;
            lblHasta.Location = new System.Drawing.Point(160, 50);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new System.Drawing.Size(39, 15);
            lblHasta.Text = "Hasta:";

            // dtpHasta
            dtpHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new System.Drawing.Point(160, 68);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.ShowCheckBox = true;
            dtpHasta.Size = new System.Drawing.Size(120, 25);
            dtpHasta.TabIndex = 2;

            // lblAgrupar
            lblAgrupar.AutoSize = true;
            lblAgrupar.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblAgrupar.ForeColor = COLOR_TEXTO_SECUNDARIO;
            lblAgrupar.Location = new System.Drawing.Point(300, 50);
            lblAgrupar.Name = "lblAgrupar";
            lblAgrupar.Size = new System.Drawing.Size(76, 15);
            lblAgrupar.Text = "Agrupar por:";

            // cmbAgrupar
            cmbAgrupar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAgrupar.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbAgrupar.Items.AddRange(new object[] { "DIA", "SEMANA", "MES" });
            cmbAgrupar.Location = new System.Drawing.Point(300, 68);
            cmbAgrupar.Name = "cmbAgrupar";
            cmbAgrupar.Size = new System.Drawing.Size(121, 25);
            cmbAgrupar.TabIndex = 3;

            // lblTipoReporte
            lblTipoReporte.AutoSize = true;
            lblTipoReporte.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTipoReporte.ForeColor = COLOR_TEXTO_SECUNDARIO;
            lblTipoReporte.Location = new System.Drawing.Point(20, 110);
            lblTipoReporte.Name = "lblTipoReporte";
            lblTipoReporte.Size = new System.Drawing.Size(91, 15);
            lblTipoReporte.Text = "Tipo de Reporte:";

            // rbRecaudacion
            rbRecaudacion.AutoSize = true;
            rbRecaudacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            rbRecaudacion.ForeColor = COLOR_TEXTO_OSCURO;
            rbRecaudacion.Location = new System.Drawing.Point(130, 107);
            rbRecaudacion.Name = "rbRecaudacion";
            rbRecaudacion.Size = new System.Drawing.Size(107, 23);
            rbRecaudacion.TabIndex = 9;
            rbRecaudacion.TabStop = true;
            rbRecaudacion.Text = "Recaudación";
            rbRecaudacion.UseVisualStyleBackColor = true;

            // rbHorarios
            rbHorarios.AutoSize = true;
            rbHorarios.Font = new System.Drawing.Font("Segoe UI", 10F);
            rbHorarios.ForeColor = COLOR_TEXTO_OSCURO;
            rbHorarios.Location = new System.Drawing.Point(260, 107);
            rbHorarios.Name = "rbHorarios";
            rbHorarios.Size = new System.Drawing.Size(161, 23);
            rbHorarios.TabIndex = 10;
            rbHorarios.TabStop = true;
            rbHorarios.Text = "Horarios más pedidos";
            rbHorarios.UseVisualStyleBackColor = true;

            // rbCanchero
            rbCanchero.AutoSize = true;
            rbCanchero.Font = new System.Drawing.Font("Segoe UI", 10F);
            rbCanchero.ForeColor = COLOR_TEXTO_OSCURO;
            rbCanchero.Location = new System.Drawing.Point(440, 107);
            rbCanchero.Name = "rbCanchero";
            rbCanchero.Size = new System.Drawing.Size(111, 23);
            rbCanchero.TabIndex = 11;
            rbCanchero.TabStop = true;
            rbCanchero.Text = "Top canchero";
            rbCanchero.UseVisualStyleBackColor = true;

            // btnBuscar
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = COLOR_ACENTO;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnBuscar.ForeColor = System.Drawing.Color.White;
            btnBuscar.Location = new System.Drawing.Point(570, 60);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new System.Drawing.Size(160, 40);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Generar reporte";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;

            // btnExportarPdf
            btnExportarPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportarPdf.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            btnExportarPdf.FlatAppearance.BorderSize = 0;
            btnExportarPdf.FlatStyle = FlatStyle.Flat;
            btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnExportarPdf.ForeColor = System.Drawing.Color.White;
            btnExportarPdf.Location = new System.Drawing.Point(570, 105);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new System.Drawing.Size(160, 35);
            btnExportarPdf.TabIndex = 6;
            btnExportarPdf.Text = "Exportar a PDF";
            btnExportarPdf.UseVisualStyleBackColor = false;
            btnExportarPdf.Click += btnExportarPdf_Click;

            // dgvReportes
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AllowUserToDeleteRows = false;
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.BackgroundColor = COLOR_FONDO_TARJETA;
            dgvReportes.BorderStyle = BorderStyle.None;
            dgvReportes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvReportes.Dock = DockStyle.Fill;
            dgvReportes.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);
            dgvReportes.Location = new System.Drawing.Point(15, 165);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.ReadOnly = true;
            dgvReportes.RowHeadersVisible = false;
            dgvReportes.RowHeadersWidth = 51;
            dgvReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReportes.Size = new System.Drawing.Size(750, 320);
            dgvReportes.TabIndex = 1;

            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelFiltros;
        private Button btnBuscar;
        private Button btnExportarPdf;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private ComboBox cmbAgrupar;
        private DataGridView dgvReportes;
        private RadioButton rbRecaudacion;
        private RadioButton rbHorarios;
        private RadioButton rbCanchero;
        private Label lblTituloFiltros;
        private Label lblDesde;
        private Label lblHasta;
        private Label lblAgrupar;
        private Label lblTipoReporte;
    }
}
