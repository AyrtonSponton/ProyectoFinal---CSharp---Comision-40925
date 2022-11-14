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

        [HttpGet(Name = "{nombreUsuario}/{contraseña}")]
        public IEnumerable<Usuario> GetNombreyContraseña([FromBody] Usuario usu)
        {
            return ADO_Usuario.MostrarUserPorNombreyContraseña(usu);
        }

        [HttpGet(Name = "{nombreUsuario}")]
        public IEnumerable<Usuario> GetNombre([FromBody] Usuario usu)
        {
            return ADO_Usuario.MostrarUserPorNombre(usu);
        }

        [HttpDelete]
        public void Eliminar([FromBody] Usuario usu)
        {
            ADO_Usuario.Delete(usu);
        }

        [HttpPut]
        public void Actualizar([FromBody] Usuario usu)
        {
            ADO_Usuario.Update(usu);

        }

        [HttpPost]
        public void Crear([FromBody] Usuario usu)
        {

            ADO_Usuario.InsertUsuario(usu);

        }

    }
}
