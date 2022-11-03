using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Repository;
using System.Reflection.Metadata.Ecma335;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public IEnumerable<Producto> Get()
        {
            return ADO_Producto.MostrarProdcutos();
        }

        [HttpPost]
        public void Crear([FromBody] Producto producto)
        {
            ADO_Producto.InsertProducto(producto);
        }

        [HttpPut]
        public void Modificar([FromBody] Producto producto)
        {
            ADO_Producto.ModificarProducto(producto);  
        }

        [HttpDelete]
        public void EliminarProducto([FromBody] int id)
        {

        }

    }
}
