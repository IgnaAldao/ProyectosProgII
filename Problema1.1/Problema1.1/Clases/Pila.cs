using Problema1._1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1._1.Clases
{
    internal class Pila : ColeccionAbstracta
    {
        public Pila(int size) : base(size) { }

        public override object extraer()
        {
            object elementoExtraido = null;
            if (!estaVacia())
            {
                elementoExtraido = array[next];
                array[next] = null;
                next--;
            }
            return elementoExtraido;

        }
    }

}
