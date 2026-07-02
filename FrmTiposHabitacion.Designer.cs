namespace Proyecto_Administracion_Hotel
{
    partial class FrmTiposHabitacion
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
            this.dgvTiposHabitacion = new System.Windows.Forms.DataGridView();
            this.txtNombreTipo = new System.Windows.Forms.TextBox();
            this.nudPrecioBase = new System.Windows.Forms.NumericUpDown();
            this.nudCapacidad = new System.Windows.Forms.NumericUpDown();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposHabitacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidad)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTiposHabitacion
            // 
            this.dgvTiposHabitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiposHabitacion.Location = new System.Drawing.Point(222, 68);
            this.dgvTiposHabitacion.Name = "dgvTiposHabitacion";
            this.dgvTiposHabitacion.RowHeadersWidth = 51;
            this.dgvTiposHabitacion.RowTemplate.Height = 24;
            this.dgvTiposHabitacion.Size = new System.Drawing.Size(380, 320);
            this.dgvTiposHabitacion.TabIndex = 0;
            this.dgvTiposHabitacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTiposHabitacion_CellClick);
            // 
            // txtNombreTipo
            // 
            this.txtNombreTipo.Location = new System.Drawing.Point(82, 68);
            this.txtNombreTipo.Name = "txtNombreTipo";
            this.txtNombreTipo.Size = new System.Drawing.Size(100, 22);
            this.txtNombreTipo.TabIndex = 1;
            // 
            // nudPrecioBase
            // 
            this.nudPrecioBase.DecimalPlaces = 2;
            this.nudPrecioBase.Location = new System.Drawing.Point(82, 139);
            this.nudPrecioBase.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPrecioBase.Name = "nudPrecioBase";
            this.nudPrecioBase.Size = new System.Drawing.Size(120, 22);
            this.nudPrecioBase.TabIndex = 2;
            // 
            // nudCapacidad
            // 
            this.nudCapacidad.Location = new System.Drawing.Point(82, 195);
            this.nudCapacidad.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudCapacidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCapacidad.Name = "nudCapacidad";
            this.nudCapacidad.Size = new System.Drawing.Size(120, 22);
            this.nudCapacidad.TabIndex = 3;
            this.nudCapacidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(661, 81);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(661, 127);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(661, 179);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(661, 235);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmTiposHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.nudCapacidad);
            this.Controls.Add(this.nudPrecioBase);
            this.Controls.Add(this.txtNombreTipo);
            this.Controls.Add(this.dgvTiposHabitacion);
            this.Name = "FrmTiposHabitacion";
            this.Text = "FrmTiposHabitacion";
            this.Load += new System.EventHandler(this.FrmTiposHabitacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposHabitacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTiposHabitacion;
        private System.Windows.Forms.TextBox txtNombreTipo;
        private System.Windows.Forms.NumericUpDown nudPrecioBase;
        private System.Windows.Forms.NumericUpDown nudCapacidad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}