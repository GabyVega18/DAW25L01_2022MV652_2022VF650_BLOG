using L01_2022VF650_2022MV652.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            List<calificaciones> Listadocalificacion = (from e in _blogDBContexto.calificaciones
                                                        select e).ToList();
            if (Listadocalificacion.Count == 0)
            {
                return NotFound();
            }

            return Ok(Listadocalificacion);
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

        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarCalificaciones([FromBody] calificaciones calificacion)
        {
            try
            {
                _blogDBContexto.calificaciones.Add(calificacion);
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

        public IActionResult ActualizarCalificaciones(int id, [FromBody] calificaciones calificacionModificar) 
        {
            calificaciones? calificacionActual = (from e in _blogDBContexto.calificaciones
                                            where e.calificacionId == id
             
                                            select e).FirstOrDefault();
            if (calificacionActual == null)
            {  return NotFound(); }

            calificacionActual.publicacionId = calificacionModificar.publicacionId;
            calificacionActual.usuarioId = calificacionModificar.usuarioId;
            calificacionActual.calificacion = calificacionModificar.calificacion;

            _blogDBContexto.Entry(calificacionActual).State = EntityState.Modified;
            _blogDBContexto.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult EliminarEquipo(int id) 
        {
            calificaciones? calificacion = (from e in _blogDBContexto.calificaciones
                                                  where e.calificacionId == id
                                                  select e).FirstOrDefault();
            if(calificacion == null)
                return NotFound();
            _blogDBContexto.calificaciones.Attach(calificacion);
            _blogDBContexto.calificaciones.Remove(calificacion);
            _blogDBContexto.SaveChanges();
            return Ok(calificacion);
        }


    }

}
