using Clase_24_09.Models;
using Clase_24_09.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clase_24_09.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<UsuariosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno ,intentalo nuevamente");
            }
            
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var usu = _repository.GetById(id);
                if (usu == null)
                {
                    return NotFound("Usuario no encontrado!!");
                }
                else return Ok(usu);
            }catch (Exception)
            {
                return StatusCode(500, "Error interno ,intentalo nuevamente");
            }
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioDTO value)
        {
            try
            {
                if (!isValid(value))
                {
                    _repository.Create(value);
                    return Ok("Usuario creado!!");
                }
                else return BadRequest("Valores incorrectos!!");
            }catch (Exception)
            {
                return StatusCode(500, "Error Interno, intentalo nuevamente");
            }
        }

        private bool isValid(UsuarioDTO value)
        {
            return String.IsNullOrEmpty(value.Nombre) && String.IsNullOrEmpty(value.Clave) && value.Activo == null
                && value.IdRol == null;
        }
        [HttpGet("/usuarios")]
        public IActionResult GetFilter(int id)
        {
            try
            {
                List<Usuario> usu = _repository.GetByFilters(id);
                if (usu == null)
                {
                    return NotFound("Usuario no encontrado!!");
                }
                else return Ok(usu);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno ,intentalo nuevamente");
            }
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok("Usuario borrado!!");

            }catch(Exception)
            {
                return StatusCode(500, "Error Interno, intentalo nuevamente");
            }
        }
    }
}
