using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public class ADO_ProductoVendido
    {
        public static List<ProductoVendido> MostrarProdcutosVendidos()
        {
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KOQ4I96";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var CS = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(CS))
            {
                List<ProductoVendido> listavendidos = new List<ProductoVendido>();
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from ProductoVendido";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var vendidos = new ProductoVendido();
                    vendidos.id = Convert.ToInt32(reader.GetValue(0));
                    vendidos.IdProducto = Convert.ToInt32(reader.GetValue(1));
                    vendidos.Stock = Convert.ToInt32(reader.GetValue(2));
                    vendidos.IdVenta = Convert.ToInt32(reader.GetValue(3));


                    listavendidos.Add(vendidos);

                }
                return listavendidos;
                connection.Close();
            }
        }
    }
}
