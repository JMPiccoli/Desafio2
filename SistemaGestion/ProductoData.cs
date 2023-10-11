﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion
{
    public class ProductoData
    {
        #region Producto
        public static void CrearProducto(Producto producto)
        {
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "INSERT INTO Producto (Descripcion,Costo, PrecioVenta,Stock, IdUsuario)" +
                " VALUES(@Descripcion, @Costo, @PrecioVenta, @Stock, @IdUsuario); ";

            try
            {
                using SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.VarChar) { Value = producto.Descripcion });
                    comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Decimal) { Value = producto.Costo });
                    comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Decimal) { Value = producto.PrecioVenta });
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Decimal) { Value = producto.Stock });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario });

                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static void ModificarProducto(Producto producto)
        {
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "UPDATE Producto " +
                "SET Descripciones = @Descripcion ,Costo = @Costo, PrecioVenta = @PrecioVenta,Stock = @Stock, IdUsuario=@IdUsuario " +
                " WHERE Id = @Id";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = producto.Id });

                        comando.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.VarChar) { Value = producto.Descripcion });
                        comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Decimal) { Value = producto.Costo });
                        comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Decimal) { Value = producto.PrecioVenta });
                        comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Decimal) { Value = producto.Stock });
                        comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario });

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

        public static void EliminarProducto(Producto producto)
        {
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "DELETE FROM Producto " +
                " WHERE Id = @Id";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = producto.Id });

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

        public static List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            // Importante: Para que funcione
            // Modifica el parametro Server por el de tu Servidor
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "SELECT Id,Descripcion,Costo,PrecioVenta,Stock,IdUsuario FROM Producto";

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
                                    var producto = new Producto();
                                    producto.Id = Convert.ToInt32(dr["Id"]);
                                    producto.Descripcion = dr["Descripcion"].ToString();
                                    producto.Costo = Convert.ToDouble(dr["Costo"]);
                                    producto.PrecioVenta = Convert.ToDouble(dr["PrecioVenta"]);
                                    producto.Stock = Convert.ToInt32(dr["Stock"]);
                                    producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                    lista.Add(producto);
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
