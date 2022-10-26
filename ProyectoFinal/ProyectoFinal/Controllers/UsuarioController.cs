using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Repository;
using System.Reflection.Metadata.Ecma335;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsusarios")]
        public IEnumerable<Usuario> Get()
        {
            return ADO_Usuario.MostrarUsuarios();
        }


        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {

        }

        [HttpPut]
        public void Actualizar([FromBody] Usuario usu)
        {

        }

        [HttpPost]
        public void Crear([FromBody] Usuario usu) 
        {
            
        } 

    }
}
