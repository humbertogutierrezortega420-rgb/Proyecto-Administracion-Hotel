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
        private int idHabitacionSeleccionada = 0;
        private string estadoActual = "";
        public FrmHabitaciones()
        {
            InitializeComponent();
        }

        private void FrmHabitaciones_Load(object sender, EventArgs e)
        {
            cmbNuevoEstado.Items.AddRange(new string[] { "Disponible", "Limpieza", "Mantenimiento" });
            CargarListaHabitaciones();
        }
        private void CargarListaHabitaciones()
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = @"SELECT h.IdHabitacion, h.NumeroHabitacion AS 'Número', t.NombreTipo AS 'Tipo', h.Estado FROM Habitaciones h INNER JOIN TiposHabitacion t ON h.IdTipoHabitacion = t.IdTipoHabitacion ORDER BY h.NumeroHabitacion";
                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                   
                    dgvHabitaciones.DataSource = dt;
                    dgvHabitaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvHabitaciones.Columns["IdHabitacion"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar tipos de habitación: " + ex.Message);
                }
            }
        }

       
        private void dgvHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvHabitaciones.Rows[e.RowIndex];
                idHabitacionSeleccionada = Convert.ToInt32(fila.Cells["IdHabitacion"].Value);
                estadoActual = fila.Cells["Estado"].Value.ToString();

                txtHabitacionSeleccionada.Text = fila.Cells["Número"].Value.ToString();

                if (estadoActual == "Ocupada")
                {
                    cmbNuevoEstado.Enabled = false;
                    btnActualizarEstado.Enabled = false;
                    lblAviso.Text = "No se puede cambiar el estado de una habitación ocupada.";
                    cmbNuevoEstado.SelectedIndex = -1;
                }
                else
                {
                    cmbNuevoEstado.Enabled = true;
                    btnActualizarEstado.Enabled = true;
                    lblAviso.Text = "";
                    cmbNuevoEstado.SelectedItem = estadoActual;
                }
                
            }
         
        }

        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            if(idHabitacionSeleccionada == 0)
            {
               MessageBox.Show("Seleccione una habitación de la tabla para actualizar su estado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(cmbNuevoEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un nuevo estado para la habitación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string nuevoEstado = cmbNuevoEstado.SelectedItem.ToString();

            if (nuevoEstado == estadoActual)
            {
                MessageBox.Show("El nuevo estado seleccionado es el mismo que el estado actual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using(SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "UPDATE Habitaciones SET Estado = @estado WHERE IdHabitacion = @id";
                    using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@estado", nuevoEstado);
                        comando.Parameters.AddWithValue("@id", idHabitacionSeleccionada);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Estado de la habitación actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        CargarListaHabitaciones();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            idHabitacionSeleccionada = 0;
            estadoActual = "";
            txtHabitacionSeleccionada.Clear(); 
            cmbNuevoEstado.SelectedIndex = -1; 
            cmbNuevoEstado.Enabled = true;
            btnActualizarEstado.Enabled = true;
            
            if(lblAviso != null)lblAviso.Text = "";
            
        }
    }
}
        

