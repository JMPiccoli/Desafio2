using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion
{
    public class ProductoVendidoData
    {
        #region ProductoVendido
        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "INSERT INTO ProductoVendido (Stock, IdProducto, IdVenta)" +
                " VALUES(@Stock, @IdProducto, @IdVenta); ";

            try
            {
                using SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Decimal) { Value = productoVendido.Stock });
                    comando.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = productoVendido.IdProducto });
                    comando.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt) { Value = productoVendido.IdVenta });

                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "UPDATE Producto " +
                "SET Stock = @Stock ,IdProducto = @IdProducto, IdVenta = @IdVenta " +
                " WHERE Id = @Id";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = productoVendido.Id });

                        comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Decimal) { Value = productoVendido.Stock });
                        comando.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = productoVendido.IdProducto });
                        comando.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt) { Value = productoVendido.IdVenta });

                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static void EliminarProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "DELETE FROM ProductoVendido " +
                " WHERE Id = @Id";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = productoVendido.Id });

                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();
            // Importante: Para que funcione
            // Modifica el parametro Server por el de tu Servidor
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "SELECT Id,Stock,IdProducto,IdVenta FROM ProductoVendido";

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var productoVendido = new ProductoVendido();
                                    productoVendido.Id = Convert.ToInt32(dr["Id"]);
                                    productoVendido.Stock = Convert.ToInt32(dr["Stock"]);
                                    productoVendido.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                                    productoVendido.IdVenta = Convert.ToInt32(dr["IdVenta"]);

                                    lista.Add(productoVendido);
                                }
                            }
                        }
                    }

                    // Opcional
                    conexion.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
