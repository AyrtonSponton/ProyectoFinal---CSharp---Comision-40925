using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]
        public IEnumerable<Venta> Get()
        {
            return ADO_Venta.MostrarVentas();
        }

        [HttpPost]
        public void Crear([FromBody] Venta venta)
        {
            ADO_Venta.InsertVenta(venta);
        }
    }
}
