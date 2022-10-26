namespace ProyectoFinal.Repository
{
    public class Producto
    {
        public int id;
        public string Descripcion;
        public double Costo;
        public double PrecioVenta;
        public int Stock;
        public int IdUsuario;

        public Producto()
        {
            id = 0;
            Descripcion = String.Empty;
            Costo = 0;
            PrecioVenta = 0;
            Stock = 0;
            IdUsuario = 0;
        }
    }
}
