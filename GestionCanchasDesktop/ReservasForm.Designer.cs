namespace GestionCanchasDesktop
{
    partial class ReservasForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            gbReservas = new GroupBox();
            cmbMetodoPagoGrid = new ComboBox();
            btnLimpiar2 = new Button();
            btnGuardar = new Button();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            cmbJugador = new ComboBox();
            cmbEstado = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            dtpFecha = new DateTimePicker();
            numDuracion = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbHorario = new ComboBox();
            cmbMetodoPago = new ComboBox();
            cmbCancha = new ComboBox();
            dgvReservas = new DataGridView();
            btnCancelar = new Button();
            gbReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            SuspendLayout();
            // 
            // gbReservas
            // 
            gbReservas.BackColor = Color.White;
            gbReservas.Controls.Add(btnCancelar);
            gbReservas.Controls.Add(cmbMetodoPagoGrid);
            gbReservas.Controls.Add(btnLimpiar2);
            gbReservas.Controls.Add(btnGuardar);
            gbReservas.Controls.Add(label9);
            gbReservas.Controls.Add(label8);
            gbReservas.Controls.Add(label7);
            gbReservas.Controls.Add(cmbJugador);
            gbReservas.Controls.Add(cmbEstado);
            gbReservas.Controls.Add(label6);
            gbReservas.Controls.Add(label5);
            gbReservas.Controls.Add(label4);
            gbReservas.Controls.Add(dtpFecha);
            gbReservas.Controls.Add(numDuracion);
            gbReservas.Controls.Add(label3);
            gbReservas.Controls.Add(label2);
            gbReservas.Controls.Add(label1);
            gbReservas.Controls.Add(cmbHorario);
            gbReservas.Controls.Add(cmbMetodoPago);
            gbReservas.Controls.Add(cmbCancha);
            gbReservas.Dock = DockStyle.Top;
            gbReservas.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbReservas.ForeColor = Color.FromArgb(30, 30, 30);
            gbReservas.Location = new Point(15, 15);
            gbReservas.Name = "gbReservas";
            gbReservas.Padding = new Padding(20, 10, 20, 20);
            gbReservas.Size = new Size(750, 240);
            gbReservas.TabIndex = 0;
            gbReservas.TabStop = false;
            gbReservas.Text = "  Gestión de Reservas";
            // 
            // cmbMetodoPagoGrid
            // 
            cmbMetodoPagoGrid.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPagoGrid.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMetodoPagoGrid.FormattingEnabled = true;
            cmbMetodoPagoGrid.Location = new Point(300, 207);
            cmbMetodoPagoGrid.Name = "cmbMetodoPagoGrid";
            cmbMetodoPagoGrid.Size = new Size(112, 25);
            cmbMetodoPagoGrid.TabIndex = 19;
            cmbMetodoPagoGrid.Visible = false;
            // 
            // btnLimpiar2
            // 
            btnLimpiar2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLimpiar2.BackColor = Color.White;
            btnLimpiar2.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            btnLimpiar2.FlatStyle = FlatStyle.Flat;
            btnLimpiar2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiar2.ForeColor = Color.FromArgb(30, 30, 30);
            btnLimpiar2.Location = new Point(570, 90);
            btnLimpiar2.Name = "btnLimpiar2";
            btnLimpiar2.Size = new Size(160, 40);
            btnLimpiar2.TabIndex = 18;
            btnLimpiar2.Text = "Limpiar";
            btnLimpiar2.UseVisualStyleBackColor = false;
            btnLimpiar2.Click += btnLimpiar2_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.BackColor = Color.FromArgb(139, 38, 56);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(570, 35);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(160, 40);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(300, 185);
            label9.Name = "label9";
            label9.Size = new Size(112, 19);
            label9.TabIndex = 15;
            label9.Text = "Método de Pago";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(300, 125);
            label8.Name = "label8";
            label8.Size = new Size(50, 19);
            label8.TabIndex = 14;
            label8.Text = "Estado";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(300, 65);
            label7.Name = "label7";
            label7.Size = new Size(58, 19);
            label7.TabIndex = 13;
            label7.Text = "Jugador";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbJugador
            // 
            cmbJugador.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbJugador.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbJugador.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJugador.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbJugador.FormattingEnabled = true;
            cmbJugador.Location = new Point(300, 87);
            cmbJugador.Name = "cmbJugador";
            cmbJugador.Size = new Size(220, 25);
            cmbJugador.TabIndex = 12;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(300, 147);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(220, 25);
            cmbEstado.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(300, 35);
            label6.Name = "label6";
            label6.Size = new Size(136, 20);
            label6.TabIndex = 10;
            label6.Text = "Datos del Jugador";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 35);
            label5.Name = "label5";
            label5.Size = new Size(132, 20);
            label5.TabIndex = 9;
            label5.Text = "Datos de la Turno";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 185);
            label4.Name = "label4";
            label4.Size = new Size(44, 19);
            label4.TabIndex = 8;
            label4.Text = "Fecha";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFecha.Location = new Point(20, 207);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(220, 25);
            dtpFecha.TabIndex = 7;
            // 
            // numDuracion
            // 
            numDuracion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numDuracion.Location = new Point(160, 147);
            numDuracion.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numDuracion.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(80, 25);
            numDuracion.TabIndex = 6;
            numDuracion.TextAlign = HorizontalAlignment.Center;
            numDuracion.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(160, 125);
            label3.Name = "label3";
            label3.Size = new Size(90, 19);
            label3.TabIndex = 5;
            label3.Text = "Duración (hs)";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 125);
            label2.Name = "label2";
            label2.Size = new Size(55, 19);
            label2.TabIndex = 4;
            label2.Text = "Horario";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 65);
            label1.Name = "label1";
            label1.Size = new Size(54, 19);
            label1.TabIndex = 3;
            label1.Text = "Cancha";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbHorario
            // 
            cmbHorario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHorario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbHorario.FormattingEnabled = true;
            cmbHorario.Location = new Point(20, 147);
            cmbHorario.Name = "cmbHorario";
            cmbHorario.Size = new Size(130, 25);
            cmbHorario.TabIndex = 2;
            cmbHorario.SelectedIndexChanged += cmbHorario_SelectedIndexChanged_1;
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(300, 207);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(220, 25);
            cmbMetodoPago.TabIndex = 1;
            // 
            // cmbCancha
            // 
            cmbCancha.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCancha.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCancha.FormattingEnabled = true;
            cmbCancha.Location = new Point(20, 87);
            cmbCancha.Name = "cmbCancha";
            cmbCancha.Size = new Size(220, 25);
            cmbCancha.TabIndex = 0;
            // 
            // dgvReservas
            // 
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dgvReservas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.BackgroundColor = Color.White;
            dgvReservas.BorderStyle = BorderStyle.None;
            dgvReservas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvReservas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Dock = DockStyle.Fill;
            dgvReservas.GridColor = Color.FromArgb(220, 220, 220);
            dgvReservas.Location = new Point(15, 255);
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.RowHeadersVisible = false;
            dgvReservas.RowHeadersWidth = 51;
            dgvReservas.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(750, 230);
            dgvReservas.TabIndex = 1;
            dgvReservas.CellClick += dgvReservas_CellClick;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.BackColor = Color.White;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.FromArgb(30, 30, 30);
            btnCancelar.Location = new Point(570, 147);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 40);
            btnCancelar.TabIndex = 20;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // ReservasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 248, 248);
            ClientSize = new Size(780, 500);
            Controls.Add(dgvReservas);
            Controls.Add(gbReservas);
            Name = "ReservasForm";
            Padding = new Padding(15);
            Text = "ReservasForm";
            gbReservas.ResumeLayout(false);
            gbReservas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbReservas;
        private ComboBox cmbHorario;
        private ComboBox cmbMetodoPago;
        private ComboBox cmbCancha;
        private DateTimePicker dtpFecha;
        private NumericUpDown numDuracion;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label6;
        private Label label5;
        private Label label9;
        private Label label8;
        private Label label7;
        private ComboBox cmbJugador;
        private ComboBox cmbEstado;
        private DataGridView dgvReservas;
        private ComboBox cmbMetodoPagoGrid;
        private Button btnLimpiar2;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}