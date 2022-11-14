using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

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

        public static List<Usuario> MostrarUserPorNombreyContraseña(Usuario usu)
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
                cmd.CommandText = "@SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario and Contraseña = @Contraseña";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   
                    cmd.Parameters.AddWithValue("@NombreUsuario", usu.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", usu.Contraseña);
                    usu.id = Convert.ToInt32(reader.GetValue(0));
                    usu.Nombre = reader.GetValue(1).ToString();
                    usu.Apellido = reader.GetValue(2).ToString();
                    usu.NombreUsuario = reader.GetValue(3).ToString();
                
                    listausuarios.Add(usu);
                    if (listausuarios.Count > 0)
                    {
                        return listausuarios;
                    }
                    else
                    {
                       Console.WriteLine("Usuario o contraseña invalida");
                    }
                }

                return listausuarios;
               
                connection.Close();
            }
        }

        public static List<Usuario> MostrarUserPorNombre(Usuario usu)
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
                cmd.CommandText = "@SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    cmd.Parameters.AddWithValue("@NombreUsuario", usu.NombreUsuario);
                    usu.id = Convert.ToInt32(reader.GetValue(0));
                    usu.Nombre = reader.GetValue(1).ToString();
                    usu.Apellido = reader.GetValue(2).ToString();
                    usu.NombreUsuario = reader.GetValue(3).ToString();

                    listausuarios.Add(usu);
                    if (listausuarios.Count > 0)
                    {
                        return listausuarios;
                    }
                    else
                    {
                        Console.WriteLine("Usuario o contraseña invalida");
                    }
                }

                return listausuarios;

                connection.Close();
            }
        }


        public static bool InsertUsuario(Usuario usuario)
        {

            bool insert = false;
            Usuario usuarioRepetido = MostrarUserPorNombre(usuario.NombreUsuario);
            if (usuario.NombreUsuario == null ||
                usuario.NombreUsuario.Trim() == "" ||
                usuario.Contraseña == null ||
                usuario.Contraseña.Trim() == "" ||
                usuario.Nombre == null ||
                usuario.Nombre.Trim() == "" ||
                usuario.Apellido == null ||
                usuario.Apellido.Trim() == "")
            {
                return insert;
                throw new Exception("Faltan datos obligatorios");
            }
            else if (usuarioRepetido.id != 0)
            {
                return insert;
                throw new Exception("El nombre de usuario ya existe");
            }

            else
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


                    insert = usuario.id != 0 ? true : false;
                    connection.Close();
                    return insert;
                }
            }
            
        }

        private static Usuario MostrarUserPorNombre(string nombreUsuario)
        {
            throw new NotImplementedException();
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