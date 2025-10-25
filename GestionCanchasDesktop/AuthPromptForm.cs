using System;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    public sealed class AuthPromptForm : Form
    {
        public string Email => txtEmail.Text.Trim();
        public string Password => txtPassword.Text;

        TextBox txtEmail = new TextBox { PlaceholderText = "email@dominio.com", Width = 260 };
        TextBox txtPassword = new TextBox { PlaceholderText = "Contraseña", UseSystemPasswordChar = true, Width = 260 };
        Button btnOk = new Button { Text = "Aceptar", DialogResult = DialogResult.OK, Width = 100 };
        Button btnCancel = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Width = 100 };
        Label lblTitulo = new Label { AutoSize = true, Font = new System.Drawing.Font("Segoe UI Semibold", 12f) };

        public AuthPromptForm(string titulo)
        {
            Text = "Autenticación requerida";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = MinimizeBox = false;
            AcceptButton = btnOk;
            CancelButton = btnCancel;

            lblTitulo.Text = titulo;

            var table = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(12), ColumnCount = 2, RowCount = 4 };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            table.Controls.Add(lblTitulo, 0, 0); table.SetColumnSpan(lblTitulo, 2);
            table.Controls.Add(new Label { Text = "Email:", AutoSize = true }, 0, 1);
            table.Controls.Add(txtEmail, 1, 1);
            table.Controls.Add(new Label { Text = "Contraseña:", AutoSize = true }, 0, 2);
            table.Controls.Add(txtPassword, 1, 2);

            var pnlBtns = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill };
            pnlBtns.Controls.Add(btnCancel);
            pnlBtns.Controls.Add(btnOk);
            table.Controls.Add(pnlBtns, 0, 3); table.SetColumnSpan(pnlBtns, 2);

            Controls.Add(table);
            ClientSize = new System.Drawing.Size(420, 180);
        }
    }
}
