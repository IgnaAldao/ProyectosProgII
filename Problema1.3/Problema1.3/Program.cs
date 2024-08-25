using Problema1._3;

var suelto = new Suelto();
var pack = new Pack();

pack.Precio = 1000;
suelto.Precio = 100;
suelto.Medida = 5;
pack.Cantidad = 2;

Producto[] array = {suelto, pack};
float total = 0;
foreach (var x in array)
{
    total += x.CalcularPrecio();
}

Console.WriteLine("Total: $" + total);
