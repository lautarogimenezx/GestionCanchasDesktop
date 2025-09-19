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
            gbEdicion.Name = "gbEdicion";
            gbEdicion.Size = new Size(800, 214);
            gbEdicion.TabIndex = 1;
            gbEdicion.TabStop = false;
            gbEdicion.Text = "Alta / Edición de cancha";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Location = new Point(334, 170);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(139, 24);
            chkActivo.TabIndex = 15;
            chkActivo.Text = "Activo / Inactivo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(345, 118);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 34);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(345, 76);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(110, 34);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(345, 35);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(110, 34);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 156);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 9;
            label4.Text = "Precio / hora";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 118);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 8;
            label3.Text = "Ubicación";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 76);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 7;
            label2.Text = "Tipo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 35);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 6;
            label1.Text = "Número";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Fútbol 5", "Fútbol 7", "Fútbol 11", "Pádel", "Tenis", "Básquet", "Vóley" });
            cmbTipo.Location = new Point(139, 71);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(170, 28);
            cmbTipo.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(139, 153);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "Precio";
            txtPrecio.Size = new Size(170, 27);
            txtPrecio.TabIndex = 3;
            // 
            // txtUbicacion
            // 
            txtUbicacion.Location = new Point(139, 111);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.PlaceholderText = "Ubicación";
            txtUbicacion.Size = new Size(170, 27);
            txtUbicacion.TabIndex = 2;
            // 
            // txtNro
            // 
            txtNro.Location = new Point(139, 32);
            txtNro.Name = "txtNro";
            txtNro.PlaceholderText = "Número";
            txtNro.Size = new Size(170, 27);
            txtNro.TabIndex = 0;
            // 
            // dgvCanchas
            // 
            dgvCanchas.BackgroundColor = SystemColors.ControlLight;
            dgvCanchas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCanchas.Dock = DockStyle.Bottom;
            dgvCanchas.Location = new Point(0, 213);
            dgvCanchas.Name = "dgvCanchas";
            dgvCanchas.RowHeadersWidth = 51;
            dgvCanchas.Size = new Size(800, 308);
            dgvCanchas.TabIndex = 7;
            // 
            // CanchasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 521);
            Controls.Add(dgvCanchas);
            Controls.Add(gbEdicion);
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
