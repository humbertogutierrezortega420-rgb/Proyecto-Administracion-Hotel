using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Administracion_Hotel.Modelos; // Para usar tu clase Cliente
using System.Data.SQLite;

namespace Proyecto_Administracion_Hotel
{
    public partial class FrmClientes : Form
    {

        // Misma cadena de conexión que usamos en el Login
        string cadenaConexion = "Data Source=HotelDB.db;Version=3;";

        int idClienteSeleccionado = 0;

        public FrmClientes()
        {
            InitializeComponent();
        }

        // Este evento ocurre al abrir la ventana
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
        // 1. Método para LEER (Read) los clientes y mostrarlos en la tabla
        private void CargarClientes()
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT * FROM Clientes";
                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dgvClientes.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        // 2. Evento para GUARDAR (Create) un nuevo cliente
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("El nombre y los apellidos son obligatorios.");
                return;
            }

            // Usamos la clase Cliente que creaste gracias a la herencia
            Cliente nuevoCliente = new Cliente()
            {
                Nombre = txtName.Text,
                Apellidos = txtApellidos.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text
            };

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO Clientes (Nombre, Apellidos, Telefono, Correo) VALUES (@nombre, @apellidos, @telefono, @correo)";

                    using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nuevoCliente.Nombre);
                        comando.Parameters.AddWithValue("@apellidos", nuevoCliente.Apellidos);
                        comando.Parameters.AddWithValue("@telefono", nuevoCliente.Telefono);
                        comando.Parameters.AddWithValue("@correo", nuevoCliente.Correo);

                        comando.ExecuteNonQuery(); // Ejecuta la inserción
                        MessageBox.Show("Cliente guardado con éxito.");

                        LimpiarCampos();
                        CargarClientes(); // Refresca la tabla
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
        }

        // Método auxiliar para vaciar los TextBox
        private void LimpiarCampos()
        {
            txtName.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtName.Focus();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que se haya hecho clic en una fila válida (y no en los títulos de arriba)
            if (e.RowIndex >= 0)
            {
                // Obtenemos la fila seleccionada
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                // Guardamos el ID (la primera columna, índice 0) en nuestra variable
                idClienteSeleccionado = Convert.ToInt32(fila.Cells[0].Value);

                // Pasamos los datos a los TextBox
                txtName.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellidos.Text = fila.Cells["Apellidos"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la tabla para modificar.");
                return;
            }

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    // Consulta de actualización usando WHERE para no afectar a los demás
                    string query = "UPDATE Clientes SET Nombre = @nombre, Apellidos = @apellidos, Telefono = @telefono, Correo = @correo WHERE IdCliente = @id";

                    using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", txtName.Text);
                        comando.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
                        comando.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                        comando.Parameters.AddWithValue("@correo", txtCorreo.Text);
                        comando.Parameters.AddWithValue("@id", idClienteSeleccionado); // Usamos el ID que guardamos en el clic

                        comando.ExecuteNonQuery();
                        MessageBox.Show("Cliente actualizado con éxito.");

                        LimpiarCampos();
                        idClienteSeleccionado = 0; // Reiniciamos la selección
                        CargarClientes(); // Refrescamos la tabla
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la tabla para eliminar.");
                return;
            }

            // Pedimos confirmación antes de borrar por seguridad
            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar a este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
                {
                    try
                    {
                        conexion.Open();
                        string query = "DELETE FROM Clientes WHERE IdCliente = @id";

                        using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                        {
                            comando.Parameters.AddWithValue("@id", idClienteSeleccionado);
                            comando.ExecuteNonQuery();

                            MessageBox.Show("Cliente eliminado con éxito.");

                            LimpiarCampos();
                            idClienteSeleccionado = 0;
                            CargarClientes();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Un error común al borrar es que el cliente ya tenga una reservación (Llave Foránea)
                        MessageBox.Show("Error al eliminar. Es posible que este cliente tenga reservaciones asociadas. Detalles: " + ex.Message);
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            idClienteSeleccionado = 0; // Deseleccionamos al cliente actual
        }

       
    }
    
}

