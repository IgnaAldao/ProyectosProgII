using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico02_Back.Entities
{
    public class Factura
    {
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int FormaPago { get; set; }
        public string Cliente { get; set; } 
    }
}
