using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2022VF650_2022MV652.Models;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarComentarios([FromBody] comentarios comentario)
        {
            try
            {
                _blogDBContexto.comentarios.Add(comentario);
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

        public IActionResult ActualizarComentarios(int id, [FromBody] comentarios comentarioModificar)
        {
            comentarios? comentarioActual = (from e in _blogDBContexto.comentarios
                                                  where e.comentariosId == id

                                                  select e).FirstOrDefault();
            if (comentarioActual == null)
            { return NotFound(); }

            comentarioActual.publicacionId = comentarioModificar.publicacionId;
            comentarioActual.comentario = comentarioModificar.comentario;
            comentarioActual.usuarioId = comentarioModificar.usuarioId;

            _blogDBContexto.Entry(comentarioActual).State = EntityState.Modified;
            _blogDBContexto.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult EliminarComentario(int id)
        {
            comentarios? comentario = (from e in _blogDBContexto.comentarios
                                             where e.comentariosId == id
                                             select e).FirstOrDefault();
            if (comentario == null)
                return NotFound();
            _blogDBContexto.comentarios.Attach(comentario);
            _blogDBContexto.comentarios.Remove(comentario);
            _blogDBContexto.SaveChanges();
            return Ok(comentario);
        }
    }
}
