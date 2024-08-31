using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Dominio
{
    public class Factura
    {
        public int NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago FormaPago { get; set; }
        public string Cliente { get; set; }
        public List<DetalleFactura> Detalles { get; set; }  
    }
}
