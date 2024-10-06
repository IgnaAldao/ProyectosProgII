using BackPractico04.Data.Models;
using BackPractico04.Data.Models.Daos;
using BackPractico04.Data.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practico04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesController : ControllerBase
    {
        private readonly IDetalleService _detalleTurnoService;

        public DetallesController(IDetalleService detalleTurnoService)
        {
            _detalleTurnoService = detalleTurnoService;
        }

        // GET: api/detalleturno
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var detallesTurno = _detalleTurnoService.GetAllDetalles();
                if (detallesTurno.Any())
                    return Ok(detallesTurno);
                return NotFound("No hay detalles de turno disponibles.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente nuevamente.");
            }
        }

        // GET: api/detalleturno/5/3
        [HttpGet("{idTurno}/{idServicio}")]
        public IActionResult Get(int idTurno, int idServicio)
        {
            try
            {
                var detalleTurno = _detalleTurnoService.GetDetalleById(idTurno, idServicio);
                if (detalleTurno != null)
                    return Ok(detalleTurno);
                return NotFound("El detalle de turno no existe.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente nuevamente.");
            }
        }

        // POST: api/detalleturno
        [HttpPost]
        public IActionResult Post([FromBody] DetalleCreateDao detalleTurno)
        {
            try
            {
                if (detalleTurno == null || !ModelState.IsValid)
                    return BadRequest("Datos inválidos.");

                if(_detalleTurnoService.CreateDetalle(detalleTurno))
                    return Ok("Detalle creado con exito!!");
                return BadRequest("Ya hay cargado este servicio para el turno..");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente nuevamente.");
            }
        }

        // PUT: api/detalleturno/5/3
        [HttpPut]
        public IActionResult Put([FromBody] DetalleCreateDao detalleTurno)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Datos incorrectos!!");
                }

                var turnoExistente = _detalleTurnoService.GetDetalleById(detalleTurno.IdTurno,detalleTurno.IdServicio);
                if (turnoExistente == null)
                {
                    return NotFound("El turno no existe.");
                }

                _detalleTurnoService.UpdateDetalle(detalleTurno);

                return Ok("Turno actualizado!!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }

        // DELETE: api/detalleturno/5/3
        [HttpDelete("{idTurno}/{idServicio}")]
        public IActionResult Delete(int idTurno, int idServicio)
        {
            try
            {
                if (_detalleTurnoService.DeleteDetalle(idTurno, idServicio))
                    return Ok("Detalle eliminado!!");
                return NotFound("El detalle de turno no existe.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente nuevamente.");
            }
        }
    }
}
