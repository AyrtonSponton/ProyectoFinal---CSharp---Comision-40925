using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public class ADO_Producto
    {
        public static List<Producto> MostrarProdcutos()
        {
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KOQ4I96";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var CS = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(CS))
            {
                List<Producto> listaproductos = new List<Producto>();
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from Producto";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var produc = new Producto();
                    produc.id = Convert.ToInt32(reader.GetValue(0));
                    produc.Descripcion = reader.GetValue(1).ToString();
                    produc.Costo = Convert.ToDouble(reader.GetValue(2));
                    produc.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                    produc.Stock = Convert.ToInt32(reader.GetValue(4));
                    produc.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    listaproductos.Add(produc);

                }
                return listaproductos;
                connection.Close();
            }
        }

        public static void InsertProducto(Producto producto)
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
                cmd.CommandText = @"INSERT INTO Producto
                                    ([Descripcion]
                                    ,[Costo]
                                    ,[PrecioVenta]
									,[Stock]
									,[IdUsuario] )
                                    VALUES
                                    (@Descripcion,
                                        @Costo,
                                        @PrecioVenta,
										@Stock,
										@IdUsuario)"; ;
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@Costo", producto.Costo);
                cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                cmd.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        public static bool ModificarProducto(Producto producto)
        {
            bool modificar = false;
            if (producto.Descripcion == null ||
                producto.Descripcion == "" ||
                producto.IdUsuario == 0)
            {
                return modificar;
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
                    cmd.CommandText = @"UPDATE Producto
                                    SET 
                                    Descripcion = @Descripcion,
                                    Costo = @Costo,
                                    PrecioVenta = @PrecioVenta,
								    Stock = @Stock,
								    IdUsuario = @IdUsuario
                                    WHERE Descripcion = @Descripcion";
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Costo", producto.Costo);
                    cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return modificar;
                }

            }
        }
    }
}
