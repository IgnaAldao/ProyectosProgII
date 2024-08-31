using Practica01.Datos;
using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Servicios
{
    public class FacturaServices
    {
        private IFacturaRepository _repositorio;

        public FacturaServices()
        {
            _repositorio = new FacturaRepositoryADO();
        }
        public List<Factura> GetFacturas()
        {
            return _repositorio.GetAll();
        }
        public Factura GetFacturaById(int id)
        {
            return _repositorio.Get(id);
        }
        public bool UpdateFactura(int facturaId, DateTime? nuevaFecha = null, int? nuevaFormaPagoId = null, string? nuevoCliente = null)
        {
            return _repositorio.Update(facturaId, nuevaFecha, nuevaFormaPagoId, nuevoCliente);
        }
        public bool DeleteFactura(int facturaId)
        {
            return _repositorio.Delete(facturaId);
        }
        public bool AddFactura(Factura factura)
        {
            return _repositorio.Add(factura);
        }
    }
}
