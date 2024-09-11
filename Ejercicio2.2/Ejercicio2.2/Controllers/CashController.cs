using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ejercicio2._2.Models;

namespace Ejercicio2._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cashcontroller : ControllerBase
    {
        private static readonly List<Moneda> lst = new List<Moneda>();

        [HttpPost]
        public IActionResult Post( [FromBody] Moneda moneda)
        {
            if (moneda != null || !string.IsNullOrEmpty(moneda.Nombre))
            {
                lst.Add(moneda);
                return Ok("Moneda Registrada!!");
            }
            else return BadRequest("Datos Incorrectos!");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(lst);
        }

        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            
            if (!string.IsNullOrEmpty(nombre))
            {
                foreach (Moneda moneda in lst)
                {
                    if (moneda.Nombre == nombre)
                        return Ok(moneda);
                }
                return BadRequest("Moneda no encontrada");
            }
            else 
                return BadRequest("Ingrese un nombre!!");

             
        }
        
    }
}
