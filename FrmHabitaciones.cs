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

                   
                    cmbTipo.DataSource = dt;
                    cmbTipo.DisplayMember = "NombreTipo"; 
                    cmbTipo.ValueMember = "IdTipoHabitacion";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar tipos de habitación: " + ex.Message);
                }
            }
        }

       
        private void CargarHabitaciones()
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
          
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

                idHabitacionSeleccionada = Convert.ToInt32(fila.Cells["IdHabitacion"].Value);

                txtNumero.Text = fila.Cells["NumeroHabitacion"].Value.ToString();

       
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
                        comando.Parameters.AddWithValue("@idTipo", Convert.ToInt32(cmbTipo.SelectedValue));
                        comando.Parameters.AddWithValue("@numero", txtNumero.Text);
                        comando.Parameters.AddWithValue("@estado", cmbEstado.Text);

                        comando.ExecuteNonQuery();
                        MessageBox.Show("Habitación guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarCampos();
                        CargarHabitaciones(); 
                    }
                }
                catch (Exception ex)
                {
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
            cmbTipo.SelectedIndex = -1; 
            cmbEstado.SelectedIndex = -1; 
            idHabitacionSeleccionada = 0; 
            txtNumero.Focus(); 
        }
    }
}
        

