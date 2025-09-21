using System;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    public partial class BackupForm : Form
    {
        public BackupForm()
        {
            InitializeComponent();
            btnBackup.Click += BtnBackup_Click;
            btnRestore.Click += BtnRestore_Click;
        }

        private void BtnBackup_Click(object? sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "SQL Server Backup (*.bak)|*.bak",
                Title = "Guardar copia de seguridad",
                FileName = $"CanchaDb_{DateTime.Now:yyyyMMdd_HHmm}.bak"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BackupService.HacerBackup(sfd.FileName);
                    MessageBox.Show("Backup realizado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar backup: " + ex.Message);
                }
            }
        }

        private void BtnRestore_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "SQL Server Backup (*.bak)|*.bak",
                Title = "Seleccionar archivo de respaldo"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (MessageBox.Show("¿Seguro que deseas restaurar este backup? Se perderán los datos actuales.",
                        "Confirmar restauración",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        BackupService.RestaurarBackup(ofd.FileName);
                        MessageBox.Show("Base de datos restaurada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al restaurar backup: " + ex.Message);
                }
            }
        }
    }
}
