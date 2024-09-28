using BackPractico04.Data.Models;
using BackPractico04.Data.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practico04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServicioService _servicioService;
        public ServiciosController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }
        // GET: api/<ServiciosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lst = _servicioService.GetAllServicios();
                if (lst.Count != 0)
                    return Ok(lst);
                else return NotFound("No hay servicio creados");
            }
            catch(Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var servicio = _servicioService.GetServicioById(id);
                if (servicio != null)
                    return Ok(servicio);
                return NotFound("Servicio no encontrado..");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public IActionResult Post([FromBody] TServicio value)
        {
            try
            {
                if (esValido(value))
                {
                    _servicioService.CreateServicio(value);
                    return Ok("Servicio actualizado/agregado!!");
                }
                return BadRequest("Datos incorrectos, verifique..");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }

        private bool esValido(TServicio value)
        {
            return !(String.IsNullOrEmpty(value.EnPromocion) && String.IsNullOrEmpty(value.Nombre) && value.Costo == null);
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_servicioService.DeleteServicio(id))
                    return Ok("Servicio Eliminado!!");
                return NotFound("El servicio no existe..");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }
    }
}
