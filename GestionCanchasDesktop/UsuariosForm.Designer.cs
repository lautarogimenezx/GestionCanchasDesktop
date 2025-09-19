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
            gbEdicion = new GroupBox();
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
            chkActivo = new CheckBox();
            gbEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // gbEdicion
            // 
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
            gbEdicion.Location = new Point(0, 0);
            gbEdicion.Name = "gbEdicion";
            gbEdicion.Size = new Size(800, 214);
            gbEdicion.TabIndex = 0;
            gbEdicion.TabStop = false;
            gbEdicion.Tag = "";
            gbEdicion.Text = "Alta / Edición de usuario";
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(345, 118);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 34);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(345, 76);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(110, 34);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(345, 35);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(110, 34);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 174);
            label5.Name = "label5";
            label5.Size = new Size(31, 20);
            label5.TabIndex = 10;
            label5.Text = "Rol";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 137);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 9;
            label4.Text = "Contraseña";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 104);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 8;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 71);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 7;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 35);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 6;
            label1.Text = "Nombre";
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Administrador", "Canchero", "Contador" });
            cmbRol.Location = new Point(127, 171);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(151, 28);
            cmbRol.TabIndex = 4;
            cmbRol.Tag = "";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(127, 138);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(170, 27);
            txtPassword.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(127, 101);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(170, 27);
            txtEmail.TabIndex = 2;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(127, 68);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Apellido";
            txtApellido.Size = new Size(170, 27);
            txtApellido.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(127, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(170, 27);
            txtNombre.TabIndex = 0;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { Nombre, ID, Apellido, Email, Rol, Estado, Editar, Baja_Alta });
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(0, 214);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(800, 307);
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
            Baja_Alta.HeaderText = "Baja_Alta";
            Baja_Alta.MinimumWidth = 6;
            Baja_Alta.Name = "Baja_Alta";
            Baja_Alta.ReadOnly = true;
            Baja_Alta.UseColumnTextForButtonValue = true;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(334, 170);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(139, 24);
            chkActivo.TabIndex = 15;
            chkActivo.Text = "Activo / Inactivo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // UsuariosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 521);
            Controls.Add(dgvUsuarios);
            Controls.Add(gbEdicion);
            Name = "UsuariosForm";
            Text = "UsuariosForm";
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