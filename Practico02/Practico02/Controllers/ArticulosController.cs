using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practico02_Back.Entities.DTOs;
using Practico02_Back.Entities;
using Practico02_Back.Services;

namespace Practico02WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IArticuloService service;
        public ArticulosController()
        {
            service = new ArticuloService();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lst = service.GetArticulos();
            if (lst.Count > 0)
            {
                return Ok(lst);
            }
            else
                return BadRequest("No hay articulos registrados");
        }

        [HttpPost]
        public IActionResult Post([FromBody] ArticuloDTO articulo)
        {
            try
            {
                if (articulo == null)
                {
                    return BadRequest("Datos incompletos");
                }
                if (service.AddArticulo(articulo))
                    return Ok("Articulo agregado con exito");
                else
                    return BadRequest("Error al cargar el articulo");
            }catch (Exception)
            {
                return StatusCode(500, "Error interno, intentelo nuevamente");
            }
        }

        [HttpDelete("articulos/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (service.RemoveArticulo(id))
                    return Ok($"Articulo {id} eliminado!");
                return BadRequest("Error al eliminar el articulo");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }

        [HttpPut]
        public IActionResult Update(Articulo articulo)
        {
            try
            {
                if (articulo == null)
                    return BadRequest("Datos incompletos");
                if (service.UpdateArticulo(articulo))
                    return Ok("Articulo actualizado!!");
                else
                    return BadRequest("Error al actualizar el articulo");
            }catch (Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }
    }
    
    
}
