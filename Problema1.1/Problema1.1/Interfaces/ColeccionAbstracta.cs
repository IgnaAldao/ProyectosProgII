using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1._1.Interfaces
{
    internal abstract class ColeccionAbstracta : IColeccion
    {
        protected object[] array;
        protected int next;

        public object[] Array { get; set; }
        public int Next { get; set; }

        protected ColeccionAbstracta(int size)
        {
            array = new object[size];
            next = -1;
        }

        public virtual bool anadir(object elemento)
        {
            bool agregado = false;
            if (next < array.Length)
            {
                array[++next] = elemento;
                agregado = true;
            }
            return agregado;
        }
        

        public virtual bool estaVacia()
        {
            return next == -1;
        }
        

        public abstract object extraer();

        public virtual object primero()
        {
            object? e = null;
            if (!estaVacia())
            {
                e = array[0];
            }
            
            return e;
        }
    }
}
