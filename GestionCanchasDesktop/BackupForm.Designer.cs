namespace GestionCanchasDesktop
{
    partial class BackupForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label lblTitulo;

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
            System.Drawing.Color COLOR_ACENTO = System.Drawing.Color.FromArgb(139, 38, 56);
            System.Drawing.Color COLOR_FONDO_PRIMARIO = System.Drawing.Color.FromArgb(248, 248, 248);
            System.Drawing.Color COLOR_TEXTO_OSCURO = System.Drawing.Color.FromArgb(30, 30, 30);

            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();

            this.SuspendLayout();
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = COLOR_FONDO_PRIMARIO;
            this.ClientSize = new System.Drawing.Size(780, 500);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BackupForm";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.Text = "Backup y Restore";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = COLOR_TEXTO_OSCURO;
            this.lblTitulo.Location = new System.Drawing.Point(50, 50);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(304, 30);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Copia de Seguridad (Backup)";
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBackup.BackColor = COLOR_ACENTO;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(240, 150);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(300, 50);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "Realizar Copia de Seguridad";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(240, 230);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(300, 50);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "Restaurar Copia de Seguridad";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.BtnRestore_Click);
            // 
            // BackupForm
            // 
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
