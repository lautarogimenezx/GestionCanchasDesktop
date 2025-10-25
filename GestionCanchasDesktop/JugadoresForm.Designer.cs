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
            // Definición de colores
            Color COLOR_ACENTO = Color.FromArgb(139, 38, 56); // RGB(139, 38, 56)
            Color COLOR_FONDO_PRIMARIO = Color.FromArgb(248, 248, 248);
            Color COLOR_FONDO_TARJETA = Color.White;
            Color COLOR_TEXTO_OSCURO = Color.FromArgb(30, 30, 30);
            Color COLOR_TEXTO_SECUNDARIO = Color.FromArgb(100, 100, 100);

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
            // JugadoresForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = COLOR_FONDO_PRIMARIO; // Fondo del formulario blanco/claro
            ClientSize = new Size(780, 500); // Tamaño ajustado para más espacio
            Controls.Add(dgvJugadores);
            Controls.Add(gbEdicion);
            Name = "JugadoresForm";
            Text = "JugadoresForm";
            Padding = new Padding(15); // Margen general
            Load += JugadoresForm_Load;
            // 
            // gbEdicion (Tarjeta de Edición)
            // 
            gbEdicion.BackColor = COLOR_FONDO_TARJETA;
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
            gbEdicion.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0); // Título más grande
            gbEdicion.ForeColor = COLOR_TEXTO_OSCURO;
            gbEdicion.Location = new Point(15, 15);
            gbEdicion.Padding = new Padding(20, 10, 20, 20);
            gbEdicion.Size = new Size(750, 190); // Altura cómoda
            gbEdicion.TabIndex = 0;
            gbEdicion.TabStop = false;
            gbEdicion.Text = "  Alta / Edición de Jugador";
            // 
            // Botones de Acción
            // Estilo plano y uniforme
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
            btnCancelar.Location = new Point(570, 125);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 40);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
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
            btnLimpiar.Location = new Point(570, 75);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(160, 40);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            //
            // btnGuardar (Principal)
            //
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.BackColor = COLOR_ACENTO; // Color de acento
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(570, 25);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(160, 40);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // Etiquetas (Labels)
            // Alineadas a la derecha
            //
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 115);
            label3.Name = "label3";
            label3.Size = new Size(61, 19);
            label3.TabIndex = 5;
            label3.Text = "Teléfono";
            label3.TextAlign = ContentAlignment.MiddleRight;
            label3.ForeColor = COLOR_TEXTO_OSCURO;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 75);
            label2.Name = "label2";
            label2.Size = new Size(61, 19);
            label2.TabIndex = 4;
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
            label1.TabIndex = 3;
            label1.Text = "Nombre";
            label1.TextAlign = ContentAlignment.MiddleRight;
            label1.ForeColor = COLOR_TEXTO_OSCURO;
            //
            // Campos de Texto (TextBox)
            // Estilo FixedSingle con altura cómoda
            //
            // txtTelefono
            //
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(130, 112);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Ej: 3794-123456";
            txtTelefono.Size = new Size(190, 25);
            txtTelefono.TabIndex = 2;
            txtTelefono.BackColor = Color.White;
            //
            // txtApellido
            //
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(130, 72);
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
            // dgvJugadores (Tabla de Datos)
            // Estilo plano y sin cabeceras de fila
            //
            dgvJugadores.AllowUserToAddRows = false;
            dgvJugadores.AllowUserToDeleteRows = false;
            dgvJugadores.AllowUserToResizeColumns = false;
            dgvJugadores.AllowUserToResizeRows = false;
            dgvJugadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvJugadores.BackgroundColor = COLOR_FONDO_TARJETA;
            dgvJugadores.BorderStyle = BorderStyle.None;
            dgvJugadores.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvJugadores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
            dgvJugadores.ColumnHeadersDefaultCellStyle.ForeColor = COLOR_TEXTO_OSCURO;
            dgvJugadores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJugadores.Columns.AddRange(new DataGridViewColumn[] { Id, Nombre, Apellido, Telefono, Editar, Eliminar });
            dgvJugadores.Dock = DockStyle.Fill;
            dgvJugadores.GridColor = Color.FromArgb(220, 220, 220);
            dgvJugadores.Location = new Point(15, 205); // Debajo del gbEdicion (tarjeta) + Margen
            dgvJugadores.Name = "dgvJugadores";
            dgvJugadores.ReadOnly = true;
            dgvJugadores.RowHeadersVisible = false; // QUITAR FILAS DE LA IZQUIERDA
            dgvJugadores.RowHeadersWidth = 51;
            dgvJugadores.RowTemplate.DefaultCellStyle.BackColor = COLOR_FONDO_TARJETA;
            dgvJugadores.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Filas alternas sutiles
            dgvJugadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJugadores.Size = new Size(750, 280);
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
            Telefono.HeaderText = "Teléfono";
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
            Eliminar.UseColumnTextForButtonValue = true;

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