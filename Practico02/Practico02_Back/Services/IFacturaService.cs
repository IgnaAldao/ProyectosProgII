using Practico02_Back.Entities;
using Practico02_Back.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico02_Back.Services
{
    public interface IFacturaService
    {
        List<Factura> GetFacturas();
        bool AddFactura(FacturaDTO factura);
        bool DeleteFactura(int nro);
        bool UpdateFactura(Factura factura);
        List<Factura> GetFactura(DateTime? fecha, int? formaPago);
    }
}
