namespace GestionCanchasDesktop
{
    partial class UsuariosForm
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
            // Definición de colores
            Color COLOR_ACENTO = Color.FromArgb(139, 38, 56); // RGB(139, 38, 56)
            Color COLOR_FONDO_PRIMARIO = Color.FromArgb(248, 248, 248);
            Color COLOR_FONDO_TARJETA = Color.White;
            Color COLOR_TEXTO_OSCURO = Color.FromArgb(30, 30, 30);
            Color COLOR_TEXTO_SECUNDARIO = Color.FromArgb(100, 100, 100);

            gbEdicion = new GroupBox();
            chkActivo = new CheckBox();
            btnCancelar = new Button();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbRol = new ComboBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            dgvUsuarios = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Rol = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            Editar = new DataGridViewButtonColumn();
            Baja_Alta = new DataGridViewButtonColumn();
            gbEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // UsuariosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = COLOR_FONDO_PRIMARIO;
            ClientSize = new Size(780, 500); // Tamaño ajustado para más espacio
            Controls.Add(dgvUsuarios);
            Controls.Add(gbEdicion);
            Name = "UsuariosForm";
            Text = "UsuariosForm";
            Padding = new Padding(15); // Más margen general
            // 
            // gbEdicion (Tarjeta de Edición)
            // 
            gbEdicion.BackColor = COLOR_FONDO_TARJETA;
            gbEdicion.Controls.Add(chkActivo);
            gbEdicion.Controls.Add(btnCancelar);
            gbEdicion.Controls.Add(btnLimpiar);
            gbEdicion.Controls.Add(btnGuardar);
            gbEdicion.Controls.Add(label5);
            gbEdicion.Controls.Add(label4);
            gbEdicion.Controls.Add(label3);
            gbEdicion.Controls.Add(label2);
            gbEdicion.Controls.Add(label1);
            gbEdicion.Controls.Add(cmbRol);
            gbEdicion.Controls.Add(txtPassword);
            gbEdicion.Controls.Add(txtEmail);
            gbEdicion.Controls.Add(txtApellido);
            gbEdicion.Controls.Add(txtNombre);
            gbEdicion.Dock = DockStyle.Top;
            gbEdicion.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0); // Título más grande
            gbEdicion.ForeColor = COLOR_TEXTO_OSCURO;
            gbEdicion.Location = new Point(15, 15);
            gbEdicion.Padding = new Padding(20, 10, 20, 20);
            gbEdicion.Size = new Size(750, 220); // Altura aumentada
            gbEdicion.TabIndex = 0;
            gbEdicion.TabStop = false;
            gbEdicion.Text = "  Alta / Edición de usuario";
            // 
            // chkActivo
            //
            chkActivo.AutoSize = true;
            chkActivo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkActivo.Location = new Point(340, 155); // Posición ajustada
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(130, 23);
            chkActivo.TabIndex = 15;
            chkActivo.Text = "Activo / Inactivo";
            chkActivo.UseVisualStyleBackColor = true;
            chkActivo.ForeColor = COLOR_TEXTO_SECUNDARIO;
            //
            // Botones de Acción
            // Mejor alineación a la derecha y tamaño uniforme
            //
            // btnCancelar (Secundario)
            //
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Anclado a la derecha
            btnCancelar.BackColor = Color.White;
            btnCancelar.FlatAppearance.BorderColor = COLOR_TEXTO_SECUNDARIO;
            btnCancelar.FlatAppearance.BorderSize = 1;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = COLOR_TEXTO_OSCURO;
            btnCancelar.Location = new Point(570, 145);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 40);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            //
            // btnLimpiar (Secundario)
            //
            btnLimpiar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.FlatAppearance.BorderColor = COLOR_TEXTO_SECUNDARIO;
            btnLimpiar.FlatAppearance.BorderSize = 1;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = COLOR_TEXTO_OSCURO;
            btnLimpiar.Location = new Point(570, 90);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(160, 40);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // btnGuardar (Principal)
            //
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.BackColor = COLOR_ACENTO; // Color de acento
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(570, 35);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(160, 40);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // Etiquetas (Labels)
            // Alineadas a la derecha
            //
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 155);
            label5.Name = "label5";
            label5.Size = new Size(30, 19);
            label5.TabIndex = 10;
            label5.Text = "Rol";
            label5.TextAlign = ContentAlignment.MiddleRight;
            label5.ForeColor = COLOR_TEXTO_OSCURO;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 125);
            label4.Name = "label4";
            label4.Size = new Size(81, 19);
            label4.TabIndex = 9;
            label4.Text = "Contraseña";
            label4.TextAlign = ContentAlignment.MiddleRight;
            label4.ForeColor = COLOR_TEXTO_OSCURO;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 95);
            label3.Name = "label3";
            label3.Size = new Size(41, 19);
            label3.TabIndex = 8;
            label3.Text = "Email";
            label3.TextAlign = ContentAlignment.MiddleRight;
            label3.ForeColor = COLOR_TEXTO_OSCURO;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 65);
            label2.Name = "label2";
            label2.Size = new Size(61, 19);
            label2.TabIndex = 7;
            label2.Text = "Apellido";
            label2.TextAlign = ContentAlignment.MiddleRight;
            label2.ForeColor = COLOR_TEXTO_OSCURO;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 35);
            label1.Name = "label1";
            label1.Size = new Size(61, 19);
            label1.TabIndex = 6;
            label1.Text = "Nombre";
            label1.TextAlign = ContentAlignment.MiddleRight;
            label1.ForeColor = COLOR_TEXTO_OSCURO;
            //
            // Campos de Texto (TextBox, ComboBox)
            // Aumenta la altura a 30px
            //
            // cmbRol
            //
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Administrador", "Canchero", "Contador" });
            cmbRol.Location = new Point(130, 152);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(180, 25);
            cmbRol.TabIndex = 4;
            //
            // txtPassword
            //
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(130, 122);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(190, 25);
            txtPassword.TabIndex = 3;
            txtPassword.BackColor = Color.White;
            //
            // txtEmail
            //
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(130, 92);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(190, 25);
            txtEmail.TabIndex = 2;
            txtEmail.BackColor = Color.White;
            //
            // txtApellido
            //
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(130, 62);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Apellido";
            txtApellido.Size = new Size(190, 25);
            txtApellido.TabIndex = 1;
            txtApellido.BackColor = Color.White;
            //
            // txtNombre
            //
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(130, 32);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(190, 25);
            txtNombre.TabIndex = 0;
            txtNombre.BackColor = Color.White;
            //
            // dgvUsuarios (Tabla de Datos)
            // Alineación de la tabla al nuevo tamaño y fondo
            //
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = COLOR_FONDO_TARJETA; // Fondo de tabla claro
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = COLOR_TEXTO_OSCURO;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { Nombre, ID, Apellido, Email, Rol, Estado, Editar, Baja_Alta });
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.GridColor = Color.FromArgb(220, 220, 220);
            dgvUsuarios.Location = new Point(15, 235); // Justo debajo del gbEdicion con margen
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.RowTemplate.DefaultCellStyle.BackColor = COLOR_FONDO_TARJETA;
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(750, 250);
            dgvUsuarios.TabIndex = 1;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            // 
            // Apellido
            // 
            Apellido.HeaderText = "Apellido";
            Apellido.MinimumWidth = 6;
            Apellido.Name = "Apellido";
            Apellido.ReadOnly = true;
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // Rol
            // 
            Rol.HeaderText = "Rol";
            Rol.MinimumWidth = 6;
            Rol.Name = "Rol";
            Rol.ReadOnly = true;
            // 
            // Estado
            // 
            Estado.HeaderText = "Estado";
            Estado.MinimumWidth = 6;
            Estado.Name = "Estado";
            Estado.ReadOnly = true;
            // 
            // Editar
            // 
            Editar.HeaderText = "Editar";
            Editar.MinimumWidth = 6;
            Editar.Name = "Editar";
            Editar.ReadOnly = true;
            Editar.UseColumnTextForButtonValue = true;
            // 
            // Baja_Alta
            // 
            Baja_Alta.HeaderText = "Baja/Alta";
            Baja_Alta.MinimumWidth = 6;
            Baja_Alta.Name = "Baja_Alta";
            Baja_Alta.ReadOnly = true;
            Baja_Alta.UseColumnTextForButtonValue = true;

            gbEdicion.ResumeLayout(false);
            gbEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbEdicion;
        private TextBox txtNombre;
        private ComboBox cmbRol;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Button btnCancelar;
        private Button btnLimpiar;
        private Button btnGuardar;
        private DataGridView dgvUsuarios;
        private Label label2;
        private TextBox txtApellido;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Rol;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewButtonColumn Editar;
        private DataGridViewButtonColumn Baja_Alta;
        private CheckBox chkActivo;
    }
}