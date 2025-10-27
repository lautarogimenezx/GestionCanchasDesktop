namespace GestionCanchasDesktop
{
    partial class LoginForm
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
            panel2 = new Panel();
            lblError = new Label();
            btnContinuar = new Button();
            txtContraseña = new TextBox();
            txtUsuario = new TextBox();
            label3 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblError);
            panel2.Controls.Add(btnContinuar);
            panel2.Controls.Add(txtContraseña);
            panel2.Controls.Add(txtUsuario);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(100, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 300);
            panel2.TabIndex = 2;
            // 
            // lblError
            // 
            lblError.Anchor = AnchorStyles.Top;
            lblError.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(50, 180);
            lblError.Name = "lblError";
            lblError.Size = new Size(300, 19);
            lblError.TabIndex = 4;
            lblError.Text = "Email o contraseña inválidos ";
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Visible = false;
            // 
            // btnContinuar
            // 
            btnContinuar.Anchor = AnchorStyles.Top;
            btnContinuar.BackColor = Color.FromArgb(139, 38, 56);
            btnContinuar.FlatAppearance.BorderSize = 0;
            btnContinuar.FlatStyle = FlatStyle.Flat;
            btnContinuar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContinuar.ForeColor = Color.White;
            btnContinuar.Location = new Point(50, 210);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(300, 45);
            btnContinuar.TabIndex = 3;
            btnContinuar.Text = "Continuar";
            btnContinuar.UseVisualStyleBackColor = false;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // txtContraseña
            // 
            txtContraseña.Anchor = AnchorStyles.Top;
            txtContraseña.BackColor = Color.White;
            txtContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtContraseña.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña.ForeColor = Color.FromArgb(30, 30, 30);
            txtContraseña.Location = new Point(50, 135);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PlaceholderText = "Contraseña";
            txtContraseña.Size = new Size(300, 27);
            txtContraseña.TabIndex = 2;
            txtContraseña.UseSystemPasswordChar = true;
            txtContraseña.TextChanged += txtContraseña_TextChanged;
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.Top;
            txtUsuario.BackColor = Color.White;
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.ForeColor = Color.FromArgb(30, 30, 30);
            txtUsuario.Location = new Point(50, 90);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Email";
            txtUsuario.Size = new Size(300, 27);
            txtUsuario.TabIndex = 1;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(30, 30, 30);
            label3.Location = new Point(100, 25);
            label3.Name = "label3";
            label3.Size = new Size(193, 41);
            label3.TabIndex = 0;
            label3.Text = "Inicia Sesión";
            // 
            // LoginForm
            // 
            AcceptButton = btnContinuar;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(248, 248, 248);
            ClientSize = new Size(600, 400);
            Controls.Add(panel2);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Canchas Deportivas";
            Load += LoginForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Button btnContinuar;
        private TextBox txtContraseña;
        private TextBox txtUsuario;
        private Label label3;
        private Label lblError;
    }
}