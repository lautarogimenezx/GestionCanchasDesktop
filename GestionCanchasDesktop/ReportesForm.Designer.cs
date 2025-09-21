namespace GestionCanchasDesktop
{
    partial class ReportesForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.ComboBox cmbAgrupar;
        private System.Windows.Forms.Label lblAgrupar;
        private System.Windows.Forms.RadioButton rbRecaudacion;
        private System.Windows.Forms.RadioButton rbHorarios;
        private System.Windows.Forms.RadioButton rbCanchero;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvReportes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblAgrupar = new System.Windows.Forms.Label();
            this.cmbAgrupar = new System.Windows.Forms.ComboBox();
            this.rbRecaudacion = new System.Windows.Forms.RadioButton();
            this.rbHorarios = new System.Windows.Forms.RadioButton();
            this.rbCanchero = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.groupBoxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Controls.Add(this.lblDesde);
            this.groupBoxFiltros.Controls.Add(this.dtpDesde);
            this.groupBoxFiltros.Controls.Add(this.lblHasta);
            this.groupBoxFiltros.Controls.Add(this.dtpHasta);
            this.groupBoxFiltros.Controls.Add(this.lblAgrupar);
            this.groupBoxFiltros.Controls.Add(this.cmbAgrupar);
            this.groupBoxFiltros.Controls.Add(this.rbRecaudacion);
            this.groupBoxFiltros.Controls.Add(this.rbHorarios);
            this.groupBoxFiltros.Controls.Add(this.rbCanchero);
            this.groupBoxFiltros.Controls.Add(this.btnBuscar);
            this.groupBoxFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFiltros.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Size = new System.Drawing.Size(800, 120);
            this.groupBoxFiltros.TabIndex = 0;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros de Reporte";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(10, 25);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(44, 15);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Checked = false;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(60, 20);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.ShowCheckBox = true;
            this.dtpDesde.Size = new System.Drawing.Size(120, 23);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(200, 25);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(40, 15);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Checked = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(250, 20);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowCheckBox = true;
            this.dtpHasta.Size = new System.Drawing.Size(120, 23);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblAgrupar
            // 
            this.lblAgrupar.AutoSize = true;
            this.lblAgrupar.Location = new System.Drawing.Point(390, 25);
            this.lblAgrupar.Name = "lblAgrupar";
            this.lblAgrupar.Size = new System.Drawing.Size(55, 15);
            this.lblAgrupar.TabIndex = 4;
            this.lblAgrupar.Text = "Agrupar:";
            // 
            // cmbAgrupar
            // 
            this.cmbAgrupar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgrupar.FormattingEnabled = true;
            this.cmbAgrupar.Location = new System.Drawing.Point(450, 20);
            this.cmbAgrupar.Name = "cmbAgrupar";
            this.cmbAgrupar.Size = new System.Drawing.Size(100, 23);
            this.cmbAgrupar.TabIndex = 5;
            // 
            // rbRecaudacion
            // 
            this.rbRecaudacion.AutoSize = true;
            this.rbRecaudacion.Checked = true;
            this.rbRecaudacion.Location = new System.Drawing.Point(10, 60);
            this.rbRecaudacion.Name = "rbRecaudacion";
            this.rbRecaudacion.Size = new System.Drawing.Size(92, 19);
            this.rbRecaudacion.TabIndex = 6;
            this.rbRecaudacion.TabStop = true;
            this.rbRecaudacion.Text = "Recaudación";
            this.rbRecaudacion.UseVisualStyleBackColor = true;
            // 
            // rbHorarios
            // 
            this.rbHorarios.AutoSize = true;
            this.rbHorarios.Location = new System.Drawing.Point(120, 60);
            this.rbHorarios.Name = "rbHorarios";
            this.rbHorarios.Size = new System.Drawing.Size(143, 19);
            this.rbHorarios.TabIndex = 7;
            this.rbHorarios.Text = "Horarios más usados";
            this.rbHorarios.UseVisualStyleBackColor = true;
            // 
            // rbCanchero
            // 
            this.rbCanchero.AutoSize = true;
            this.rbCanchero.Location = new System.Drawing.Point(280, 60);
            this.rbCanchero.Name = "rbCanchero";
            this.rbCanchero.Size = new System.Drawing.Size(147, 19);
            this.rbCanchero.TabIndex = 8;
            this.rbCanchero.Text = "Canchero que recaudó";
            this.rbCanchero.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(650, 40);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvReportes
            // 
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportes.Location = new System.Drawing.Point(0, 120);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.RowTemplate.Height = 25;
            this.dgvReportes.Size = new System.Drawing.Size(800, 330);
            this.dgvReportes.TabIndex = 1;
            // 
            // ReportesForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.groupBoxFiltros);
            this.Name = "ReportesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
