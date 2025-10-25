namespace GestionCanchasDesktop
{
    partial class CanchasForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Definición de colores
            System.Drawing.Color COLOR_ACENTO = System.Drawing.Color.FromArgb(139, 38, 56); // RGB(139, 38, 56)
            System.Drawing.Color COLOR_FONDO_PRIMARIO = System.Drawing.Color.FromArgb(248, 248, 248);
            System.Drawing.Color COLOR_FONDO_TARJETA = System.Drawing.Color.White;
            System.Drawing.Color COLOR_TEXTO_OSCURO = System.Drawing.Color.FromArgb(30, 30, 30);
            System.Drawing.Color COLOR_TEXTO_SECUNDARIO = System.Drawing.Color.FromArgb(100, 100, 100);

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
            // CanchasForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = COLOR_FONDO_PRIMARIO;
            ClientSize = new System.Drawing.Size(780, 500);
            Controls.Add(dgvCanchas);
            Controls.Add(gbEdicion);
            Name = "CanchasForm";
            Text = "Canchas";
            Padding = new System.Windows.Forms.Padding(15); // Margen general
            // 
            // gbEdicion (Tarjeta de Edición)
            // 
            gbEdicion.BackColor = COLOR_FONDO_TARJETA;
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
            gbEdicion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            gbEdicion.ForeColor = COLOR_TEXTO_OSCURO;
            gbEdicion.Location = new System.Drawing.Point(15, 15);
            gbEdicion.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20);
            gbEdicion.Size = new System.Drawing.Size(750, 220);
            gbEdicion.TabIndex = 1;
            gbEdicion.TabStop = false;
            gbEdicion.Text = "  Alta / Edición de Cancha";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chkActivo.Location = new System.Drawing.Point(340, 35);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new System.Drawing.Size(130, 23);
            chkActivo.TabIndex = 15;
            chkActivo.Text = "Activo / Inactivo";
            chkActivo.UseVisualStyleBackColor = true;
            chkActivo.ForeColor = COLOR_TEXTO_SECUNDARIO;
            // 
            // Botones de Acción
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.BackColor = System.Drawing.Color.White;
            btnCancelar.FlatAppearance.BorderColor = COLOR_TEXTO_SECUNDARIO;
            btnCancelar.FlatAppearance.BorderSize = 1;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = COLOR_TEXTO_OSCURO;
            btnCancelar.Location = new System.Drawing.Point(570, 145);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(160, 40);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLimpiar.BackColor = System.Drawing.Color.White;
            btnLimpiar.FlatAppearance.BorderColor = COLOR_TEXTO_SECUNDARIO;
            btnLimpiar.FlatAppearance.BorderSize = 1;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = COLOR_TEXTO_OSCURO;
            btnLimpiar.Location = new System.Drawing.Point(570, 90);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new System.Drawing.Size(160, 40);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.BackColor = COLOR_ACENTO;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(570, 35);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(160, 40);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // Etiquetas (Labels)
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(20, 155);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(95, 19);
            label4.TabIndex = 9;
            label4.Text = "Precio / Hora";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            label4.ForeColor = COLOR_TEXTO_OSCURO;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(20, 125);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 19);
            label3.TabIndex = 8;
            label3.Text = "Ubicación";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            label3.ForeColor = COLOR_TEXTO_OSCURO;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(20, 95);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(35, 19);
            label2.TabIndex = 7;
            label2.Text = "Tipo";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            label2.ForeColor = COLOR_TEXTO_OSCURO;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(20, 65);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 19);
            label1.TabIndex = 6;
            label1.Text = "Número";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            label1.ForeColor = COLOR_TEXTO_OSCURO;
            // 
            // Campos de Texto (TextBox, ComboBox)
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Fútbol 5", "Fútbol 7", "Fútbol 11", "Pádel", "Tenis", "Básquet", "Vóley" });
            cmbTipo.Location = new System.Drawing.Point(130, 92);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new System.Drawing.Size(190, 25);
            cmbTipo.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.BorderStyle = BorderStyle.FixedSingle;
            txtPrecio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtPrecio.Location = new System.Drawing.Point(130, 152);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "$ 0.00";
            txtPrecio.Size = new System.Drawing.Size(190, 25);
            txtPrecio.TabIndex = 3;
            txtPrecio.BackColor = System.Drawing.Color.White;
            // 
            // txtUbicacion
            // 
            txtUbicacion.BorderStyle = BorderStyle.FixedSingle;
            txtUbicacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtUbicacion.Location = new System.Drawing.Point(130, 122);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.PlaceholderText = "Ubicación";
            txtUbicacion.Size = new System.Drawing.Size(190, 25);
            txtUbicacion.TabIndex = 2;
            txtUbicacion.BackColor = System.Drawing.Color.White;
            // 
            // txtNro
            // 
            txtNro.BorderStyle = BorderStyle.FixedSingle;
            txtNro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtNro.Location = new System.Drawing.Point(130, 62);
            txtNro.Name = "txtNro";
            txtNro.PlaceholderText = "Número";
            txtNro.Size = new System.Drawing.Size(190, 25);
            txtNro.TabIndex = 0;
            txtNro.BackColor = System.Drawing.Color.White;
            // 
            // dgvCanchas (Tabla de Datos)
            // 
            dgvCanchas.AllowUserToAddRows = false;
            dgvCanchas.AllowUserToDeleteRows = false;
            dgvCanchas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCanchas.BackgroundColor = COLOR_FONDO_TARJETA;
            dgvCanchas.BorderStyle = BorderStyle.None;
            dgvCanchas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvCanchas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            dgvCanchas.ColumnHeadersDefaultCellStyle.ForeColor = COLOR_TEXTO_OSCURO;
            dgvCanchas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dgvCanchas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCanchas.Dock = DockStyle.Fill;
            dgvCanchas.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);
            dgvCanchas.Location = new System.Drawing.Point(15, 235);
            dgvCanchas.Name = "dgvCanchas";
            dgvCanchas.ReadOnly = true;
            dgvCanchas.RowHeadersVisible = false;
            dgvCanchas.RowHeadersWidth = 51;
            dgvCanchas.RowTemplate.DefaultCellStyle.BackColor = COLOR_FONDO_TARJETA;
            dgvCanchas.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            dgvCanchas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCanchas.Size = new System.Drawing.Size(750, 250);
            dgvCanchas.TabIndex = 7;

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