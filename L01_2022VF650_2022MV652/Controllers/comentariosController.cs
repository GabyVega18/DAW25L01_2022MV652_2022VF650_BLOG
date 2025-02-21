using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2022VF650_2022MV652.Models;

namespace L01_2022VF650_2022MV652.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class comentariosController : ControllerBase
    {
        private readonly blogDBContext _blogDBContexto;

        public comentariosController(blogDBContext blogDBContexto)
        {
            _blogDBContexto = blogDBContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<comentarios> Listadocomentarios = _blogDBContexto.comentarios.ToList();

            if (Listadocomentarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(Listadocomentarios);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            comentarios? comentario = (from e in _blogDBContexto.comentarios
                                       where e.usuarioId == id
                                       select e).FirstOrDefault();

            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario);

        }
    }
}
