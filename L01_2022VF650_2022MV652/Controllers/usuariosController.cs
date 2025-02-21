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
    }
}
