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

        [HttpDelete]
        public void EliminarProducto([FromBody] int id)
        {

        }

    }
}
