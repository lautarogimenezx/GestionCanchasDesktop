using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace GestionCanchasDesktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Se ejecuta al cargar el form
        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Si tenés un label de error, lo ocultamos al inicio.
            // (El control lblError está en el Designer)
            try { lblError.Visible = false; } catch { /* si no existe, no pasa nada */ }
        }

        // CLICK del botón Continuar (probar conexión)
        private void btnContinuar_Click(object sender, EventArgs e)
                {
                    lblError.Visible = false;

                    var email = txtUsuario.Text.Trim();
                    var pass = txtContraseña.Text;

                    if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(pass))
                    {
                        lblError.Text = "Ingresá email y contraseña.";
                        lblError.Visible = true;
                        return;
                    }

                    try
                    {
                        if (AuthService.TryLogin(email, pass, out var user) && user != null)
                        {
                            // Crear y mostrar el formulario principal
                            var main = new MainForm(user.Id, user.Nombre, user.Apellido, user.Rol);

                            // Al cerrar el MainForm, cerramos también la app (cierra el Login oculto)
                            main.FormClosed += (_, __) => this.Close();

                            this.Hide();   // ocultar Login
                            main.Show();   // mostrar Main
                        }
                        else
                        {
                            lblError.Text = "Email o contraseña inválidos (o usuario inactivo).";
                            lblError.Visible = true;
                        }
                    }
                    catch (SqlException ex)
                    {
                        lblError.Text = $"SQL {ex.Number}: {ex.Message}";
                        lblError.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = $"Error: {ex.Message}";
                        lblError.Visible = true;
                    }
                }



        // (Opcionales del diseñador: podés borrarlos si no los usás)
        private void txtUsuario_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}
