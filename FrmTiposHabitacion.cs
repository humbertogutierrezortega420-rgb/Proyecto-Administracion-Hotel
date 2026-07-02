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
    public partial class FrmTiposHabitacion : Form
    {
        string cadenaConexion = "Data Source=HotelDB.db;Version=3;";
        private int idTipoSeleccionado = 0;
        public FrmTiposHabitacion()
        {
            InitializeComponent();
        }

        private void FrmTiposHabitacion_Load(object sender, EventArgs e)
        {
            CargarTiposHabitacion();
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }
     
    
        private void CargarTiposHabitacion()
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT IdTipoHabitacion, NombreTipo AS 'Categoria', PrecioBase AS 'Precio x Noche', CapacidadMaxima AS 'Capacidad (Personas)' From TiposHabitacion";
                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    dgvTiposHabitacion.DataSource = dt;
                    dgvTiposHabitacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvTiposHabitacion.Columns["IdTipoHabitacion"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos " + ex.Message);
                }
            }
        }

        private void dgvTiposHabitacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvTiposHabitacion.Rows[e.RowIndex];

                idTipoSeleccionado = Convert.ToInt32(fila.Cells["IdTipoHabitacion"].Value);
                txtNombreTipo.Text = fila.Cells["Categoria"].Value.ToString();
                nudPrecioBase.Value = Convert.ToDecimal(fila.Cells["Precio x Noche"].Value);
                nudCapacidad.Value = Convert.ToDecimal(fila.Cells["Capacidad (Personas)"].Value);

                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

       

        
      
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreTipo.Text))
            {
                MessageBox.Show("El nombre del tipo de habitación no puede estar vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return;
            }

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO TiposHabitacion (NombreTipo, PrecioBase, CapacidaMaxima) VALUES (@nombre, @precio, @capacidad)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombreTipo.Text.Trim());
                        cmd.Parameters.AddWithValue("@precio", nudPrecioBase.Value);
                        cmd.Parameters.AddWithValue("@capacidad", nudCapacidad.Value);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Tipo de habitación guardado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTiposHabitacion();
                        LimpiarCampos();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar tipo de habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (idTipoSeleccionado == 0)
            {
                return;
            }

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "UPDATE TiposHabitacion SET NombreTipo = @nombre, PrecioBase = @precio, CapacidadMaxima = @capacidad WHERE IdTipoHabitacion = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombreTipo.Text.Trim());
                        cmd.Parameters.AddWithValue("@precio", nudPrecioBase.Value);
                        cmd.Parameters.AddWithValue("@capacidad", nudCapacidad.Value);
                        cmd.Parameters.AddWithValue("@id", idTipoSeleccionado);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Tipo de habitación actualizado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTiposHabitacion();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar tipo de habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idTipoSeleccionado == 0)
            {
                return;
            }
            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar este tipo de habitación?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No) { return; }

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string queryValidar = "SELECT COUNT(*) FROM Habitaciones WHERE IdTipoHabitacion = @id";

                    using (SQLiteCommand cmdValidar = new SQLiteCommand(queryValidar, conexion))
                    {
                        cmdValidar.Parameters.AddWithValue("@id", idTipoSeleccionado);
                        int enUso = Convert.ToInt32(cmdValidar.ExecuteScalar());

                        if (enUso > 0)
                        {
                            MessageBox.Show($"No se puede eliminar. Existe {enUso} habitacion(es) registradas con esta categoria.", "Operacion Bloqueada", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    string queryDelete = "DELETE FROM TiposHabitacion WHERE IdTipoHabitacion = @id";
                    using (SQLiteCommand cmdDelete = new SQLiteCommand(queryDelete, conexion))
                    {
                        cmdDelete.Parameters.AddWithValue("@id", idTipoSeleccionado);
                        cmdDelete.ExecuteNonQuery();

                        MessageBox.Show("Tipo de habitación eliminado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        CargarTiposHabitacion();
                        LimpiarCampos();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar tipo de habitación:  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtNombreTipo.Clear();
            nudPrecioBase.Value = 0;
            nudCapacidad.Value = 1;
            idTipoSeleccionado = 0;
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }
    }
}