namespace Proyecto_Administracion_Hotel
{
    partial class FrmConsumos
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbReservaActiva = new System.Windows.Forms.ComboBox();
            this.cmbServicios = new System.Windows.Forms.ComboBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarConsumo = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvConsumos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Habitación Ocupada:";
            // 
            // cmbReservaActiva
            // 
            this.cmbReservaActiva.FormattingEnabled = true;
            this.cmbReservaActiva.Location = new System.Drawing.Point(301, 56);
            this.cmbReservaActiva.Name = "cmbReservaActiva";
            this.cmbReservaActiva.Size = new System.Drawing.Size(126, 21);
            this.cmbReservaActiva.TabIndex = 1;
            this.cmbReservaActiva.SelectedIndexChanged += new System.EventHandler(this.cmbReservaActiva_SelectedIndexChanged);
            // 
            // cmbServicios
            // 
            this.cmbServicios.FormattingEnabled = true;
            this.cmbServicios.Location = new System.Drawing.Point(301, 146);
            this.cmbServicios.Name = "cmbServicios";
            this.cmbServicios.Size = new System.Drawing.Size(126, 21);
            this.cmbServicios.TabIndex = 2;
            this.cmbServicios.SelectedIndexChanged += new System.EventHandler(this.cmbServicios_SelectedIndexChanged);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(302, 213);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(125, 20);
            this.txtPrecio.TabIndex = 3;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(302, 272);
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(125, 20);
            this.nudCantidad.TabIndex = 4;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAgregarConsumo
            // 
            this.btnAgregarConsumo.Location = new System.Drawing.Point(688, 282);
            this.btnAgregarConsumo.Name = "btnAgregarConsumo";
            this.btnAgregarConsumo.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarConsumo.TabIndex = 5;
            this.btnAgregarConsumo.Text = "Agregar";
            this.btnAgregarConsumo.UseVisualStyleBackColor = true;
            this.btnAgregarConsumo.Click += new System.EventHandler(this.btnAgregarConsumo_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(688, 326);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvConsumos
            // 
            this.dgvConsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumos.Location = new System.Drawing.Point(479, 56);
            this.dgvConsumos.Name = "dgvConsumos";
            this.dgvConsumos.Size = new System.Drawing.Size(284, 203);
            this.dgvConsumos.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Concepto / Descripción:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Precio ($):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Monto:";
            // 
            // FrmConsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvConsumos);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAgregarConsumo);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.cmbServicios);
            this.Controls.Add(this.cmbReservaActiva);
            this.Controls.Add(this.label1);
            this.Name = "FrmConsumos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar Consumos a Habitación";
            this.Load += new System.EventHandler(this.FrmConsumos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbReservaActiva;
        private System.Windows.Forms.ComboBox cmbServicios;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Button btnAgregarConsumo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvConsumos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}