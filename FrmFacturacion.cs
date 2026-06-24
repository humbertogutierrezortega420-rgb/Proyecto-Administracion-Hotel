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
    public partial class FrmFacturacion : Form
    {

        private string cadenaConexion = "Data Source=HotelDB.db;Version=3;";
        public FrmFacturacion()
        {
            InitializeComponent();
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            CargarReservasActivas();
            cmbMetodoPago.Items.AddRange(new string[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbMetodoPago.SelectedIndex = 0;
        }
        private void CargarReservasActivas()
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = @"SELECT r.IdReserva, 
                                            'Hab: ' || h.NumeroHabitacion || ' - ' || c.Nombre || ' ' || c.Apellidos AS Informacion
                                     FROM Reservaciones r
                                     INNER JOIN Habitaciones h ON r.IdHabitacion = h.IdHabitacion
                                     INNER JOIN Clientes c ON r.IdCliente = c.IdCliente
                                     WHERE r.EstadoReserva = 'Activa'";

                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    cmbReservasActivas.DataSource = dt;
                    cmbReservasActivas.DisplayMember = "Informacion";
                    cmbReservasActivas.ValueMember = "IdReserva";
                    cmbReservasActivas.SelectedIndex = -1;
                }
                catch (Exception ex) { MessageBox.Show("Error al cargar reservaciones: " + ex.Message); }
            }
        }

        private void cmbReservasActivas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbReservasActivas.SelectedIndex == -1 || cmbReservasActivas.SelectedValue == null)
                {
                    LimpiarCampos();
                    return;
                }

                if (int.TryParse(cmbReservasActivas.SelectedValue.ToString(), out int idReserva))
                {
                    CargarDatosFactura(idReserva);
                }
            }
            catch { }
        }

        private void CargarDatosFactura(int idReserva)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();

                    string queryHospedaje = @"SELECT c.Nombre || ' ' || c.Apellidos AS Huesped, 
                                                     th.PrecioBase, r.FechaCheckIn 
                                              FROM Reservaciones r
                                              INNER JOIN Clientes c ON r.IdCliente = c.IdCliente
                                              INNER JOIN Habitaciones h ON r.IdHabitacion = h.IdHabitacion
                                              INNER JOIN TiposHabitacion th ON h.IdTipoHabitacion = th.IdTipoHabitacion
                                              WHERE r.IdReserva = @idReserva";

                    double montoHospedaje = 0;
                    using (SQLiteCommand cmd = new SQLiteCommand(queryHospedaje, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idReserva", idReserva);
                        using (SQLiteDataReader lector = cmd.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                txtCliente.Text = lector["Huesped"].ToString();

                                DateTime fechaIngreso = Convert.ToDateTime(lector["FechaCheckIn"]);
                                int noches = (DateTime.Today - fechaIngreso.Date).Days;
                                if (noches <= 0) noches = 1; 

                                double precioNoche = Convert.ToDouble(lector["PrecioBase"]);
                                montoHospedaje = noches * precioNoche;

                                txtSubtotalHospedaje.Text = montoHospedaje.ToString("F2");
                            }
                        }
                    }

                    string queryConsumos = @"SELECT s.NombreServicio AS 'Concepto', 
                                                    c.Cantidad AS 'Cant.', 
                                                    s.Precio AS 'Precio Unitario', 
                                                    (c.Cantidad * s.Precio) AS 'Subtotal'
                                             FROM Consumos c
                                             INNER JOIN ServiciosExtra s ON c.IdServicio = s.IdServicio
                                             WHERE c.IdReserva = @idReserva";

                    SQLiteCommand cmdConsumos = new SQLiteCommand(queryConsumos, conexion);
                    cmdConsumos.Parameters.AddWithValue("@idReserva", idReserva);
                    SQLiteDataAdapter adaptador = new SQLiteDataAdapter(cmdConsumos);
                    DataTable dtConsumos = new DataTable();
                    adaptador.Fill(dtConsumos);

                    dgvDesgloseConsumos.DataSource = dtConsumos;
                    dgvDesgloseConsumos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    double montoConsumos = 0;
                    foreach (DataRow fila in dtConsumos.Rows)
                    {
                        montoConsumos += Convert.ToDouble(fila["Subtotal"]);
                    }
                    txtSubtotalConsumos.Text = montoConsumos.ToString("F2");

                    double total = montoHospedaje + montoConsumos;
                    txtTotalPagar.Text = total.ToString("F2");
                }
                catch (Exception ex) { MessageBox.Show("Error al cargar datos: " + ex.Message); }
            }
        }


        private int ObtenerSiguienteIdFacturaSecuencial(SQLiteConnection conexion)
        {
            string query = "SELECT IdFactura FROM Facturas ORDER BY IdFactura";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
            using (SQLiteDataReader lector = cmd.ExecuteReader())
            {
                int idEsperado = 1;
                while (lector.Read())
                {
                    if (Convert.ToInt32(lector["IdFactura"]) != idEsperado) return idEsperado;
                    idEsperado++;
                }
                return idEsperado;
            }
        }

        private void LimpiarCampos()
        {
            if (txtCliente != null) txtCliente.Clear();
            if (txtSubtotalHospedaje != null) txtSubtotalHospedaje.Clear();
            if (txtSubtotalConsumos != null) txtSubtotalConsumos.Clear();
            if (txtTotalPagar != null) txtTotalPagar.Clear();
            if (dgvDesgloseConsumos.DataSource != null) ((DataTable)dgvDesgloseConsumos.DataSource).Clear();
        }

        private void btnFinalizarCheckOut_Click(object sender, EventArgs e)
        {
            if (cmbReservasActivas.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione una cuenta activa para liquidar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idReserva = Convert.ToInt32(cmbReservasActivas.SelectedValue);

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();
                using (SQLiteTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        int nuevoFolioFactura = ObtenerSiguienteIdFacturaSecuencial(conexion);

                        string queryFactura = @"INSERT INTO Facturas (IdFactura, IdReserva, FechaEmision, SubtotalHabitacion, SubtotalConsumos, Total, MetodoPago)
                                                VALUES (@idFactura, @idReserva, @fecha, @subHospedaje, @subConsumos, @total, @metodo)";

                        using (SQLiteCommand cmdFactura = new SQLiteCommand(queryFactura, conexion, transaccion))
                        {
                            cmdFactura.Parameters.AddWithValue("@idFactura", nuevoFolioFactura);
                            cmdFactura.Parameters.AddWithValue("@idReserva", idReserva);
                            cmdFactura.Parameters.AddWithValue("@fecha", DateTime.Today.ToString("yyyy-MM-dd"));

                            cmdFactura.Parameters.AddWithValue("@subHospedaje", Convert.ToDouble(txtSubtotalHospedaje.Text));
                            cmdFactura.Parameters.AddWithValue("@subConsumos", Convert.ToDouble(txtSubtotalConsumos.Text));
                            cmdFactura.Parameters.AddWithValue("@total", Convert.ToDouble(txtTotalPagar.Text));
                            cmdFactura.Parameters.AddWithValue("@metodo", cmbMetodoPago.SelectedItem.ToString());

                            cmdFactura.ExecuteNonQuery();
                        }

                        string queryReserva = "UPDATE Reservaciones SET EstadoReserva = 'Completada', FechaCheckOut = @fechaOut WHERE IdReserva = @idReserva";
                        using (SQLiteCommand cmdReserva = new SQLiteCommand(queryReserva, conexion, transaccion))
                        {
                            cmdReserva.Parameters.AddWithValue("@fechaOut", DateTime.Today.ToString("yyyy-MM-dd"));
                            cmdReserva.Parameters.AddWithValue("@idReserva", idReserva);
                            cmdReserva.ExecuteNonQuery();
                        }

                        string queryHabitacion = @"UPDATE Habitaciones SET Estado = 'Disponible' 
                                                   WHERE IdHabitacion = (SELECT IdHabitacion FROM Reservaciones WHERE IdReserva = @idReserva)";
                        using (SQLiteCommand cmdHab = new SQLiteCommand(queryHabitacion, conexion, transaccion))
                        {
                            cmdHab.Parameters.AddWithValue("@idReserva", idReserva);
                            cmdHab.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        MessageBox.Show($"Check-Out procesado con éxito.\nFolio de Factura Generado: #{nuevoFolioFactura}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarReservasActivas();
                        LimpiarCampos();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        MessageBox.Show("Ocurrió un problema al procesar el cierre de cuenta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
