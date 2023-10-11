using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion
{
    public class VentaData
    {
        #region Venta
        public static void CrearVenta(Venta venta)
        {
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "INSERT INTO Producto (Comentarios, IdUsuario)" +
                " VALUES(@Comentarios, @IdUsuario); ";

            try
            {
                using SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = venta.IdUsuario });

                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static void ModificarVenta(Venta venta)
        {
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "UPDATE Producto " +
                "SET Comentarios = @Comentarios, IdUsuario=@IdUsuario " +
                " WHERE Id = @Id";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = venta.Id });

                        comando.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });
                        comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = venta.IdUsuario });

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

        public static void EliminarProducto(Venta venta)
        {
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "DELETE FROM Venta " +
                " WHERE Id = @Id";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = venta.Id });

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

        public static List<Venta> ListarVentas()
        {
            List<Venta> lista = new List<Venta>();
            // Importante: Para que funcione
            // Modifica el parametro Server por el de tu Servidor
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "SELECT Id,Comentarios,IdUsuario FROM Venta";

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
                                    var venta = new Venta();
                                    venta.Id = Convert.ToInt32(dr["Id"]);
                                    venta.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                    lista.Add(venta);
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
