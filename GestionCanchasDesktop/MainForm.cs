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

            // Título y encabezado
            this.Text = $"Gestión de Canchas - Bienvenido {nombre} ({rol})";
            lblUsuario.Text = $"{nombre} {apellido} ({rol})";

            // ===== Permisos por rol =====
            bool isAdmin = _rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
            bool isCanchero = _rol.Equals("Canchero", StringComparison.OrdinalIgnoreCase);
            bool isContador = _rol.Equals("Contador", StringComparison.OrdinalIgnoreCase);

            // Admin: todo habilitado
            // Canchero: Jugadores + Reservas
            // Contador: Reportes
            btnUsuarios.Enabled = isAdmin;
            btnCanchas.Enabled = isAdmin;
            btnBackup.Enabled = isAdmin;

            btnJugadores.Enabled = isAdmin || isCanchero;
            btnReservas.Enabled = isAdmin || isCanchero;

            btnReportes.Enabled = isAdmin || isContador;

         
            btnUsuarios.TabStop = btnUsuarios.Enabled;
            btnCanchas.TabStop = btnCanchas.Enabled;
            btnBackup.TabStop = btnBackup.Enabled;
            btnJugadores.TabStop = btnJugadores.Enabled;
            btnReservas.TabStop = btnReservas.Enabled;
            btnReportes.TabStop = btnReportes.Enabled;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CargarEnPanel(Form formHijo)
        {
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
            if (!btnUsuarios.Enabled) return; 
            CargarEnPanel(new UsuariosForm());
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            if (!btnJugadores.Enabled) return;
            CargarEnPanel(new JugadoresForm());
        }

        private void btnCanchas_Click(object sender, EventArgs e)
        {
            if (!btnCanchas.Enabled) return;
            CargarEnPanel(new CanchasForm());
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            if (!btnReservas.Enabled) return;

            CargarEnPanel(new ReservasForm(_userId));
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (!btnReportes.Enabled) return;
            CargarEnPanel(new ReportesForm());

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (!btnBackup.Enabled) return;
            CargarEnPanel(new BackupForm());

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
