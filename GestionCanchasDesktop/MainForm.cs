using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // Necesario para List<Button>

namespace GestionCanchasDesktop
{
    public partial class MainForm : Form
    {
        // --- TEMA OSCURO (Con nuevos colores para deshabilitado) ---
        private readonly Color COLOR_ACENTO_OSCURO = Color.FromArgb(139, 38, 56);
        private readonly Color COLOR_FONDO_PRIMARIO_OSCURO = Color.FromArgb(248, 248, 248);
        private readonly Color COLOR_FONDO_SECUNDARIO_OSCURO = Color.FromArgb(40, 40, 40); // Fondo menú/header
        private readonly Color COLOR_TEXTO_CLARO_OSCURO = Color.White;
        // NUEVOS COLORES PARA DESHABILITADO EN MODO OSCURO
        private readonly Color COLOR_BOTON_DESHABILITADO_OSCURO_FONDO = Color.FromArgb(30, 30, 30); // Más oscuro que el fondo
        private readonly Color COLOR_TEXTO_DESHABILITADO_OSCURO = Color.FromArgb(100, 100, 100); // Texto muy apagado
        private readonly Color COLOR_MENU_HOVER_FONDO_OSCURO = Color.FromArgb(60, 60, 60);

        // --- Variables de Estado ---
        private readonly int _userId;
        private readonly string _rol;
        private Form? _formActual;
        private Button? _botonActivo = null;

        public MainForm(int userId, string nombre, string apellido, string rol)
        {
            InitializeComponent();

            _userId = userId;
            _rol = rol;

            // Título y encabezado inicial
            this.Text = $"Gestión de Canchas - Bienvenido {nombre} ({rol})";
            lblUsuario.Text = $"{nombre} {apellido} ({rol})";

            // Aplicar estilos iniciales y eventos (siempre será modo oscuro)
            AplicarTemaOscuro();

            // ===== Permisos por rol =====
            bool isAdmin = _rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
            bool isCanchero = _rol.Equals("Canchero", StringComparison.OrdinalIgnoreCase);
            bool isContador = _rol.Equals("Contador", StringComparison.OrdinalIgnoreCase);

            // Habilitar/Deshabilitar botones según rol
            btnUsuarios.Enabled = isAdmin;
            btnCanchas.Enabled = isAdmin;
            btnBackup.Enabled = isAdmin;
            btnJugadores.Enabled = isAdmin || isCanchero;
            btnReservas.Enabled = isAdmin || isCanchero;
            btnReportes.Enabled = isAdmin || isContador;

            // Aplicar el nuevo estilo visual a los botones deshabilitados
            ActualizarEstiloBotonesPorPermiso();

            // Opcional: Cargar vista inicial
            // CargarEnPanel(new ReservasForm(_userId)); 
            // MarcarBotonActivo(btnReservas); 
        }

        // 
        // MÉTODO PARA APLICAR EL TEMA OSCURO
        // 
        private void AplicarTemaOscuro()
        {
            // Aplicar colores a paneles principales
            this.BackColor = COLOR_FONDO_PRIMARIO_OSCURO; // Fondo contenido
            panelTop.BackColor = COLOR_FONDO_SECUNDARIO_OSCURO;
            panel1.BackColor = COLOR_FONDO_SECUNDARIO_OSCURO; // <-- CORREGIDO: Usar panel1
            panelContenido.BackColor = COLOR_FONDO_PRIMARIO_OSCURO;

            // Aplicar colores a elementos del panel superior
            label1.ForeColor = COLOR_TEXTO_CLARO_OSCURO;
            lblUsuario.ForeColor = COLOR_TEXTO_CLARO_OSCURO;
            btnLogout.ForeColor = COLOR_TEXTO_CLARO_OSCURO;
            btnLogout.FlatAppearance.BorderColor = COLOR_ACENTO_OSCURO;

            // Estilos base de botones 
            List<Button> botonesMenu = new List<Button>
            {
                btnUsuarios, btnJugadores, btnCanchas, btnReservas,
                btnReportes, btnBackup, btnSalir
            };

            foreach (Button btn in botonesMenu)
            {
                btn.MouseEnter -= BotonMenu_MouseEnter;
                btn.MouseLeave -= BotonMenu_MouseLeave;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.UseVisualStyleBackColor = false;
                if (btn == btnSalir)
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                else
                    btn.Font = new Font("Segoe UI", 10F);

                if (btn.Enabled)
                {
                    btn.MouseEnter += BotonMenu_MouseEnter;
                    btn.MouseLeave += BotonMenu_MouseLeave;
                }
            }
        }

        // 
        // MÉTODO ACTUALIZADO PARA ESTILIZAR BOTONES DESHABILITADOS EN MODO OSCURO
        // 
        private void ActualizarEstiloBotonesPorPermiso()
        {
            List<Button> botonesMenu = new List<Button>
            {
                btnUsuarios, btnJugadores, btnCanchas, btnReservas,
                btnReportes, btnBackup
            };

            foreach (Button btn in botonesMenu)
            {
                btn.MouseEnter -= BotonMenu_MouseEnter;
                btn.MouseLeave -= BotonMenu_MouseLeave;

                if (!btn.Enabled)
                {
                    btn.BackColor = COLOR_BOTON_DESHABILITADO_OSCURO_FONDO;
                    btn.ForeColor = COLOR_TEXTO_DESHABILITADO_OSCURO;
                    btn.Cursor = Cursors.Default;
                }
                else
                {
                    btn.BackColor = COLOR_FONDO_SECUNDARIO_OSCURO;
                    btn.ForeColor = COLOR_TEXTO_CLARO_OSCURO;
                    btn.Cursor = Cursors.Hand;
                    btn.MouseEnter += BotonMenu_MouseEnter;
                    btn.MouseLeave += BotonMenu_MouseLeave;
                }
            }

            // Estilo especial para Salir 
            btnSalir.BackColor = COLOR_FONDO_SECUNDARIO_OSCURO;
            btnSalir.ForeColor = COLOR_TEXTO_CLARO_OSCURO;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.MouseEnter -= BotonMenu_MouseEnter;
            btnSalir.MouseEnter += BotonMenu_MouseEnter;
            btnSalir.MouseLeave -= BotonMenu_MouseLeave;
            btnSalir.MouseLeave += BotonMenu_MouseLeave;

            // Reaplica el estilo del botón activo 
            if (_botonActivo != null && _botonActivo.Enabled)
            {
                _botonActivo.BackColor = COLOR_ACENTO_OSCURO;
                _botonActivo.ForeColor = Color.White;
                _botonActivo.MouseEnter -= BotonMenu_MouseEnter;
                _botonActivo.MouseEnter += BotonMenu_MouseEnter;
                _botonActivo.MouseLeave -= BotonMenu_MouseLeave;
                _botonActivo.MouseLeave += BotonMenu_MouseLeave;
            }
        }

        // --- Eventos Hover (Para Tema Oscuro) ---
        private void BotonMenu_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Enabled && btn != _botonActivo)
            {
                btn.BackColor = COLOR_MENU_HOVER_FONDO_OSCURO;
            }
        }

        private void BotonMenu_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Enabled && btn != _botonActivo)
            {
                btn.BackColor = COLOR_FONDO_SECUNDARIO_OSCURO;
            }
        }

        // --- Lógica para marcar el botón activo (Para Tema Oscuro) ---
        private void MarcarBotonActivo(Button? botonSeleccionado)
        {
            _botonActivo = botonSeleccionado;
            ActualizarEstiloBotonesPorPermiso();

            if (_botonActivo != null && _botonActivo.Enabled)
            {
                _botonActivo.BackColor = COLOR_ACENTO_OSCURO;
                _botonActivo.ForeColor = Color.White;
            }
        }

        // --- Carga de Formularios ---
        private void CargarEnPanel(Form formHijo)
        {
            _formActual?.Close();
            _formActual = formHijo;

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            formHijo.BackColor = COLOR_FONDO_PRIMARIO_OSCURO;

            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formHijo);
            formHijo.Show();
        }

        // --- Manejadores de Eventos Click ---
        // (Sin cambios lógicos)
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (!btnUsuarios.Enabled) return;
            CargarEnPanel(new UsuariosForm());
            MarcarBotonActivo(btnUsuarios);
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            if (!btnJugadores.Enabled) return;
            CargarEnPanel(new JugadoresForm());
            MarcarBotonActivo(btnJugadores);
        }

        private void btnCanchas_Click(object sender, EventArgs e)
        {
            if (!btnCanchas.Enabled) return;
            CargarEnPanel(new CanchasForm());
            MarcarBotonActivo(btnCanchas);
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            if (!btnReservas.Enabled) return;
            CargarEnPanel(new ReservasForm(_userId));
            MarcarBotonActivo(btnReservas);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (!btnReportes.Enabled) return;
            CargarEnPanel(new ReportesForm());
            MarcarBotonActivo(btnReportes);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (!btnBackup.Enabled) return;
            CargarEnPanel(new BackupForm());
            MarcarBotonActivo(btnBackup);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro de que desea salir de la aplicación?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Seguro que desea cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Hide();
                System.Threading.Thread t = new System.Threading.Thread(() =>
                {
                    Application.Run(new LoginForm());
                });
                t.SetApartmentState(System.Threading.ApartmentState.STA);
                t.Start();
                this.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e) { }

    }
}