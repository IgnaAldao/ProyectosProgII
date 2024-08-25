using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problema1._3
{
    public abstract class Producto : IPrecio
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }

        public abstract float CalcularPrecio();

    }
}
