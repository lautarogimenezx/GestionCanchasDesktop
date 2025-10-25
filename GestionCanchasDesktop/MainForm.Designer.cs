namespace GestionCanchasDesktop
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Definición de colores (Tema Oscuro Minimalista)
            System.Drawing.Color COLOR_ACENTO = System.Drawing.Color.FromArgb(139, 38, 56);
            System.Drawing.Color COLOR_FONDO_PRIMARIO = System.Drawing.Color.FromArgb(248, 248, 248);
            System.Drawing.Color COLOR_FONDO_SECUNDARIO = System.Drawing.Color.FromArgb(40, 40, 40);
            System.Drawing.Color COLOR_TEXTO_CLARO = System.Drawing.Color.White;
            System.Drawing.Color COLOR_TEXTO_OSCURO = System.Drawing.Color.FromArgb(40, 40, 40);

            panelTop = new Panel();
            btnLogout = new Button();
            pictureBox1 = new PictureBox();
            lblUsuario = new Label();
            label1 = new Label();
            panel1 = new Panel();
            btnSalir = new Button(); // Declaración presente
            btnBackup = new Button();
            btnReportes = new Button();
            btnReservas = new Button();
            btnCanchas = new Button();
            btnUsuarios = new Button();
            btnJugadores = new Button();
            panelContenido = new Panel();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop (Encabezado)
            // 
            panelTop.BackColor = COLOR_FONDO_SECUNDARIO;
            panelTop.Controls.Add(btnLogout);
            panelTop.Controls.Add(pictureBox1);
            panelTop.Controls.Add(lblUsuario);
            panelTop.Controls.Add(label1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(1034, 40);
            panelTop.TabIndex = 1;
            // 
            // btnLogout (Cerrar Sesión)
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = System.Drawing.Color.Transparent;
            btnLogout.FlatAppearance.BorderColor = COLOR_ACENTO;
            btnLogout.FlatAppearance.BorderSize = 1;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnLogout.ForeColor = COLOR_TEXTO_CLARO;
            btnLogout.Location = new System.Drawing.Point(915, 8);
            btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new System.Drawing.Size(110, 25);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Cerrar sesión";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pictureBox1 (Logo)
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new System.Drawing.Point(8, 5);
            pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(30, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Asegura que la imagen se ajuste
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblUsuario (Usuario)
            // 
            lblUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0); // Bold para destacar
            lblUsuario.ForeColor = COLOR_TEXTO_CLARO; // Texto claro sobre fondo oscuro
            lblUsuario.Location = new System.Drawing.Point(650, 11); // Ajustar posición si es necesario
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new System.Drawing.Size(250, 19); // Tamaño fijo para evitar AutoSize
            lblUsuario.TabIndex = 2;
            lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight; // Alinear a la derecha
            // 
            // label1 (Título de la App)
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = COLOR_TEXTO_CLARO;
            label1.Location = new System.Drawing.Point(45, 9);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(245, 21);
            label1.TabIndex = 0;
            label1.Text = "Gestión de Canchas Deportivas";
            // 
            // panel1 (Menú Lateral)
            // 
            panel1.BackColor = COLOR_FONDO_SECUNDARIO;
            panel1.Controls.Add(btnSalir); // Añadido btnSalir
            panel1.Controls.Add(btnBackup);
            panel1.Controls.Add(btnReportes);
            panel1.Controls.Add(btnReservas);
            panel1.Controls.Add(btnCanchas);
            panel1.Controls.Add(btnUsuarios);
            panel1.Controls.Add(btnJugadores);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 40);
            panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(250, 450);
            panel1.TabIndex = 2;
            // 
            // --- INICIO DE CONFIGURACIÓN BÁSICA DE BOTONES DEL MENÚ ---
            // (Los estilos complejos se aplican en MainForm.cs)
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new System.Drawing.Point(0, 10);
            btnUsuarios.Margin = new System.Windows.Forms.Padding(0);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnUsuarios.Size = new System.Drawing.Size(250, 45);
            btnUsuarios.TabIndex = 5;
            btnUsuarios.Text = "   Usuarios";
            btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnJugadores
            // 
            btnJugadores.Location = new System.Drawing.Point(0, 60); // 10 + 45 + 5 (espacio)
            btnJugadores.Margin = new System.Windows.Forms.Padding(0);
            btnJugadores.Name = "btnJugadores";
            btnJugadores.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnJugadores.Size = new System.Drawing.Size(250, 45);
            btnJugadores.TabIndex = 6;
            btnJugadores.Text = "   Jugadores";
            btnJugadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnJugadores.Click += btnJugadores_Click;
            // 
            // btnCanchas
            // 
            btnCanchas.Location = new System.Drawing.Point(0, 110); // 60 + 45 + 5
            btnCanchas.Margin = new System.Windows.Forms.Padding(0);
            btnCanchas.Name = "btnCanchas";
            btnCanchas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnCanchas.Size = new System.Drawing.Size(250, 45);
            btnCanchas.TabIndex = 4;
            btnCanchas.Text = "   Canchas";
            btnCanchas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnCanchas.Click += btnCanchas_Click;
            // 
            // btnReservas
            // 
            btnReservas.Location = new System.Drawing.Point(0, 160); // 110 + 45 + 5
            btnReservas.Margin = new System.Windows.Forms.Padding(0);
            btnReservas.Name = "btnReservas";
            btnReservas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnReservas.Size = new System.Drawing.Size(250, 45);
            btnReservas.TabIndex = 3;
            btnReservas.Text = "   Reservas";
            btnReservas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnReservas.Click += btnReservas_Click;
            // 
            // btnReportes
            // 
            btnReportes.Location = new System.Drawing.Point(0, 210); // 160 + 45 + 5
            btnReportes.Margin = new System.Windows.Forms.Padding(0);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnReportes.Size = new System.Drawing.Size(250, 45);
            btnReportes.TabIndex = 2;
            btnReportes.Text = "   Reportes";
            btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnBackup
            // 
            btnBackup.Location = new System.Drawing.Point(0, 260); // 210 + 45 + 5
            btnBackup.Margin = new System.Windows.Forms.Padding(0);
            btnBackup.Name = "btnBackup";
            btnBackup.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnBackup.Size = new System.Drawing.Size(250, 45);
            btnBackup.TabIndex = 1;
            btnBackup.Text = "   Backup";
            btnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnSalir - RESTAURADO Y POSICIONADO
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left; // Anclado al fondo
            btnSalir.Location = new System.Drawing.Point(0, 395); // panel1.Height(450) - btn.Height(45) - Margen(10)
            btnSalir.Margin = new System.Windows.Forms.Padding(0);
            btnSalir.Name = "btnSalir";
            btnSalir.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnSalir.Size = new System.Drawing.Size(250, 45);
            btnSalir.TabIndex = 0; // Asegúrate de que tenga un TabIndex si usas navegación por teclado
            btnSalir.Text = "   Salir";
            btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSalir.Click += btnSalir_Click;

            // --- FIN DE CONFIGURACIÓN BÁSICA DE BOTONES DEL MENÚ ---
            // 
            // panelContenido
            // 
            panelContenido.BackColor = COLOR_FONDO_PRIMARIO;
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new System.Drawing.Point(250, 40);
            panelContenido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new System.Drawing.Size(784, 450);
            panelContenido.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1034, 490);
            Controls.Add(panelContenido);
            Controls.Add(panel1);
            Controls.Add(panelTop);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen; // Centrar al inicio
            Text = "Gestión de Canchas Deportivas";
            Load += MainForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // 
        // DECLARACIONES DE VARIABLES (DEBEN ESTAR TODAS)
        // 
        private Panel panelTop;
        private Label label1;
        private Label lblUsuario;
        private Panel panel1;
        private Button btnSalir;
        private Button btnBackup;
        private Button btnReportes;
        private Button btnReservas;
        private Button btnCanchas;
        private Button btnUsuarios;
        private Button btnJugadores;
        private Panel panelContenido;
        private PictureBox pictureBox1;
        private Button btnLogout;
    }
}