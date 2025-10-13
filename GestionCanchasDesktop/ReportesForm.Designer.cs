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
            groupBoxFiltros = new GroupBox();
            btnBuscar = new Button();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            cmbAgrupar = new ComboBox();
            rbRecaudacion = new RadioButton();
            rbHorarios = new RadioButton();
            rbCanchero = new RadioButton();
            dgvReportes = new DataGridView();
            groupBoxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            SuspendLayout();
            // 
            // groupBoxFiltros
            // 
            groupBoxFiltros.Controls.Add(btnBuscar);
            groupBoxFiltros.Controls.Add(dtpDesde);
            groupBoxFiltros.Controls.Add(dtpHasta);
            groupBoxFiltros.Controls.Add(cmbAgrupar);
            groupBoxFiltros.Controls.Add(rbRecaudacion);
            groupBoxFiltros.Controls.Add(rbHorarios);
            groupBoxFiltros.Controls.Add(rbCanchero);
            groupBoxFiltros.Location = new Point(12, 12);
            groupBoxFiltros.Name = "groupBoxFiltros";
            groupBoxFiltros.Size = new Size(760, 120);
            groupBoxFiltros.TabIndex = 0;
            groupBoxFiltros.TabStop = false;
            groupBoxFiltros.Text = "Filtros";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(600, 20);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(120, 30);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Generar reporte";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(20, 30);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.ShowCheckBox = true;
            dtpDesde.Size = new Size(200, 23);
            dtpDesde.TabIndex = 1;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(240, 30);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.ShowCheckBox = true;
            dtpHasta.Size = new Size(200, 23);
            dtpHasta.TabIndex = 2;
            // 
            // cmbAgrupar
            // 
            cmbAgrupar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAgrupar.FormattingEnabled = true;
            cmbAgrupar.Items.AddRange(new object[] { "DIA", "SEMANA", "MES" });
            cmbAgrupar.Location = new Point(463, 30);
            cmbAgrupar.Name = "cmbAgrupar";
            cmbAgrupar.Size = new Size(121, 23);
            cmbAgrupar.TabIndex = 3;
            // 
            // rbRecaudacion
            // 
            rbRecaudacion.AutoSize = true;
            rbRecaudacion.Location = new Point(34, 80);
            rbRecaudacion.Name = "rbRecaudacion";
            rbRecaudacion.Size = new Size(93, 19);
            rbRecaudacion.TabIndex = 9;
            rbRecaudacion.TabStop = true;
            rbRecaudacion.Text = "Recaudación";
            rbRecaudacion.UseVisualStyleBackColor = true;
            // 
            // rbHorarios
            // 
            rbHorarios.AutoSize = true;
            rbHorarios.Location = new Point(134, 80);
            rbHorarios.Name = "rbHorarios";
            rbHorarios.Size = new Size(140, 19);
            rbHorarios.TabIndex = 10;
            rbHorarios.TabStop = true;
            rbHorarios.Text = "Horarios más pedidos";
            rbHorarios.UseVisualStyleBackColor = true;
            // 
            // rbCanchero
            // 
            rbCanchero.AutoSize = true;
            rbCanchero.Location = new Point(274, 80);
            rbCanchero.Name = "rbCanchero";
            rbCanchero.Size = new Size(97, 19);
            rbCanchero.TabIndex = 11;
            rbCanchero.TabStop = true;
            rbCanchero.Text = "Top canchero";
            rbCanchero.UseVisualStyleBackColor = true;
            // 
            // dgvReportes
            // 
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AllowUserToDeleteRows = false;
            dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Location = new Point(12, 150);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.ReadOnly = true;
            dgvReportes.Size = new Size(760, 300);
            dgvReportes.TabIndex = 1;
            // 
            // ReportesForm
            // 
            ClientSize = new Size(784, 461);
            Controls.Add(dgvReportes);
            Controls.Add(groupBoxFiltros);
            Name = "ReportesForm";
            Text = "Reportes";
            groupBoxFiltros.ResumeLayout(false);
            groupBoxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);

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
    }
}