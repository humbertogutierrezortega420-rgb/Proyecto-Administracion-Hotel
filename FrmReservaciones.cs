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
    public partial class FrmReservaciones : Form
    {
       
            string cadenaConexion = "Data Source=HotelDB.db;Version=3;";

        private int idEmpleadoActual;
        private string nombreEmpleadoActual;

        public FrmReservaciones(int idEmpleado, string nombreEmpleado)
        {
            InitializeComponent();
            this.idEmpleadoActual = idEmpleado;
            this.nombreEmpleadoActual = nombreEmpleado;
        }
        private void FrmReservaciones_Load(object sender, EventArgs e)
        {
            txtEmpleadoActual.Text = nombreEmpleadoActual;

            dtpFechaCheckIn.MinDate = DateTime.Today;
            dtpFechaCheckOut.MinDate = DateTime.Today.AddDays(1);

            CargarClientes();
            CargarHabitacionesDisponibles();
            CargarReservacionesActivas();
        }

        private void CargarClientes()
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT IdCliente, Nombre || ' ' || Apellidos AS NombreCompleto FROM Clientes";
                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    cmbCliente.DataSource = dt;
                    cmbCliente.DisplayMember = "NombreCompleto";
                    cmbCliente.ValueMember = "IdCliente";
                    cmbCliente.SelectedIndex = -1; 
                }
                catch (Exception ex) { MessageBox.Show("Error al cargar clientes: " + ex.Message); }
            }
        }

        private void CargarHabitacionesDisponibles()
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = @"SELECT h.IdHabitacion, h.NumeroHabitacion || ' - ' || t.NombreTipo AS Descripcion 
                                     FROM Habitaciones h
                                     INNER JOIN TiposHabitacion t ON h.IdTipoHabitacion = t.IdTipoHabitacion
                                     WHERE h.Estado = 'Disponible'";

                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    cmbHabitacion.DataSource = dt;
                    cmbHabitacion.DisplayMember = "Descripcion";
                    cmbHabitacion.ValueMember = "IdHabitacion";
                    cmbHabitacion.SelectedIndex = -1;
                }
                catch (Exception ex) { MessageBox.Show("Error al cargar habitaciones: " + ex.Message); }
            }
        }
      

        private void CargarReservacionesActivas()
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = @"SELECT r.IdReserva, c.Nombre || ' ' || c.Apellidos AS Cliente, 
                                            h.NumeroHabitacion AS Habitacion, r.FechaCheckIn, r.FechaCheckOut
                                     FROM Reservaciones r
                                     INNER JOIN Clientes c ON r.IdCliente = c.IdCliente
                                     INNER JOIN Habitaciones h ON r.IdHabitacion = h.IdHabitacion
                                     WHERE r.EstadoReserva = 'Activa'";

                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dgvReservaciones.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Error al cargar reservaciones: " + ex.Message); }
            }
        }

        private void btnCrearReserva_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null || cmbHabitacion.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente y una habitación.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpFechaCheckOut.Value.Date <= dtpFechaCheckIn.Value.Date)
            {
                MessageBox.Show("La fecha de salida debe ser posterior a la fecha de entrada.", "Error en fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = Convert.ToInt32(cmbCliente.SelectedValue);
            int idHabitacion = Convert.ToInt32(cmbHabitacion.SelectedValue);
            string fechaIn = dtpFechaCheckIn.Value.ToString("yyyy-MM-dd");
            string fechaOut = dtpFechaCheckOut.Value.ToString("yyyy-MM-dd");

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    using (SQLiteTransaction transaccion = conexion.BeginTransaction())
                    {
                        string queryReserva = @"INSERT INTO Reservaciones (IdCliente, IdHabitacion, IdEmpleado, FechaCheckIn, FechaCheckOut, EstadoReserva) 
                                                VALUES (@cliente, @habitacion, @empleado, @checkin, @checkout, 'Activa')";
                        using (SQLiteCommand cmdReserva = new SQLiteCommand(queryReserva, conexion, transaccion))
                        {
                            cmdReserva.Parameters.AddWithValue("@cliente", idCliente);
                            cmdReserva.Parameters.AddWithValue("@habitacion", idHabitacion);
                            cmdReserva.Parameters.AddWithValue("@empleado", idEmpleadoActual);
                            cmdReserva.Parameters.AddWithValue("@checkin", fechaIn);
                            cmdReserva.Parameters.AddWithValue("@checkout", fechaOut);
                            cmdReserva.ExecuteNonQuery();
                        }

                        string queryHabitacion = "UPDATE Habitaciones SET Estado = 'Ocupada' WHERE IdHabitacion = @habitacion";
                        using (SQLiteCommand cmdHabitacion = new SQLiteCommand(queryHabitacion, conexion, transaccion))
                        {
                            cmdHabitacion.Parameters.AddWithValue("@habitacion", idHabitacion);
                            cmdHabitacion.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        MessageBox.Show("Check-In realizado con éxito. La habitación ahora está Ocupada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnLimpiar_Click(null, null);
                        CargarHabitacionesDisponibles(); 
                        CargarReservacionesActivas();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear la reservación: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbCliente.SelectedIndex = -1;
            cmbHabitacion.SelectedIndex = -1;
            dtpFechaCheckIn.Value = DateTime.Today;
            dtpFechaCheckOut.Value = DateTime.Today.AddDays(1);
        }
    }
        
}
