using Clase_10_09.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clase_10_09.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechaController2 : ControllerBase
    {
        private List<Fecha> fechaList = new List<Fecha>();
        // GET: api/<FechaController2>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(fechaList);
        }

        // GET api/<FechaController2>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FechaController2>
        [HttpPost]
        public IActionResult Post([FromBody] Fecha fecha)
        {
            if (fecha != null)
            {
                fechaList.Add(fecha);
                return Ok("Fecha Agregada!!");
            }
            else
                return BadRequest("Error al cargar la fecha");

        }

        // PUT api/<FechaController2>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FechaController2>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
