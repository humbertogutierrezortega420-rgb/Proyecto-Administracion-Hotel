using Proyecto_Administracion_Hotel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Administracion_Hotel
{
    public partial class FrmLogin : Form
    {


        string cadenaConexion = "Data Source=HotelDB.db;Version=3;";
        public FrmLogin()
        {
            InitializeComponent();
        }

        
            private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT IdRol, Nombre, Apellidos FROM Empleados WHERE Usuario = @usuario AND Contrasena = @contrasena";

                    using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                        comando.Parameters.AddWithValue("@contrasena", txtContraseña.Text);

                        using (SQLiteDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())  
                            {
                                int idRol = Convert.ToInt32(lector["IdRol"]);
                                string nombreCompleto = lector["Nombre"].ToString() + " " + lector["Apellidos"].ToString();

                                MessageBox.Show("Bienvenido, " + nombreCompleto, "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                FrmPrincipal menu = new FrmPrincipal(idRol, nombreCompleto);
                                menu.Show();

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtContraseña.Clear();
                                txtUsuario.Focus();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    
}

//Un pequeño ajuste en FrmPrincipal Notarás que la línea FrmPrincipal menu = new FrmPrincipal(idRol, nombreCompleto); marcará un error rojo. Esto es porque nuestro FrmPrincipal aún no sabe cómo recibir esos datos. Para arreglarlo, ve al código de tu FrmPrincipal.cs y modifica el constructor (la parte que tiene el mismo nombre que la clase) para que reciba el rol y el nombre, así:
//El ajuste son las primeras lineas de codigo hasta la linea 51 en el frms principal.