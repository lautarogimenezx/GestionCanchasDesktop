using System;
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

            // Admin o Canchero pueden Jugadores y Canchas
            bool puedeOperar = _rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase)
                            || _rol.Equals("Canchero", StringComparison.OrdinalIgnoreCase);
            btnJugadores.Enabled = puedeOperar;
            btnCanchas.Enabled = puedeOperar;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Podés cargar un dashboard por defecto acá si querés
            // CargarEnPanel(new DashboardForm());
        }

        private void CargarEnPanel(Form formHijo)
        {
            // Cierra el form anterior si había
            if (_formActual != null)
            {
                _formActual.Close();
                _formActual.Dispose();
                _formActual = null;
            }

            _formActual = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formHijo);
            formHijo.Show();
            formHijo.BringToFront();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            CargarEnPanel(new UsuariosForm());
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            CargarEnPanel(new JugadoresForm());
        }

        private void btnCanchas_Click(object sender, EventArgs e)
        {
            CargarEnPanel(new CanchasForm());
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            // Cuando tengas el form de Reservas, descomentá:
            // CargarEnPanel(new ReservasForm());
            MessageBox.Show("La vista de Reservas aún no está implementada.");
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            // TODO: CargarEnPanel(new ReportesForm());
            MessageBox.Show("La vista de Reportes aún no está implementada.");
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            // TODO: CargarEnPanel(new BackupForm());
            MessageBox.Show("La vista de Backup aún no está implementada.");
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
