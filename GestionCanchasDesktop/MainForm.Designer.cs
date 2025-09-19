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
            panelTop.Margin = new Padding(4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1182, 44);
            panelTop.TabIndex = 1;
            panelTop.Paint += panelTop_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(3, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 37);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(824, 7);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(0, 25);
            lblUsuario.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(42, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(276, 25);
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
            panel1.Location = new Point(0, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 609);
            panel1.TabIndex = 2;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.Image = Properties.Resources.salir;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(42, 541);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(261, 65);
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
            btnBackup.Location = new Point(42, 405);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(261, 65);
            btnBackup.TabIndex = 9;
            btnBackup.Text = "Backup";
            btnBackup.UseVisualStyleBackColor = true;
            // 
            // btnReportes
            // 
            btnReportes.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportes.Image = Properties.Resources.reportes;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(42, 334);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(261, 65);
            btnReportes.TabIndex = 8;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            // 
            // btnReservas
            // 
            btnReservas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReservas.Image = Properties.Resources.reserva;
            btnReservas.ImageAlign = ContentAlignment.MiddleLeft;
            btnReservas.Location = new Point(42, 263);
            btnReservas.Name = "btnReservas";
            btnReservas.Size = new Size(261, 65);
            btnReservas.TabIndex = 7;
            btnReservas.Text = "Reservas";
            btnReservas.UseVisualStyleBackColor = true;
            // 
            // btnCanchas
            // 
            btnCanchas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCanchas.Image = Properties.Resources.cancha;
            btnCanchas.ImageAlign = ContentAlignment.MiddleLeft;
            btnCanchas.Location = new Point(42, 192);
            btnCanchas.Name = "btnCanchas";
            btnCanchas.Size = new Size(261, 65);
            btnCanchas.TabIndex = 6;
            btnCanchas.Text = "Canchas";
            btnCanchas.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsuarios.Image = Properties.Resources.usuarios;
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Location = new Point(42, 50);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(261, 65);
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
            btnJugadores.Location = new Point(42, 121);
            btnJugadores.Name = "btnJugadores";
            btnJugadores.Size = new Size(261, 65);
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
            Lmenu.Location = new Point(42, 16);
            Lmenu.Name = "Lmenu";
            Lmenu.Size = new Size(258, 31);
            Lmenu.TabIndex = 3;
            Lmenu.Text = "Menu de Opciones";
            // 
            // panelContenido
            // 
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(334, 44);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(848, 609);
            panelContenido.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(panelContenido);
            Controls.Add(panel1);
            Controls.Add(panelTop);
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