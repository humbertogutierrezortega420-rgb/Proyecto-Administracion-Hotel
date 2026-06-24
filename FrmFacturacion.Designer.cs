namespace Proyecto_Administracion_Hotel
{
    partial class FrmFacturacion
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
            this.cmbReservasActivas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDesgloseConsumos = new System.Windows.Forms.DataGridView();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.btnFinalizarCheckOut = new System.Windows.Forms.Button();
            this.txtSubtotalHospedaje = new System.Windows.Forms.TextBox();
            this.txtSubtotalConsumos = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesgloseConsumos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbReservasActivas
            // 
            this.cmbReservasActivas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReservasActivas.FormattingEnabled = true;
            this.cmbReservasActivas.Location = new System.Drawing.Point(167, 23);
            this.cmbReservasActivas.Name = "cmbReservasActivas";
            this.cmbReservasActivas.Size = new System.Drawing.Size(121, 21);
            this.cmbReservasActivas.TabIndex = 0;
            this.cmbReservasActivas.SelectedIndexChanged += new System.EventHandler(this.cmbReservasActivas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Búsqueda / Selección:";
            // 
            // dgvDesgloseConsumos
            // 
            this.dgvDesgloseConsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDesgloseConsumos.Location = new System.Drawing.Point(48, 61);
            this.dgvDesgloseConsumos.Name = "dgvDesgloseConsumos";
            this.dgvDesgloseConsumos.Size = new System.Drawing.Size(698, 162);
            this.dgvDesgloseConsumos.TabIndex = 6;
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Location = new System.Drawing.Point(646, 347);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.ReadOnly = true;
            this.txtTotalPagar.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPagar.TabIndex = 7;
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(519, 403);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(121, 21);
            this.cmbMetodoPago.TabIndex = 8;
            // 
            // btnFinalizarCheckOut
            // 
            this.btnFinalizarCheckOut.Location = new System.Drawing.Point(671, 403);
            this.btnFinalizarCheckOut.Name = "btnFinalizarCheckOut";
            this.btnFinalizarCheckOut.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizarCheckOut.TabIndex = 9;
            this.btnFinalizarCheckOut.Text = "PAGAR";
            this.btnFinalizarCheckOut.UseVisualStyleBackColor = true;
            this.btnFinalizarCheckOut.Click += new System.EventHandler(this.btnFinalizarCheckOut_Click);
            // 
            // txtSubtotalHospedaje
            // 
            this.txtSubtotalHospedaje.Location = new System.Drawing.Point(646, 279);
            this.txtSubtotalHospedaje.Name = "txtSubtotalHospedaje";
            this.txtSubtotalHospedaje.ReadOnly = true;
            this.txtSubtotalHospedaje.Size = new System.Drawing.Size(100, 20);
            this.txtSubtotalHospedaje.TabIndex = 10;
            // 
            // txtSubtotalConsumos
            // 
            this.txtSubtotalConsumos.Location = new System.Drawing.Point(646, 314);
            this.txtSubtotalConsumos.Name = "txtSubtotalConsumos";
            this.txtSubtotalConsumos.ReadOnly = true;
            this.txtSubtotalConsumos.Size = new System.Drawing.Size(100, 20);
            this.txtSubtotalConsumos.TabIndex = 11;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(646, 26);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCliente.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "SubTotal Hospedaje:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "SubTotal Consumos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(606, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(424, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Metodo de Pago:";
            // 
            // FrmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtSubtotalConsumos);
            this.Controls.Add(this.txtSubtotalHospedaje);
            this.Controls.Add(this.btnFinalizarCheckOut);
            this.Controls.Add(this.cmbMetodoPago);
            this.Controls.Add(this.txtTotalPagar);
            this.Controls.Add(this.dgvDesgloseConsumos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbReservasActivas);
            this.Name = "FrmFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salida y Facturación (Check-Out)";
            this.Load += new System.EventHandler(this.FrmFacturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesgloseConsumos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReservasActivas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDesgloseConsumos;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Button btnFinalizarCheckOut;
        private System.Windows.Forms.TextBox txtSubtotalHospedaje;
        private System.Windows.Forms.TextBox txtSubtotalConsumos;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}