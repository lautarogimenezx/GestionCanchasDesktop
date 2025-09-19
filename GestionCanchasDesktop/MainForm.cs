using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    public partial class MainForm : Form
    {
        private readonly int _userId;
        private readonly string _rol;

        private Form? _formActual;

        public MainForm(int userId, string nombre, string apellido, string rol)
        {
            InitializeComponent();

            _userId = userId;
            _rol = rol;

            // Título
            this.Text = $"Gestión de Canchas - Bienvenido {nombre} ({rol})";

            // Header usuario
            lblUsuario.Text = $"{nombre} {apellido} ({rol})";

            // Permisos por rol
            bool isAdmin = _rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
            btnUsuarios.Enabled = isAdmin;
            btnReportes.Enabled = isAdmin;
            btnBackup.Enabled = isAdmin;

            // Jugadores: Admin o Canchero
            bool puedeJugadores = _rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase)
                               || _rol.Equals("Canchero", StringComparison.OrdinalIgnoreCase);
            btnJugadores.Enabled = puedeJugadores;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Si querés, podés cargar un dashboard por defecto aquí
        }

        private void CargarEnPanel(Form formHijo)
        {
            if (_formActual != null)
            {
                _formActual.Close();
                _formActual.Dispose();
            }

            _formActual = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formHijo);
            formHijo.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            CargarEnPanel(new UsuariosForm());
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            CargarEnPanel(new JugadoresForm());
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            // TODO: abrir ReservasForm
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            // TODO: abrir ReportesForm
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            // TODO: abrir BackupForm
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            // opcional
        }
    }
}
