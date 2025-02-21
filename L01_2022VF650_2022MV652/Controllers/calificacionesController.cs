using L01_2022VF650_2022MV652.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace L01_2022VF650_2022MV652.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class calificacionesController : ControllerBase
    {
        private readonly blogDBContext _blogDBContexto;

        public calificacionesController(blogDBContext blogDBContexto)
        {
            _blogDBContexto = blogDBContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<calificaciones> Listadocalificaciones = _blogDBContexto.calificaciones.ToList();

            if (Listadocalificaciones.Count == 0)
            {
                return NotFound();
            }

            return Ok(Listadocalificaciones);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            calificaciones? calificacion = (from e in _blogDBContexto.calificaciones
                                            where e.calificacionId == id
                                            select e).FirstOrDefault();

            if (calificacion == null)
            {
                return NotFound();
            }

            return Ok(calificacion);
        }
    }
}
