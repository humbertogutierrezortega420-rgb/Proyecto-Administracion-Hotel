using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Proyecto_Administracion_Hotel
{
    public partial class FrmHabitaciones : Form
    {
        string cadenaConexion = "Data Source=HotelDB.db;Version=3;";
        int idHabitacionSeleccionada = 0;
        public FrmHabitaciones()
        {
            InitializeComponent();
        }

        private void FrmHabitaciones_Load(object sender, EventArgs e)
        {
            CargarTiposHabitacion();
            CargarHabitaciones();
        }
        // 1. Método para llenar el ComboBox de Tipos desde SQLite
        private void CargarTiposHabitacion()
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT IdTipoHabitacion, NombreTipo FROM TiposHabitacion";
                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    // Conectamos el ComboBox a la tabla
                    cmbTipo.DataSource = dt;
                    cmbTipo.DisplayMember = "NombreTipo"; // Esto es lo que lee el usuario (Ej: "Suite")
                    cmbTipo.ValueMember = "IdTipoHabitacion"; // Esto es el número oculto que guardaremos (Ej: 3)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar tipos de habitación: " + ex.Message);
                }
            }
        }

        // 2. Método para mostrar todas las habitaciones en el DataGridView
        private void CargarHabitaciones()
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    // Hacemos un JOIN para que la tabla muestre el nombre del tipo y no solo un número
                    string query = @"SELECT h.IdHabitacion, h.NumeroHabitacion, t.NombreTipo, h.Estado 
                                     FROM Habitaciones h
                                     INNER JOIN TiposHabitacion t ON h.IdTipoHabitacion = t.IdTipoHabitacion";

                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dgvHabitaciones.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar habitaciones: " + ex.Message);
                }
            }
        }

        private void dgvHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvHabitaciones.Rows[e.RowIndex];

                // Guardamos el ID de la habitación seleccionada
                idHabitacionSeleccionada = Convert.ToInt32(fila.Cells["IdHabitacion"].Value);

                // Llenamos los controles con los datos de la fila
                txtNumero.Text = fila.Cells["NumeroHabitacion"].Value.ToString();

                // Al asignarle el texto al ComboBox, este buscará y seleccionará la opción correcta automáticamente
                cmbTipo.Text = fila.Cells["NombreTipo"].Value.ToString();
                cmbEstado.Text = fila.Cells["Estado"].Value.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text) || cmbTipo.SelectedValue == null || string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos (Número, Tipo y Estado).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO Habitaciones (IdTipoHabitacion, NumeroHabitacion, Estado) VALUES (@idTipo, @numero, @estado)";

                    using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                    {
                        // Extraemos el ID oculto del tipo de habitación seleccionado en el ComboBox
                        comando.Parameters.AddWithValue("@idTipo", Convert.ToInt32(cmbTipo.SelectedValue));
                        comando.Parameters.AddWithValue("@numero", txtNumero.Text);
                        comando.Parameters.AddWithValue("@estado", cmbEstado.Text);

                        comando.ExecuteNonQuery();
                        MessageBox.Show("Habitación guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarCampos();
                        CargarHabitaciones(); // Refrescamos la tabla
                    }
                }
                catch (Exception ex)
                {
                    // Si el número de habitación ya existe, SQLite lanzará un error por la restricción UNIQUE
                    MessageBox.Show("Error al guardar. Es posible que este número de habitación ya exista. Detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idHabitacionSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una habitación de la tabla para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "UPDATE Habitaciones SET IdTipoHabitacion = @idTipo, NumeroHabitacion = @numero, Estado = @estado WHERE IdHabitacion = @id";

                    using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@idTipo", Convert.ToInt32(cmbTipo.SelectedValue));
                        comando.Parameters.AddWithValue("@numero", txtNumero.Text);
                        comando.Parameters.AddWithValue("@estado", cmbEstado.Text);
                        comando.Parameters.AddWithValue("@id", idHabitacionSeleccionada);

                        comando.ExecuteNonQuery();
                        MessageBox.Show("Habitación actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarCampos();
                        CargarHabitaciones();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idHabitacionSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una habitación de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar esta habitación?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
                {
                    try
                    {
                        conexion.Open();
                        string query = "DELETE FROM Habitaciones WHERE IdHabitacion = @id";

                        using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                        {
                            comando.Parameters.AddWithValue("@id", idHabitacionSeleccionada);
                            comando.ExecuteNonQuery();

                            MessageBox.Show("Habitación eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarCampos();
                            CargarHabitaciones();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se puede eliminar la habitación porque tiene historial de reservaciones asociado. Detalles: " + ex.Message, "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNumero.Clear();
            cmbTipo.SelectedIndex = -1; // Deselecciona el tipo
            cmbEstado.SelectedIndex = -1; // Deselecciona el estado
            idHabitacionSeleccionada = 0; // Reinicia el ID
            txtNumero.Focus(); // Pone el cursor en el TextBox del número
        }
    }
}
        

