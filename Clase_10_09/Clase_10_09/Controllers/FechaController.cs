using Clase_10_09.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clase_10_09.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechaController : ControllerBase
    {

        private string[] DiaSemana;

        public FechaController()
        {
            DiaSemana = new string[] { "Dom" , "Lun", "Mar", "Mie", "Jue", "Vie", "Sab"};
        }
        [HttpGet]// rute por defecto
       public IActionResult Get()
        {
            var fec = DateTime.Now;
            var value = new Fecha()
            {
                Numero = fec.Day,
                Dia = DiaSemana[(int)fec.DayOfWeek - 1],
                Mes = fec.Month,
                Anio = fec.Year,
            };



            return Ok(value);
        } 
    }
}
