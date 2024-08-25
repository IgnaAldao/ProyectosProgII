using Problema1._1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1._1.Clases
{
    internal class Cola : ColeccionAbstracta
    {
        public Cola(int size) : base(size)
        {

        }

        public override object extraer()
        {
            object? e = null;

            if (!estaVacia())
            {
                e = array[0];
                array[0] = null;
            }
            return e;
        }
    }
}
