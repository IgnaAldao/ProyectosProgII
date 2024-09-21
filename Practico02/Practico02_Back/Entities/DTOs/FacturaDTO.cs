using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico02_Back.Entities.DTOs
{
    public class FacturaDTO
    {
        public DateTime Fecha { get; set; }
        public int FormaPago { get; set; }
        public string Cliente { get; set; }
    }
}
