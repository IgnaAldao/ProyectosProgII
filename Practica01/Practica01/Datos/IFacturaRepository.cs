using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public interface IFacturaRepository
    {
        bool Add(Factura factura);
        Factura Get(int numFactura);
        List<Factura> GetAll();
        bool Update(int facturaId, DateTime? nuevaFecha = null, int? nuevaFormaPagoId = null, string? nuevoCliente = null);
        bool Delete(int numFactura);
    }
}
