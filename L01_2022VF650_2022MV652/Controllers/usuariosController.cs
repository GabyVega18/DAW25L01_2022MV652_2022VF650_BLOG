using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01_2022VF650_2022MV652.Models;

namespace L01_2022VF650_2022MV652.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly blogDBContext _blogDBContexto;

        public usuariosController(blogDBContext blogDBContexto)
        {
            _blogDBContexto = blogDBContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<usuarios> Listadousuarios = _blogDBContexto.usuarios.ToList();

            if (Listadousuarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(Listadousuarios);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            usuarios? usuario = (from e in _blogDBContexto.usuarios
                                 where e.usuarioId == id
                                 select e).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarUsuario([FromBody] usuarios usuario)
        {
            try
            {
                _blogDBContexto.usuarios.Add(usuario);
                _blogDBContexto.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut]
        [Route("actualizar/{id}")]

        public IActionResult ActualizarUsuario(int id, [FromBody] usuarios usuarioModificar)
        {
            usuarios? usuarioActual = (from e in _blogDBContexto.usuarios
                                 where e.usuarioId == id
                                 select e).FirstOrDefault();

            if (usuarioActual == null)
            { return NotFound(); }

            usuarioActual.nombreUsuario = usuarioModificar.nombreUsuario;
            usuarioActual.clave = usuarioModificar.clave;
            usuarioActual.nombre = usuarioModificar.nombre;
            usuarioActual.apellido = usuarioModificar.apellido;

            _blogDBContexto.Entry(usuarioActual).State = EntityState.Modified;
            _blogDBContexto.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult EliminarUsuario(int id)
        {
            usuarios? usuario = (from e in _blogDBContexto.usuarios
                                       where e.usuarioId == id
                                       select e).FirstOrDefault();
            if (usuario == null)
                return NotFound();
            _blogDBContexto.usuarios.Attach(usuario);
            _blogDBContexto.usuarios.Remove(usuario);
            _blogDBContexto.SaveChanges();
            return Ok(usuario);
        }
    }
}
