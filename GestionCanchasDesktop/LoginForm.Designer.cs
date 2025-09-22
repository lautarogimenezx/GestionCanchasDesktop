

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
            panel2.BackColor = Color.WhiteSmoke;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblError);
            panel2.Controls.Add(btnContinuar);
            panel2.Controls.Add(txtContraseña);
            panel2.Controls.Add(txtUsuario);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(31, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(520, 280);
            panel2.TabIndex = 2;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(115, 169);
            lblError.Name = "lblError";
            lblError.Size = new Size(223, 20);
            lblError.TabIndex = 4;
            lblError.Text = "Usuario o contraseña invalidos";
            lblError.Visible = false;
            // 
            // btnContinuar
            // 
            btnContinuar.Location = new Point(75, 197);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(349, 29);
            btnContinuar.TabIndex = 3;
            btnContinuar.Text = "Continuar";
            btnContinuar.UseVisualStyleBackColor = true;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // txtContraseña
            // 
            txtContraseña.ForeColor = Color.Black;
            txtContraseña.Location = new Point(75, 119);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PlaceholderText = "Ingrese su contraseña";
            txtContraseña.Size = new Size(349, 27);
            txtContraseña.TabIndex = 2;
            txtContraseña.UseSystemPasswordChar = true;
            txtContraseña.TextChanged += txtContraseña_TextChanged;
            // 
            // txtUsuario
            // 
            txtUsuario.ForeColor = Color.Black;
            txtUsuario.Location = new Point(75, 82);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Ingrese su nombre de usuario";
            txtUsuario.Size = new Size(349, 27);
            txtUsuario.TabIndex = 1;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(156, 13);
            label3.Name = "label3";
            label3.Size = new Size(176, 37);
            label3.TabIndex = 0;
            label3.Text = "Inicia Sesión";
            // 
            // LoginForm
            // 
            AcceptButton = btnContinuar;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(582, 308);
            Controls.Add(panel2);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "LoginForm";
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