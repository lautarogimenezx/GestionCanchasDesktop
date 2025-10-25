using System;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    public partial class BackupForm : Form
    {
        public BackupForm()
        {
            InitializeComponent();
          
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

                    var u = Program.UsuarioActual;
                    BackupService.RegistrarAuditoria(
                        accion: "BACKUP",
                        archivo: sfd.FileName,
                        usuario1Id: u?.Id ?? 0,
                        usuario1Nombre: u is null ? "(desconocido)" : $"{u.Nombre} {u.Apellido} ({u.Rol})",
                        usuario2Id: null,
                        usuario2Nombre: null,
                        detalle: "Backup manual desde la aplicación");

                    MessageBox.Show("Backup realizado con éxito", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar backup: " + ex.Message);
                }
            }
        }

        private void BtnRestore_Click(object? sender, EventArgs e)
        {
            if (!SolicitarCredencial("Autenticá Administrador", "Administrador", out var admin)) return;
            if (!SolicitarCredencial("Autenticá Contador", "Contador", out var contador)) return;

            if (admin.Id == contador.Id)
            {
                MessageBox.Show("Los dos aprobadores deben ser usuarios distintos.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                    "Vas a RESTAURAR la base. Se perderán cambios no incluidos en el backup.\n\n¿Deseás continuar?",
                    "Confirmar restauración",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            using var ofd = new OpenFileDialog
            {
                Filter = "SQL Server Backup (*.bak)|*.bak",
                Title = "Seleccionar archivo de respaldo"
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                BackupService.RestaurarBackupSeguro(ofd.FileName);

                BackupService.RegistrarAuditoria(
                    accion: "RESTORE",
                    archivo: ofd.FileName,
                    usuario1Id: admin.Id,
                    usuario1Nombre: $"{admin.Nombre} {admin.Apellido} ({admin.Rol})",
                    usuario2Id: contador.Id,
                    usuario2Nombre: $"{contador.Nombre} {contador.Apellido} ({contador.Rol})",
                    detalle: "Restauración con doble autorización");

                MessageBox.Show("Base de datos restaurada con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar backup: " + ex.Message);
            }
        }

        private bool SolicitarCredencial(string titulo, string rolRequerido, out UserInfo user)
        {
            user = default;

            using var dlg = new AuthPromptForm(titulo);
            if (dlg.ShowDialog(this) != DialogResult.OK) return false;

            if (!AuthService.TryLogin(dlg.Email, dlg.Password, out var u) || u is null)
            {
                MessageBox.Show("Credenciales inválidas.");
                return false;
            }

            if (!string.Equals(u.Rol, rolRequerido, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Se requiere un usuario con rol '{rolRequerido}'.\nUsuario autenticado: {u.Rol}");
                return false;
            }

            user = u; 
            return true;
        }
    }
}
