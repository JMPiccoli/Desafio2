using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion
{
    public static class UsuarioData
    {
        #region Usuario
        public static void CrearUsuario(Usuario usuario)
        {
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail)" +
                " VALUES(@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail); ";

            try
            {
                using SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                    comando.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                    comando.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    comando.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contrasenia });
                    comando.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail });

                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static void ModificarUsuario(Usuario usuario)
        {
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "UPDATE Usuario " +
                "SET Nombre = @Nombre ,Apellido = @Apellido, NombreUsuario = @NombreUsuario, Contraseña = @Contrasenia, Mail=@Mail " +
                " WHERE Id = @Id";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = usuario.Id });

                        comando.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                        comando.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                        comando.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                        comando.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contrasenia });
                        comando.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail });

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

        public static void EliminarUsuario(Usuario usuario)
        {
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "DELETE FROM Usuario " +
                " WHERE Id = @Id";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("Id", SqlDbType.VarChar) { Value = usuario.Id });

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

        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            // Importante: Para que funcione
            // Modifica el parametro Server por el de tu Servidor
            string connectionString = @"Server=NBK_DELL\SQLEXPRESS2012;DataBase=SistemaGestion;
                                        Trusted_Connection=True";
            string query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario";

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
                                    var usuario = new Usuario();
                                    usuario.Id = Convert.ToInt32(dr["Id"]);
                                    usuario.Nombre = dr["Nombre"].ToString();
                                    usuario.Apellido = Convert.ToString(dr["Apellido"]);
                                    usuario.NombreUsuario = Convert.ToString(dr["NombreUsuario"]);
                                    usuario.Contrasenia = Convert.ToString(dr["Contraseña"]);
                                    usuario.Mail = Convert.ToString(dr["Mail"]);

                                    lista.Add(usuario);
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
