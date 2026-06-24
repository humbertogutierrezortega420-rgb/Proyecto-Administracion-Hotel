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
    public partial class FrmConsumos : Form
    {
        string cadenaConexion = "Data Source=HotelDB.db;Version=3;";
        public FrmConsumos()
        {
            InitializeComponent();
        }

        private void FrmConsumos_Load(object sender, EventArgs e)
        {
            CargarReservasActivas();
            CargarServiciosExtra();
        }

        private void CargarReservasActivas()
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = @"SELECT r.IdReserva, 
                                            h.NumeroHabitacion || ' - ' || c.Nombre || ' ' || c.Apellidos AS Detalle
                                     FROM Reservaciones r
                                     INNER JOIN Habitaciones h ON r.IdHabitacion = h.IdHabitacion
                                     INNER JOIN Clientes c ON r.IdCliente = c.IdCliente
                                     WHERE r.EstadoReserva = 'Activa'";

                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    cmbReservaActiva.DataSource = dt;
                    cmbReservaActiva.DisplayMember = "Detalle";
                    cmbReservaActiva.ValueMember = "IdReserva";
                    cmbReservaActiva.SelectedIndex = -1;
                }
                catch (Exception ex) { MessageBox.Show("Error al cargar reservas: " + ex.Message); }
            }
        }

        private void CargarServiciosExtra()
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT IdServicio, NombreServicio, Precio FROM ServiciosExtra";
                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    cmbServicios.DataSource = dt;
                    cmbServicios.DisplayMember = "NombreServicio";
                    cmbServicios.ValueMember = "IdServicio";
                    cmbServicios.SelectedIndex = -1;
                }
                catch (Exception ex) { MessageBox.Show("Error al cargar servicios: " + ex.Message); }
            }
        }

        private void cmbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServicios.SelectedIndex != -1 && cmbServicios.SelectedItem is DataRowView fila)
            {
                txtPrecio.Text = fila["Precio"].ToString();
            }
            else
            {
                txtPrecio.Clear();
            }
        }

        private void cmbReservaActiva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReservaActiva.SelectedIndex != -1 && cmbReservaActiva.SelectedValue is long idReserva)
            {
                CargarHistorialConsumos(Convert.ToInt32(idReserva));
            }
            else
            {
                if (dgvConsumos.DataSource != null) ((DataTable)dgvConsumos.DataSource).Clear();
            }
        }

        private void CargarHistorialConsumos(int idReserva)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = @"SELECT c.IdConsumo AS 'Folio', 
                                            s.NombreServicio AS 'Servicio / Producto', 
                                            c.Cantidad, 
                                            s.Precio AS 'Precio Unitario', 
                                            (c.Cantidad * s.Precio) AS 'Subtotal',
                                            c.FechaConsumo AS 'Fecha'
                                     FROM Consumos c
                                     INNER JOIN ServiciosExtra s ON c.IdServicio = s.IdServicio
                                     WHERE c.IdReserva = @idReserva";

                    SQLiteCommand comando = new SQLiteCommand(query, conexion);
                    comando.Parameters.AddWithValue("@idReserva", idReserva);
                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(comando);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    dgvConsumos.DataSource = dt;
                    dgvConsumos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex) { MessageBox.Show("Error al cargar tabla: " + ex.Message); }
            }
        }

        private int ObtenerSiguienteIdSecuencial(SQLiteConnection conexion)
        {
            string query = "SELECT IdConsumo FROM Consumos ORDER BY IdConsumo";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
            using (SQLiteDataReader lector = cmd.ExecuteReader())
            {
                int idEsperado = 1;
                while (lector.Read())
                {
                    if (Convert.ToInt32(lector["IdConsumo"]) != idEsperado) return idEsperado;
                    idEsperado++;
                }
                return idEsperado;
            }
        }

        private void btnAgregarConsumo_Click(object sender, EventArgs e)
        {
            if (cmbReservaActiva.SelectedValue == null || cmbServicios.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una habitación y un servicio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    int idSecuencial = ObtenerSiguienteIdSecuencial(conexion);

                    string query = @"INSERT INTO Consumos (IdConsumo, IdReserva, IdServicio, Cantidad) 
                                     VALUES (@idConsumo, @reserva, @servicio, @cantidad)";

                    using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@idConsumo", idSecuencial);
                        comando.Parameters.AddWithValue("@reserva", Convert.ToInt32(cmbReservaActiva.SelectedValue));
                        comando.Parameters.AddWithValue("@servicio", Convert.ToInt32(cmbServicios.SelectedValue));
                        comando.Parameters.AddWithValue("@cantidad", Convert.ToInt32(nudCantidad.Value));

                        comando.ExecuteNonQuery();
                        MessageBox.Show("Cargo registrado en la cuenta de la habitación.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmbServicios.SelectedIndex = -1;
                        nudCantidad.Value = 1;
                        CargarHistorialConsumos(Convert.ToInt32(cmbReservaActiva.SelectedValue));
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbReservaActiva.SelectedIndex = -1;
            cmbServicios.SelectedIndex = -1;
            txtPrecio.Clear();
            nudCantidad.Value = 1;
        }
    }
}
