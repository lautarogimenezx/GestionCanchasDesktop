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

        private void InitializeComponent()
        {
            btnBackup = new Button();
            btnRestore = new Button();
            SuspendLayout();
            // 
            // btnBackup
            // 
            btnBackup.Location = new Point(260, 140);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(200, 40);
            btnBackup.TabIndex = 0;
            btnBackup.Text = "Hacer Backup";
            btnBackup.UseVisualStyleBackColor = true;
            // 
            // btnRestore
            // 
            btnRestore.Location = new Point(260, 200);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(200, 40);
            btnRestore.TabIndex = 1;
            btnRestore.Text = "Restaurar Backup";
            btnRestore.UseVisualStyleBackColor = true;
            btnRestore.Click += btnRestore_Click_1;
            // 
            // BackupForm
            // 
            ClientSize = new Size(700, 391);
            Controls.Add(btnRestore);
            Controls.Add(btnBackup);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "BackupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Backup y Restore";
            ResumeLayout(false);
        }
    }
}
