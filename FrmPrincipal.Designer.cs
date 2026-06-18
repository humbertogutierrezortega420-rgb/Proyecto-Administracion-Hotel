namespace Proyecto_Administracion_Hotel
{
    partial class FrmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuRecepcion = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuCheckIn = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuCheckOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHabitaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuEstadoHabitaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuConsumos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCatalogos = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuServicios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuPrecios = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuarioActual = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRecepcion,
            this.menuHabitaciones,
            this.menuCatalogos,
            this.menuAdmin});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuRecepcion
            // 
            this.menuRecepcion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuCheckIn,
            this.submenuCheckOut});
            this.menuRecepcion.Name = "menuRecepcion";
            this.menuRecepcion.Size = new System.Drawing.Size(108, 29);
            this.menuRecepcion.Text = "Recepción";
            // 
            // submenuCheckIn
            // 
            this.submenuCheckIn.Name = "submenuCheckIn";
            this.submenuCheckIn.Size = new System.Drawing.Size(270, 34);
            this.submenuCheckIn.Text = "Nueva Reservación";
            this.submenuCheckIn.Click += new System.EventHandler(this.submenuCheckIn_Click);
            // 
            // submenuCheckOut
            // 
            this.submenuCheckOut.Name = "submenuCheckOut";
            this.submenuCheckOut.Size = new System.Drawing.Size(270, 34);
            this.submenuCheckOut.Text = "Salida y Facturación";
            // 
            // menuHabitaciones
            // 
            this.menuHabitaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuEstadoHabitaciones,
            this.submenuConsumos});
            this.menuHabitaciones.Name = "menuHabitaciones";
            this.menuHabitaciones.Size = new System.Drawing.Size(130, 29);
            this.menuHabitaciones.Text = "Habitaciones";
            // 
            // submenuEstadoHabitaciones
            // 
            this.submenuEstadoHabitaciones.Name = "submenuEstadoHabitaciones";
            this.submenuEstadoHabitaciones.Size = new System.Drawing.Size(386, 34);
            this.submenuEstadoHabitaciones.Text = "Estado de Habitaciones / Limpieza";
            this.submenuEstadoHabitaciones.Click += new System.EventHandler(this.submenuEstadoHabitaciones_Click);
            // 
            // submenuConsumos
            // 
            this.submenuConsumos.Name = "submenuConsumos";
            this.submenuConsumos.Size = new System.Drawing.Size(386, 34);
            this.submenuConsumos.Text = "Cargar Consumo a Habitación";
            // 
            // menuCatalogos
            // 
            this.menuCatalogos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuClientes,
            this.submenuServicios});
            this.menuCatalogos.Name = "menuCatalogos";
            this.menuCatalogos.Size = new System.Drawing.Size(108, 29);
            this.menuCatalogos.Text = "Catálogos";
            // 
            // submenuClientes
            // 
            this.submenuClientes.Name = "submenuClientes";
            this.submenuClientes.Size = new System.Drawing.Size(270, 34);
            this.submenuClientes.Text = "Clientes";
            this.submenuClientes.Click += new System.EventHandler(this.submenuClientes_Click);
            // 
            // submenuServicios
            // 
            this.submenuServicios.Name = "submenuServicios";
            this.submenuServicios.Size = new System.Drawing.Size(270, 34);
            this.submenuServicios.Text = "Servicios Extra";
            // 
            // menuAdmin
            // 
            this.menuAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuEmpleados,
            this.submenuPrecios});
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(147, 29);
            this.menuAdmin.Text = "Administración";
            // 
            // submenuEmpleados
            // 
            this.submenuEmpleados.Name = "submenuEmpleados";
            this.submenuEmpleados.Size = new System.Drawing.Size(347, 34);
            this.submenuEmpleados.Text = "Empleados y Roles";
            // 
            // submenuPrecios
            // 
            this.submenuPrecios.Name = "submenuPrecios";
            this.submenuPrecios.Size = new System.Drawing.Size(347, 34);
            this.submenuPrecios.Text = "Tipos de Habitación y Precios";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuarioActual});
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1200, 32);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsuarioActual
            // 
            this.lblUsuarioActual.Name = "lblUsuarioActual";
            this.lblUsuarioActual.Size = new System.Drawing.Size(157, 25);
            this.lblUsuarioActual.Text = "Usuario: -- | Rol: --";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPrincipal";
            this.Text = "Sistema de Administración de Hotel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrincipal_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuHabitaciones;
        private System.Windows.Forms.ToolStripMenuItem menuCatalogos;
        private System.Windows.Forms.ToolStripMenuItem menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem submenuEstadoHabitaciones;
        private System.Windows.Forms.ToolStripMenuItem submenuCheckIn;
        private System.Windows.Forms.ToolStripMenuItem submenuCheckOut;
        private System.Windows.Forms.ToolStripMenuItem submenuConsumos;
        private System.Windows.Forms.ToolStripMenuItem submenuClientes;
        private System.Windows.Forms.ToolStripMenuItem submenuServicios;
        private System.Windows.Forms.ToolStripMenuItem submenuEmpleados;
        private System.Windows.Forms.ToolStripMenuItem submenuPrecios;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioActual;
        private System.Windows.Forms.ToolStripMenuItem menuRecepcion;
    }
}