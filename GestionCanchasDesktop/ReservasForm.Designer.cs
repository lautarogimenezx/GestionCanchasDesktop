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
            gbReservas = new GroupBox();
            cmbMetodoPagoGrid = new ComboBox();
            btnLimpiar = new Button();
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
            gbReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            SuspendLayout();
            // 
            // gbReservas
            // 
            gbReservas.Controls.Add(cmbMetodoPagoGrid);
            gbReservas.Controls.Add(btnLimpiar);
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
            gbReservas.Location = new Point(0, 0);
            gbReservas.Name = "gbReservas";
            gbReservas.Size = new Size(800, 220);
            gbReservas.TabIndex = 0;
            gbReservas.TabStop = false;
            gbReservas.Text = "Reservas";
            // 
            // cmbMetodoPagoGrid
            // 
            cmbMetodoPagoGrid.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPagoGrid.FormattingEnabled = true;
            cmbMetodoPagoGrid.Location = new Point(602, 174);
            cmbMetodoPagoGrid.Name = "cmbMetodoPagoGrid";
            cmbMetodoPagoGrid.Size = new Size(121, 23);
            cmbMetodoPagoGrid.TabIndex = 19;
            cmbMetodoPagoGrid.Visible = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(342, 173);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 18;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(242, 171);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(412, 111);
            label9.Name = "label9";
            label9.Size = new Size(95, 15);
            label9.TabIndex = 15;
            label9.Text = "Metodo de Pago";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(465, 82);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 14;
            label8.Text = "Estado";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(458, 52);
            label7.Name = "label7";
            label7.Size = new Size(49, 15);
            label7.TabIndex = 13;
            label7.Text = "Jugador";
            // 
            // cmbJugador
            // 
            cmbJugador.FormattingEnabled = true;
            cmbJugador.Location = new Point(525, 49);
            cmbJugador.Name = "cmbJugador";
            cmbJugador.Size = new Size(121, 23);
            cmbJugador.TabIndex = 12;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(525, 78);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(487, 19);
            label6.Name = "label6";
            label6.Size = new Size(124, 15);
            label6.TabIndex = 10;
            label6.Text = "Selección de Jugador";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(85, 19);
            label5.Name = "label5";
            label5.Size = new Size(119, 15);
            label5.TabIndex = 9;
            label5.Text = "Selección de Cancha";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 112);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 8;
            label4.Text = "Fecha";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(117, 108);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 7;
            // 
            // numDuracion
            // 
            numDuracion.Location = new Point(117, 140);
            numDuracion.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numDuracion.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(120, 23);
            numDuracion.TabIndex = 6;
            numDuracion.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 142);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 5;
            label3.Text = "Duracion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 82);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 4;
            label2.Text = "Horarios";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 49);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 3;
            label1.Text = "Lista de Canchas";
            // 
            // cmbHorario
            // 
            cmbHorario.FormattingEnabled = true;
            cmbHorario.Location = new Point(117, 79);
            cmbHorario.Name = "cmbHorario";
            cmbHorario.Size = new Size(121, 23);
            cmbHorario.TabIndex = 2;
            cmbHorario.SelectedIndexChanged += cmbHorario_SelectedIndexChanged_1;
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(525, 107);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(121, 23);
            cmbMetodoPago.TabIndex = 1;
            // 
            // cmbCancha
            // 
            cmbCancha.FormattingEnabled = true;
            cmbCancha.Location = new Point(117, 46);
            cmbCancha.Name = "cmbCancha";
            cmbCancha.Size = new Size(121, 23);
            cmbCancha.TabIndex = 0;
            // 
            // dgvReservas
            // 
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Dock = DockStyle.Bottom;
            dgvReservas.Location = new Point(0, 209);
            dgvReservas.Name = "dgvReservas";
            dgvReservas.Size = new Size(800, 241);
            dgvReservas.TabIndex = 1;
            dgvReservas.CellClick += dgvReservas_CellClick;
            // 
            // ReservasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvReservas);
            Controls.Add(gbReservas);
            Name = "ReservasForm";
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
        private Button btnLimpiar;
        private Button btnGuardar;
        private Label label9;
        private Label label8;
        private Label label7;
        private ComboBox cmbJugador;
        private ComboBox cmbEstado;
        private DataGridView dgvReservas;
        private ComboBox cmbMetodoPagoGrid;
    }
}