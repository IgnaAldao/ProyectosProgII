using Practico02_Back.Entities.DTOs;
using Practico02_Back.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico02_Back.Data
{
    public interface IFacturaRepository
    {
        List<Factura> GetFacturas();
        List<Factura> GetFacturaFilter(DateTime? fecha, int? formaPago);
        bool AddFactura(FacturaDTO factura);
        bool RemoveFactura(int nro);
        bool UpdateFactura(Factura factura);
    }
}
