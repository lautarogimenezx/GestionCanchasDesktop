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
            panelTop = new Panel();
            pictureBox1 = new PictureBox();
            lblUsuario = new Label();
            label1 = new Label();
            panel1 = new Panel();
            btnSalir = new Button();
            btnBackup = new Button();
            btnReportes = new Button();
            btnReservas = new Button();
            btnCanchas = new Button();
            btnUsuarios = new Button();
            btnJugadores = new Button();
            Lmenu = new Label();
            panelContenido = new Panel();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.Black;
            panelTop.Controls.Add(pictureBox1);
            panelTop.Controls.Add(lblUsuario);
            panelTop.Controls.Add(label1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1034, 33);
            panelTop.TabIndex = 1;
            panelTop.Paint += panelTop_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(3, 5);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 28);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(721, 5);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(0, 20);
            lblUsuario.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(37, 7);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(225, 20);
            label1.TabIndex = 0;
            label1.Text = "Gestion de Canchas Deportivas";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(btnBackup);
            panel1.Controls.Add(btnReportes);
            panel1.Controls.Add(btnReservas);
            panel1.Controls.Add(btnCanchas);
            panel1.Controls.Add(btnUsuarios);
            panel1.Controls.Add(btnJugadores);
            panel1.Controls.Add(Lmenu);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 33);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(292, 457);
            panel1.TabIndex = 2;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.Image = Properties.Resources.salir;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(37, 406);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(228, 49);
            btnSalir.TabIndex = 10;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnBackup
            // 
            btnBackup.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackup.Image = Properties.Resources.backup;
            btnBackup.ImageAlign = ContentAlignment.MiddleLeft;
            btnBackup.Location = new Point(37, 304);
            btnBackup.Margin = new Padding(3, 2, 3, 2);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(228, 49);
            btnBackup.TabIndex = 9;
            btnBackup.Text = "Backup";
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnReportes
            // 
            btnReportes.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportes.Image = Properties.Resources.reportes;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(37, 250);
            btnReportes.Margin = new Padding(3, 2, 3, 2);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(228, 49);
            btnReportes.TabIndex = 8;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnReservas
            // 
            btnReservas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReservas.Image = Properties.Resources.reserva;
            btnReservas.ImageAlign = ContentAlignment.MiddleLeft;
            btnReservas.Location = new Point(37, 197);
            btnReservas.Margin = new Padding(3, 2, 3, 2);
            btnReservas.Name = "btnReservas";
            btnReservas.Size = new Size(228, 49);
            btnReservas.TabIndex = 7;
            btnReservas.Text = "Reservas";
            btnReservas.UseVisualStyleBackColor = true;
            btnReservas.Click += btnReservas_Click;
            // 
            // btnCanchas
            // 
            btnCanchas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCanchas.Image = Properties.Resources.cancha;
            btnCanchas.ImageAlign = ContentAlignment.MiddleLeft;
            btnCanchas.Location = new Point(37, 144);
            btnCanchas.Margin = new Padding(3, 2, 3, 2);
            btnCanchas.Name = "btnCanchas";
            btnCanchas.Size = new Size(228, 49);
            btnCanchas.TabIndex = 6;
            btnCanchas.Text = "Canchas";
            btnCanchas.UseVisualStyleBackColor = true;
            btnCanchas.Click += btnCanchas_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsuarios.Image = Properties.Resources.usuarios;
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Location = new Point(37, 38);
            btnUsuarios.Margin = new Padding(3, 2, 3, 2);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(228, 49);
            btnUsuarios.TabIndex = 5;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnJugadores
            // 
            btnJugadores.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnJugadores.Image = Properties.Resources.jugadores;
            btnJugadores.ImageAlign = ContentAlignment.MiddleLeft;
            btnJugadores.Location = new Point(37, 91);
            btnJugadores.Margin = new Padding(3, 2, 3, 2);
            btnJugadores.Name = "btnJugadores";
            btnJugadores.Size = new Size(228, 49);
            btnJugadores.TabIndex = 4;
            btnJugadores.Text = "Jugadores";
            btnJugadores.UseVisualStyleBackColor = true;
            btnJugadores.Click += btnJugadores_Click;
            // 
            // Lmenu
            // 
            Lmenu.AutoSize = true;
            Lmenu.Font = new Font("Cooper Black", 16F);
            Lmenu.ForeColor = Color.White;
            Lmenu.Location = new Point(37, 12);
            Lmenu.Name = "Lmenu";
            Lmenu.Size = new Size(213, 25);
            Lmenu.TabIndex = 3;
            Lmenu.Text = "Menu de Opciones";
            // 
            // panelContenido
            // 
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(292, 33);
            panelContenido.Margin = new Padding(3, 2, 3, 2);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(742, 457);
            panelContenido.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 490);
            Controls.Add(panelContenido);
            Controls.Add(panel1);
            Controls.Add(panelTop);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label label1;
        private Label lblUsuario;
        private Panel panel1;
        private Label Lmenu;
        private Button btnSalir;
        private Button btnBackup;
        private Button btnReportes;
        private Button btnReservas;
        private Button btnCanchas;
        private Button btnUsuarios;
        private Button btnJugadores;
        private Panel panelContenido;
        private PictureBox pictureBox1;
    }
}