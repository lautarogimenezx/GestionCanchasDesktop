namespace GestionCanchasDesktop
{
    partial class BackupForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;

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
            // Definición de colores
            System.Drawing.Color COLOR_ACENTO = System.Drawing.Color.FromArgb(139, 38, 56); // RGB(139, 38, 56)
            System.Drawing.Color COLOR_FONDO_PRIMARIO = System.Drawing.Color.FromArgb(248, 248, 248);
            System.Drawing.Color COLOR_TEXTO_OSCURO = System.Drawing.Color.FromArgb(30, 30, 30);

            btnBackup = new Button();
            btnRestore = new Button();
            lblTitulo = new Label(); // Label para el título
            SuspendLayout();
            // 
            // BackupForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = COLOR_FONDO_PRIMARIO;
            ClientSize = new System.Drawing.Size(780, 500); // Tamaño consistente
            Controls.Add(lblTitulo);
            Controls.Add(btnRestore);
            Controls.Add(btnBackup);
            FormBorderStyle = FormBorderStyle.None; // Sin borde para integrar en MainForm
            Name = "BackupForm";
            Padding = new System.Windows.Forms.Padding(50); // Buen margen
            Text = "Backup y Restore";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = COLOR_TEXTO_OSCURO;
            lblTitulo.Location = new System.Drawing.Point(50, 50); // Posición del título
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(262, 30);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Copia de Seguridad (Backup)";
            // 
            // btnBackup (Botón Principal)
            // 
            btnBackup.Anchor = AnchorStyles.None; // Centrado
            btnBackup.BackColor = COLOR_ACENTO;
            btnBackup.FlatAppearance.BorderSize = 0;
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnBackup.ForeColor = System.Drawing.Color.White;
            btnBackup.Location = new System.Drawing.Point(240, 150); // Posición centrada
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new System.Drawing.Size(300, 50); // Tamaño aumentado
            btnBackup.TabIndex = 0;
            btnBackup.Text = "Realizar Copia de Seguridad";
            btnBackup.UseVisualStyleBackColor = false;
            // No agregamos el evento Click aquí, debe estar en BackupForm.cs
            // 
            // btnRestore (Botón Secundario - pero importante)
            // 
            btnRestore.Anchor = AnchorStyles.None; // Centrado
            btnRestore.BackColor = System.Drawing.Color.FromArgb(80, 80, 80); // Un gris oscuro para diferenciar
            btnRestore.FlatAppearance.BorderSize = 0;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnRestore.ForeColor = System.Drawing.Color.White;
            btnRestore.Location = new System.Drawing.Point(240, 230); // Debajo del otro botón
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new System.Drawing.Size(300, 50); // Tamaño aumentado
            btnRestore.TabIndex = 1;
            btnRestore.Text = "Restaurar Copia de Seguridad";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += btnRestore_Click_1;

            ResumeLayout(false);
            PerformLayout(); // Para que el AutoSize del Label funcione bien
        }

        #endregion

        private Label lblTitulo; // Declaración del Label añadido
    }
}