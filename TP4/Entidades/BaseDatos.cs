using System;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    /// <summary>
    /// Clase estatica para el acceso a la base de datos tp4_ventas
    /// </summary>
    public static class BaseDatos
    {
        #region ATRIBUTOS
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region CONSTRUCTORES
        static BaseDatos()
        {
            BaseDatos.conexion = new SqlConnection(Properties.Settings.Default.CadenaDeConexion);
            BaseDatos.comando = new SqlCommand();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Obtiene la lista completa de productos de la tabla Productos
        /// </summary>
        /// <returns>Datatable que contiene todos productos</returns>
        public static DataTable ObtenerProductos()
        {
            DataTable dt;

            try
            {
                dt = new DataTable("Productos");

                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Marca", typeof(string));
                dt.Columns.Add("Precio", typeof(double));
                dt.Columns.Add("Tipo", typeof(string));
                dt.Columns.Add("Material", typeof(string));
                dt.Columns.Add("Vencimiento", typeof(DateTime));

                dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("SELECT * FROM dbo.Productos", BaseDatos.conexion);
                da.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }

            return dt;
        }

        /// <summary>
        /// Inserta una venta en la base de datos.
        /// </summary>
        /// <param name="v"> Venta a insertar </param>
        /// <returns></returns>
        public static void InsertarVenta(Venta<Producto> v)
        {
            string sqlQuery = "INSERT INTO dbo.Ventas (factura, fecha, cliente, total, estado) " +
                "VALUES ('" + v.factura + "', '" + v.FechaVenta.ToString("yyyy-MM-dd hh:ss") + "', '" + v.cliente + "', '" + v.TotalVenta.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "', '" + v.Estado.ToString() + "')";

            try
            {
                BaseDatos.comando.CommandType = CommandType.Text;
                BaseDatos.comando.CommandText = sqlQuery;
                BaseDatos.comando.Connection = BaseDatos.conexion;

                BaseDatos.conexion.Open();
                BaseDatos.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                BaseDatos.conexion.Close();
            }
        }

        /// <summary>
        /// Actualiza en la base de datos el estado de la venta  pasada como parametro.
        /// </summary>
        /// <param name="v"> Venta a actualizar </param>
        /// <returns></returns>
        public static void ActualizarEstadoVenta(Venta<Producto> v)
        {
            string sqlQuery = "UPDATE dbo.Ventas SET estado = '" + v.Estado.ToString() + "' WHERE factura = " + v.factura; 
            try
            {
                BaseDatos.comando.CommandType = CommandType.Text;
                BaseDatos.comando.CommandText = sqlQuery;
                BaseDatos.comando.Connection = BaseDatos.conexion;

                BaseDatos.conexion.Open();
                BaseDatos.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                BaseDatos.conexion.Close();
            }
        }
        #endregion
    }
}