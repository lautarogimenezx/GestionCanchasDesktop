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
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btnUltimos7 = new System.Windows.Forms.Button();
            this.btnEsteMes = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbAgrupar = new System.Windows.Forms.ComboBox();
            this.rbRecaudacion = new System.Windows.Forms.RadioButton();
            this.rbHorarios = new System.Windows.Forms.RadioButton();
            this.rbCanchero = new System.Windows.Forms.RadioButton();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.groupBoxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Controls.Add(this.btnHoy);
            this.groupBoxFiltros.Controls.Add(this.btnUltimos7);
            this.groupBoxFiltros.Controls.Add(this.btnEsteMes);
            this.groupBoxFiltros.Controls.Add(this.btnBuscar);
            this.groupBoxFiltros.Controls.Add(this.dtpDesde);
            this.groupBoxFiltros.Controls.Add(this.dtpHasta);
            this.groupBoxFiltros.Controls.Add(this.cmbAgrupar);
            this.groupBoxFiltros.Controls.Add(this.rbRecaudacion);
            this.groupBoxFiltros.Controls.Add(this.rbHorarios);
            this.groupBoxFiltros.Controls.Add(this.rbCanchero);
            this.groupBoxFiltros.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Size = new System.Drawing.Size(760, 120);
            this.groupBoxFiltros.TabIndex = 0;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros";
            // 
            // btnHoy
            // 
            this.btnHoy.Location = new System.Drawing.Point(500, 20);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(75, 25);
            this.btnHoy.TabIndex = 6;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = true;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // btnUltimos7
            // 
            this.btnUltimos7.Location = new System.Drawing.Point(500, 50);
            this.btnUltimos7.Name = "btnUltimos7";
            this.btnUltimos7.Size = new System.Drawing.Size(75, 25);
            this.btnUltimos7.TabIndex = 7;
            this.btnUltimos7.Text = "7 días";
            this.btnUltimos7.UseVisualStyleBackColor = true;
            this.btnUltimos7.Click += new System.EventHandler(this.btnUltimos7_Click);
            // 
            // btnEsteMes
            // 
            this.btnEsteMes.Location = new System.Drawing.Point(500, 80);
            this.btnEsteMes.Name = "btnEsteMes";
            this.btnEsteMes.Size = new System.Drawing.Size(75, 25);
            this.btnEsteMes.TabIndex = 8;
            this.btnEsteMes.Text = "Este mes";
            this.btnEsteMes.UseVisualStyleBackColor = true;
            this.btnEsteMes.Click += new System.EventHandler(this.btnEsteMes_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(600, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 30);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Generar reporte";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(20, 30);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.ShowCheckBox = true;
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(240, 30);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowCheckBox = true;
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 2;
            // 
            // cmbAgrupar
            // 
            this.cmbAgrupar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgrupar.FormattingEnabled = true;
            this.cmbAgrupar.Items.AddRange(new object[] {
            "DIA",
            "MES",
            "AÑO"});
            this.cmbAgrupar.Location = new System.Drawing.Point(20, 70);
            this.cmbAgrupar.Name = "cmbAgrupar";
            this.cmbAgrupar.Size = new System.Drawing.Size(121, 21);
            this.cmbAgrupar.TabIndex = 3;
            // 
            // rbRecaudacion
            // 
            this.rbRecaudacion.AutoSize = true;
            this.rbRecaudacion.Location = new System.Drawing.Point(160, 72);
            this.rbRecaudacion.Name = "rbRecaudacion";
            this.rbRecaudacion.Size = new System.Drawing.Size(89, 17);
            this.rbRecaudacion.TabIndex = 9;
            this.rbRecaudacion.TabStop = true;
            this.rbRecaudacion.Text = "Recaudación";
            this.rbRecaudacion.UseVisualStyleBackColor = true;
            // 
            // rbHorarios
            // 
            this.rbHorarios.AutoSize = true;
            this.rbHorarios.Location = new System.Drawing.Point(260, 72);
            this.rbHorarios.Name = "rbHorarios";
            this.rbHorarios.Size = new System.Drawing.Size(133, 17);
            this.rbHorarios.TabIndex = 10;
            this.rbHorarios.TabStop = true;
            this.rbHorarios.Text = "Horarios más pedidos";
            this.rbHorarios.UseVisualStyleBackColor = true;
            // 
            // rbCanchero
            // 
            this.rbCanchero.AutoSize = true;
            this.rbCanchero.Location = new System.Drawing.Point(400, 72);
            this.rbCanchero.Name = "rbCanchero";
            this.rbCanchero.Size = new System.Drawing.Size(88, 17);
            this.rbCanchero.TabIndex = 11;
            this.rbCanchero.TabStop = true;
            this.rbCanchero.Text = "Top canchero";
            this.rbCanchero.UseVisualStyleBackColor = true;
            // 
            // dgvReportes
            // 
            this.dgvReportes.AllowUserToAddRows = false;
            this.dgvReportes.AllowUserToDeleteRows = false;
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(12, 150);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.ReadOnly = true;
            this.dgvReportes.Size = new System.Drawing.Size(760, 300);
            this.dgvReportes.TabIndex = 1;
            // 
            // ReportesForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.groupBoxFiltros);
            this.Name = "ReportesForm";
            this.Text = "Reportes";
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.ComboBox cmbAgrupar;
        private System.Windows.Forms.DataGridView dgvReportes;
        private System.Windows.Forms.RadioButton rbRecaudacion;
        private System.Windows.Forms.RadioButton rbHorarios;
        private System.Windows.Forms.RadioButton rbCanchero;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnUltimos7;
        private System.Windows.Forms.Button btnEsteMes;
    }
}
