using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practico02_Back.Data;
using Practico02_Back.Entities;
using Practico02_Back.Entities.DTOs;
using Practico02_Back.Services;

namespace Practico02WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private IFacturaService service;
        public FacturasController()
        {
            service = new FacturaService();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lst = service.GetFacturas();
                if (lst != null)
                {
                    return Ok(lst);
                }
                else
                    return NotFound("No existen facturas");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] FacturaDTO value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest("Datos incompletos");
                }
                if (service.AddFactura(value))
                    return Ok("Factura agregada con exito");
                else
                    return BadRequest("Error al cargar la factura");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }

        [HttpDelete("facturas/{nro}")]
        public IActionResult Delete(int nro)
        {
            try
            {
                if (service.DeleteFactura(nro))
                    return Ok($"Factura {nro} eliminado!");
                return BadRequest("Error al eliminar la factura");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }

        [HttpPut]
        public IActionResult Update(Factura factura)
        {
            try
            {
                if (factura == null)
                    return BadRequest("Datos incompletos");
                if (service.UpdateFactura(factura))
                    return Ok("Factura actualizado!!");
                else
                    return BadRequest("Error al actualizar la factura");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }

        [HttpGet("facturas")] 
        public IActionResult GetFacturas([FromQuery] DateTime? fecha, [FromQuery] int? formaPago)
        {
            try
            {
                var lst = service.GetFactura(fecha, formaPago);
                if (lst != null && lst.Count == 0)
                    return NotFound("No se encontraron facturas para los filtros indicados");
                return Ok(lst);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intentalo nuevamente");
            }
        }
    }
}
