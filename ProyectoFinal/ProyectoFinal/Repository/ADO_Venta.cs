using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public class ADO_Venta
    {
        public static List<Venta> MostrarVentas()
        {
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KOQ4I96";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var CS = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(CS))
            {
                List<Venta> listaventas = new List<Venta>();
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from Venta";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var venta = new Venta();
                    venta.id = Convert.ToInt32(reader.GetValue(0));
                    venta.Comentarios = reader.GetValue(1).ToString();
                    venta.IdUsuario = Convert.ToInt32(reader.GetValue(2));

                    listaventas.Add(venta);

                }
                return listaventas;
                connection.Close();
            }
        }
    }
}
