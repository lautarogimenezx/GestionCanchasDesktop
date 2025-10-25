using System;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    internal static class Program
    {
        // ← NUEVO: aquí guardamos el usuario logueado
        public static UserInfo? UsuarioActual { get; set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
