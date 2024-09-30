using BackPractico04.Data.Models;
using BackPractico04.Data.Models.Daos;
using BackPractico04.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practico04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnoService _turnoService;

        public TurnosController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }

        // GET: api/turnos
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var turnos = _turnoService.GetAllTurnos();
                if (turnos.Any())
                    return Ok(turnos);
                return NotFound("No hay turnos disponibles.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente nuevamente.");
            }
        }

        // GET: api/turnos/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var turno = _turnoService.GetTurnoById(id);
                if (turno != null)
                    return Ok(turno);
                return NotFound("El turno no existe.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente nuevamente.");
            }
        }

        // POST: api/turnos
        [HttpPost]
        public IActionResult Post([FromBody] TurnoCreateDao turno)
        {
            try
            {
                if (turno == null || !ModelState.IsValid)
                    return BadRequest("Datos inválidos.");

                _turnoService.CreateTurno(turno);
                return Ok("Turno creado!!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente nuevamente.");
            }
        }

        // PUT: api/turnos/5
        [HttpPut("{id}")]
        public IActionResult UpdateTurno(int id, [FromBody] TurnoCreateDao turnoDao)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Datos incorrectos!!");
                }

                var turnoExistente = _turnoService.GetTurnoById(id);
                if (turnoExistente == null)
                {
                    return NotFound("El turno no existe.");
                }

                _turnoService.UpdateTurno(id, turnoDao);

                return Ok("Turno actualizado!!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }

        // DELETE: api/turnos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_turnoService.DeleteTurno(id))
                    return Ok("Turno eliminado!!");
                return NotFound("El turno no existe.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente nuevamente.");
            }
        }
    }
}
