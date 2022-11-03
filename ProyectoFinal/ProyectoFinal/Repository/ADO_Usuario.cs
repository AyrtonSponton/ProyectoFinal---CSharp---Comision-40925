using System;
using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public class ADO_Usuario
    {
        public static List<Usuario> MostrarUsuarios()
        {
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KOQ4I96";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var CS = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(CS))
            {
                List<Usuario> listausuarios = new List<Usuario>();
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from usuario";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var usu = new Usuario();
                    usu.id = Convert.ToInt32(reader.GetValue(0));
                    usu.Nombre = reader.GetValue(1).ToString();
                    usu.Apellido = reader.GetValue(2).ToString();
                    usu.NombreUsuario = reader.GetValue(3).ToString();
                    usu.Contraseña = reader.GetValue(4).ToString();
                    usu.Mail = reader.GetValue(5).ToString();

                    listausuarios.Add(usu);

                }
                return listausuarios;
                connection.Close();
            }
        }

        public static void InsertUsuario(Usuario usuario)
        {
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KOQ4I96";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var CS = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(CS))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"INSERT INTO Usuario
                                    ([Nombre]
                                    ,[Apellido]
                                    ,[NombreUsuario]
									,[Contraseña]
									,[Mail] )
                                    VALUES
                                    (@Nombre,
                                        @Apellido,
                                        @NombreUsuario,
										@Contraseña,
										@Mail)"; ;             
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    cmd.Parameters.AddWithValue("@Mail", usuario.Mail);

                    cmd.ExecuteNonQuery();
                    connection.Close();

            }
        }

        public static void Update(Usuario usuario)
        {

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KOQ4I96";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var CS = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(CS))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @" UPDATE Usuario
                                                SET 
                                                   Nombre = @Nombre,
                                                   Apellido = @Apellido,
                                                   NombreUsuario = @NombreUsuario,
										           Contraseña = @Contraseña,
										           Mail = @Mail
                                                WHERE id = @ID";
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    cmd.Parameters.AddWithValue("@Mail", usuario.Mail);

                    cmd.ExecuteNonQuery();
                    connection.Close();
            }
        }
        public static void Delete(Usuario usuario)
        {

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KOQ4I96";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var CS = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(CS))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @" DELETE 
                                    Usuario
                                    WHERE 
                                NombreUsuario = @NombreUsuario";

                cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

    
}