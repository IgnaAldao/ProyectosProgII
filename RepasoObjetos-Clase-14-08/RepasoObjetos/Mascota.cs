using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoObjetos
{
    public class Mascota
    {
        public Mascota(string nombre)
        {
            Nombre = nombre;
        }
        public string Nombre { get; set; }//properties
        public string Duenio { get; set; }

        public override string? ToString() //sobreescribienod un metodo
                                           //solo se puede hacer override cuando el metodo es abstract o virtual en la clase base
        {
            return Nombre + "(" + Duenio + ")";
        }
    }
}
