using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_6.Domain
{
    public  class Cliente
    {
        private string nombre;
        private string apellido;
        private int dni;

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public List<Cuenta> Cuentas { get; set; }
    }
}
