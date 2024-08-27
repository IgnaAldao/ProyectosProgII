using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1._1.Interfaces
{
    internal interface IColeccion
    {
        bool estaVacia();
        object extraer();
        object primero();
        bool anadir(object elemento);
        string mostrarElementos();

    }
}
