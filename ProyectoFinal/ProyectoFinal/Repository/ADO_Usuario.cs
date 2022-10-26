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
    }
}