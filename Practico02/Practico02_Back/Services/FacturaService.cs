using Practico02_Back.Data;
using Practico02_Back.Entities;
using Practico02_Back.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico02_Back.Services
{
    public class FacturaService : IFacturaService
    {
        public IFacturaRepository repository;

        public FacturaService()
        {
            repository = new FacturaRepository();
        }

        public bool AddFactura(FacturaDTO factura)
        {
            return repository.AddFactura(factura);
        }

        public bool DeleteFactura(int nro)
        {
            return repository.RemoveFactura(nro);
        }

        public List<Factura> GetFactura(DateTime? fecha, int? formaPago)
        {
            return repository.GetFacturaFilter(fecha,formaPago);
        }

        public List<Factura> GetFacturas()
        {
            return repository.GetFacturas();
        }

        public bool UpdateFactura(Factura factura)
        {
            return repository.UpdateFactura(factura);
        }
    }
}
