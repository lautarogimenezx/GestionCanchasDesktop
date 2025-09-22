using System.Drawing;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    partial class CanchasForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer? components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            gbEdicion = new GroupBox();
            chkActivo = new CheckBox();
            btnCancelar = new Button();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbTipo = new ComboBox();
            txtPrecio = new TextBox();
            txtUbicacion = new TextBox();
            txtNro = new TextBox();
            dgvCanchas = new DataGridView();
            gbEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCanchas).BeginInit();
            SuspendLayout();
            // 
            // gbEdicion
            // 
            gbEdicion.Controls.Add(chkActivo);
            gbEdicion.Controls.Add(btnCancelar);
            gbEdicion.Controls.Add(btnLimpiar);
            gbEdicion.Controls.Add(btnGuardar);
            gbEdicion.Controls.Add(label4);
            gbEdicion.Controls.Add(label3);
            gbEdicion.Controls.Add(label2);
            gbEdicion.Controls.Add(label1);
            gbEdicion.Controls.Add(cmbTipo);
            gbEdicion.Controls.Add(txtPrecio);
            gbEdicion.Controls.Add(txtUbicacion);
            gbEdicion.Controls.Add(txtNro);
            gbEdicion.Dock = DockStyle.Top;
            gbEdicion.Location = new Point(0, 0);
            gbEdicion.Margin = new Padding(3, 2, 3, 2);
            gbEdicion.Name = "gbEdicion";
            gbEdicion.Padding = new Padding(3, 2, 3, 2);
            gbEdicion.Size = new Size(700, 160);
            gbEdicion.TabIndex = 1;
            gbEdicion.TabStop = false;
            gbEdicion.Text = "Alta / Edición de cancha";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Location = new Point(292, 128);
            chkActivo.Margin = new Padding(3, 2, 3, 2);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(113, 19);
            chkActivo.TabIndex = 15;
            chkActivo.Text = "Activo / Inactivo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(302, 88);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 26);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnLimpiar
            // 
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(302, 57);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(96, 26);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(302, 26);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(96, 26);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 117);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 9;
            label4.Text = "Precio / hora";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 88);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 8;
            label3.Text = "Ubicación";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 57);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 7;
            label2.Text = "Tipo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 26);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 6;
            label1.Text = "Número";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Fútbol 5", "Fútbol 7", "Fútbol 11", "Pádel", "Tenis", "Básquet", "Vóley" });
            cmbTipo.Location = new Point(122, 53);
            cmbTipo.Margin = new Padding(3, 2, 3, 2);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(149, 23);
            cmbTipo.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(122, 115);
            txtPrecio.Margin = new Padding(3, 2, 3, 2);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "Precio";
            txtPrecio.Size = new Size(149, 23);
            txtPrecio.TabIndex = 3;
            // 
            // txtUbicacion
            // 
            txtUbicacion.Location = new Point(122, 83);
            txtUbicacion.Margin = new Padding(3, 2, 3, 2);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.PlaceholderText = "Ubicación";
            txtUbicacion.Size = new Size(149, 23);
            txtUbicacion.TabIndex = 2;
            // 
            // txtNro
            // 
            txtNro.Location = new Point(122, 24);
            txtNro.Margin = new Padding(3, 2, 3, 2);
            txtNro.Name = "txtNro";
            txtNro.PlaceholderText = "Número";
            txtNro.Size = new Size(149, 23);
            txtNro.TabIndex = 0;
            // 
            // dgvCanchas
            // 
            dgvCanchas.BackgroundColor = SystemColors.ControlLight;
            dgvCanchas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCanchas.Dock = DockStyle.Bottom;
            dgvCanchas.Location = new Point(0, 160);
            dgvCanchas.Margin = new Padding(3, 2, 3, 2);
            dgvCanchas.Name = "dgvCanchas";
            dgvCanchas.RowHeadersWidth = 51;
            dgvCanchas.Size = new Size(700, 231);
            dgvCanchas.TabIndex = 7;
            // 
            // CanchasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 391);
            Controls.Add(dgvCanchas);
            Controls.Add(gbEdicion);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CanchasForm";
            Text = "Canchas";
            gbEdicion.ResumeLayout(false);
            gbEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCanchas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gbEdicion;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.TextBox txtNro;
        private System.Windows.Forms.DataGridView dgvCanchas;
    }
}
