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
        // Variables para guardar quién entró
        private int rolUsuario;
        private string nombreUsuario;

        // Modificamos el constructor para recibir los datos del Login
        public FrmPrincipal(int idRol, string nombre)
        {
            InitializeComponent();

            this.rolUsuario = idRol;
            this.nombreUsuario = nombre;

            // Actualizamos la barra de estado de abajo
            lblUsuarioActual.Text = $"Usuario: {nombreUsuario} | Rol ID: {rolUsuario}";

            // Aquí aplicamos los permisos
            ConfigurarPermisos();
        }

        private void ConfigurarPermisos()
        {
            // Si es personal de limpieza (Rol 3)
            if (rolUsuario == 3)
            {
                menuRecepcion.Visible = false;
                menuCatalogos.Visible = false;
                menuAdmin.Visible = false;
                submenuConsumos.Visible = false;
            }
            // Si es Recepcionista (Rol 2)
            else if (rolUsuario == 2)
            {
                menuAdmin.Visible = false; // La recepcionista no gestiona empleados ni precios base
            }
            // Si es Gerente (Rol 1) tiene todo visible por defecto, no hacemos nada.
        }
        
        private void AbrirFormularioHijo<MiForm>() where MiForm : Form, new()
        {
            Form formulario;

            // Busca si el formulario ya está abierto en la colección de MdiChildren
            formulario = this.MdiChildren.FirstOrDefault(f => f is MiForm);

            if (formulario != null)
            {
                // Si ya está abierto, simplemente lo trae al frente
                formulario.BringToFront();
            }
            else
            {
                // Si no está abierto, crea una nueva instancia
                formulario = new MiForm();
                formulario.MdiParent = this; // Le dice que su papá es el FrmPrincipal
                formulario.Show();
            }
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Esto asegura que al cerrar el menú principal, toda la aplicación se apague por completo
            Application.Exit();
        }

        private void submenuClientes_Click(object sender, EventArgs e)
        {
            // Llama a la función y le pasa el nombre del formulario que quieres abrir
            AbrirFormularioHijo<FrmClientes>();
        }

        private void submenuEstadoHabitaciones_Click(object sender, EventArgs e)
        {
            // Esto abre la ventana de Habitaciones
            AbrirFormularioHijo<FrmHabitaciones>();
        }

        private void submenuCheckIn_Click(object sender, EventArgs e)
        {
            // Verificamos si ya está abierto para no abrirlo dos veces
            Form formulario = this.MdiChildren.FirstOrDefault(f => f is FrmReservaciones);

            if (formulario != null)
            {
                formulario.BringToFront();
            }
            else
            {
                // Al crearlo, le pasamos las variables del empleado que guardamos en el FrmPrincipal
                FrmReservaciones frmReserva = new FrmReservaciones(this.rolUsuario, this.nombreUsuario);
                frmReserva.MdiParent = this;
                frmReserva.Show();
            }
        }
    }
}
