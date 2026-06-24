using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Administracion_Hotel
{
    public partial class FrmPrincipal : Form
    {
        private int rolUsuario;
        private string nombreUsuario;


        public FrmPrincipal()
        {
            InitializeComponent();
        }
        public FrmPrincipal(int idRol, string nombre)
        {
            InitializeComponent();


            this.rolUsuario = idRol;
            this.nombreUsuario = nombre;

            lblUsuarioActual.Text = $"Usuario: {nombreUsuario} | Rol ID: {rolUsuario}";

            ConfigurarPermisos();
        }

        private void ConfigurarPermisos()
        {
            if (rolUsuario == 3)
            {
                menuRecepcion.Visible = false;
                menuCatalogos.Visible = false;
                menuAdmin.Visible = false;
                submenuConsumos.Visible = false;
            }
            else if (rolUsuario == 2)
            {
                menuAdmin.Visible = false; 
            }
        }
        
        private void AbrirFormularioHijo<MiForm>() where MiForm : Form, new()
        {
            Form formulario;

            formulario = this.MdiChildren.FirstOrDefault(f => f is MiForm);

            if (formulario != null)
            {
                formulario.BringToFront();
            }
            else
            {
                formulario = new MiForm();
                formulario.MdiParent = this; 
                formulario.Show();
            }
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void submenuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmClientes>();
        }

        private void submenuEstadoHabitaciones_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmHabitaciones>();
        }

        private void submenuCheckIn_Click(object sender, EventArgs e)
        {
            Form formulario = this.MdiChildren.FirstOrDefault(f => f is FrmReservaciones);

            if (formulario != null)
            {
                formulario.BringToFront();
            }
            else
            {
                FrmReservaciones frmReserva = new FrmReservaciones(this.rolUsuario, this.nombreUsuario);
                frmReserva.MdiParent = this;
                frmReserva.Show();
            }
        }

        private void submenuConsumos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmConsumos>();
        }

        private void submenuCheckOut_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmFacturacion>();

        }
    }
}
