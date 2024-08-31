using Practica01.Dominio;
using Practica01.Servicios;
using System;
using System.Collections.Generic;

namespace Practica01
{
    class Program
    {
        static void Main(string[] args)
        {
            FacturaServices facturaServices = new FacturaServices();

            Articulo articulo1 = new Articulo { Id = 1, Nombre = "Producto A", PrecioUnitario = 100 };
            Articulo articulo2 = new Articulo { Id = 2, Nombre = "Producto B", PrecioUnitario = 200 };

            List<DetalleFactura> detalles = new List<DetalleFactura>
            {
                new DetalleFactura { Articulo = articulo1, Cantidad = 2 },
                new DetalleFactura { Articulo = articulo2, Cantidad = 1 }
            };

            FormaPago formaPago = new FormaPago { Id = 1, Nombre = "Tarjeta de Crédito" };

            Factura nuevaFactura = new Factura
            {
                Fecha = DateTime.Now,
                FormaPago = formaPago,
                Cliente = "Juan Pérez",
                Detalles = detalles
            };

            bool facturaGuardada = facturaServices.AddFactura(nuevaFactura);
            Console.WriteLine(facturaGuardada ? "Factura guardada con éxito." : "Error al guardar la factura.");

            List<Factura> facturas = facturaServices.GetFacturas();
            foreach (var factura in facturas)
            {
                Console.WriteLine($"Factura Nro: {factura.NumeroFactura}, Fecha: {factura.Fecha}, Cliente: {factura.Cliente}");
            }

            int facturaId = 1;
            bool facturaActualizada = facturaServices.UpdateFactura(facturaId, nuevaFecha: DateTime.Now.AddDays(1), nuevoCliente: "Carlos García");
            Console.WriteLine(facturaActualizada ? "Factura actualizada con éxito." : "Error al actualizar la factura.");

            bool facturaEliminada = facturaServices.DeleteFactura(facturaId);
            Console.WriteLine(facturaEliminada ? "Factura eliminada con éxito." : "Error al eliminar la factura.");

            Console.ReadKey();
        }
    }
}
