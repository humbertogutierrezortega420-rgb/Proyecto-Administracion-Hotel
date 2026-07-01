namespace Proyecto_Administracion_Hotel
{
    partial class FrmHabitaciones
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
            this.txtHabitacionSeleccionada = new System.Windows.Forms.TextBox();
            this.cmbNuevoEstado = new System.Windows.Forms.ComboBox();
            this.btnActualizarEstado = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHabitacionSeleccionada
            // 
            this.txtHabitacionSeleccionada.Location = new System.Drawing.Point(264, 42);
            this.txtHabitacionSeleccionada.Margin = new System.Windows.Forms.Padding(4);
            this.txtHabitacionSeleccionada.Name = "txtHabitacionSeleccionada";
            this.txtHabitacionSeleccionada.ReadOnly = true;
            this.txtHabitacionSeleccionada.Size = new System.Drawing.Size(132, 22);
            this.txtHabitacionSeleccionada.TabIndex = 0;
            // 
            // cmbNuevoEstado
            // 
            this.cmbNuevoEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNuevoEstado.FormattingEnabled = true;
            this.cmbNuevoEstado.Location = new System.Drawing.Point(236, 166);
            this.cmbNuevoEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbNuevoEstado.Name = "cmbNuevoEstado";
            this.cmbNuevoEstado.Size = new System.Drawing.Size(160, 24);
            this.cmbNuevoEstado.TabIndex = 1;
            // 
            // btnActualizarEstado
            // 
            this.btnActualizarEstado.Location = new System.Drawing.Point(903, 313);
            this.btnActualizarEstado.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizarEstado.Name = "btnActualizarEstado";
            this.btnActualizarEstado.Size = new System.Drawing.Size(100, 28);
            this.btnActualizarEstado.TabIndex = 5;
            this.btnActualizarEstado.Text = "Actualizar";
            this.btnActualizarEstado.UseVisualStyleBackColor = true;
            this.btnActualizarEstado.Click += new System.EventHandler(this.btnActualizarEstado_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(903, 364);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones.Location = new System.Drawing.Point(459, 42);
            this.dgvHabitaciones.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.RowHeadersWidth = 51;
            this.dgvHabitaciones.Size = new System.Drawing.Size(544, 263);
            this.dgvHabitaciones.TabIndex = 7;
            this.dgvHabitaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHabitaciones_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Habitacion Seleccionada:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Estado:";
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Location = new System.Drawing.Point(459, 324);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(10, 16);
            this.lblAviso.TabIndex = 10;
            this.lblAviso.Text = ".";
            // 
            // FrmHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHabitaciones);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnActualizarEstado);
            this.Controls.Add(this.cmbNuevoEstado);
            this.Controls.Add(this.txtHabitacionSeleccionada);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmHabitaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Habitaciones";
            this.Load += new System.EventHandler(this.FrmHabitaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHabitacionSeleccionada;
        private System.Windows.Forms.ComboBox cmbNuevoEstado;
        private System.Windows.Forms.Button btnActualizarEstado;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAviso;
    }
}