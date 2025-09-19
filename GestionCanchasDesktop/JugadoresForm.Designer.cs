namespace GestionCanchasDesktop
{
    partial class JugadoresForm
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtTelefono = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            dgvJugadores = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            Editar = new DataGridViewButtonColumn();
            Eliminar = new DataGridViewButtonColumn();
            gbEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).BeginInit();
            SuspendLayout();
            // 
            // gbEdicion
            // 
            gbEdicion.Controls.Add(btnCancelar);
            gbEdicion.Controls.Add(btnLimpiar);
            gbEdicion.Controls.Add(btnGuardar);
            gbEdicion.Controls.Add(label3);
            gbEdicion.Controls.Add(label2);
            gbEdicion.Controls.Add(label1);
            gbEdicion.Controls.Add(txtTelefono);
            gbEdicion.Controls.Add(txtApellido);
            gbEdicion.Controls.Add(txtNombre);
            gbEdicion.Dock = DockStyle.Top;
            gbEdicion.Location = new Point(0, 0);
            gbEdicion.Name = "gbEdicion";
            gbEdicion.Size = new Size(800, 218);
            gbEdicion.TabIndex = 0;
            gbEdicion.TabStop = false;
            gbEdicion.Text = "Alta / Edicion de Jugador";
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(365, 116);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 34);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(365, 76);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 34);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(365, 36);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 34);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 144);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 5;
            label3.Text = "Telefono";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 95);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 4;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 43);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 3;
            label1.Text = "Nombre";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(144, 137);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Ej: 3794-123456";
            txtTelefono.Size = new Size(170, 27);
            txtTelefono.TabIndex = 2;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(144, 88);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Apellido";
            txtApellido.Size = new Size(170, 27);
            txtApellido.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(144, 40);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(170, 27);
            txtNombre.TabIndex = 0;
            // 
            // dgvJugadores
            // 
            dgvJugadores.AllowUserToAddRows = false;
            dgvJugadores.AllowUserToDeleteRows = false;
            dgvJugadores.AllowUserToResizeColumns = false;
            dgvJugadores.AllowUserToResizeRows = false;
            dgvJugadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJugadores.Columns.AddRange(new DataGridViewColumn[] { Id, Nombre, Apellido, Telefono, Editar, Eliminar });
            dgvJugadores.Dock = DockStyle.Fill;
            dgvJugadores.Location = new Point(0, 218);
            dgvJugadores.Name = "dgvJugadores";
            dgvJugadores.ReadOnly = true;
            dgvJugadores.RowHeadersVisible = false;
            dgvJugadores.RowHeadersWidth = 51;
            dgvJugadores.Size = new Size(800, 303);
            dgvJugadores.TabIndex = 1;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            Apellido.HeaderText = "Apellido";
            Apellido.MinimumWidth = 6;
            Apellido.Name = "Apellido";
            Apellido.ReadOnly = true;
            // 
            // Telefono
            // 
            Telefono.HeaderText = "Telefono";
            Telefono.MinimumWidth = 6;
            Telefono.Name = "Telefono";
            Telefono.ReadOnly = true;
            // 
            // Editar
            // 
            Editar.HeaderText = "Editar";
            Editar.MinimumWidth = 6;
            Editar.Name = "Editar";
            Editar.ReadOnly = true;
            Editar.UseColumnTextForButtonValue = true;
            // 
            // Eliminar
            // 
            Eliminar.HeaderText = "Eliminar";
            Eliminar.MinimumWidth = 6;
            Eliminar.Name = "Eliminar";
            Eliminar.ReadOnly = true;
            // 
            // JugadoresForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 521);
            Controls.Add(dgvJugadores);
            Controls.Add(gbEdicion);
            Name = "JugadoresForm";
            Text = "JugadoresForm";
            Load += JugadoresForm_Load;
            gbEdicion.ResumeLayout(false);
            gbEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbEdicion;
        private DataGridView dgvJugadores;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewButtonColumn Editar;
        private DataGridViewButtonColumn Eliminar;
        private TextBox txtTelefono;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnCancelar;
        private Button btnLimpiar;
        private Button btnGuardar;
    }
}