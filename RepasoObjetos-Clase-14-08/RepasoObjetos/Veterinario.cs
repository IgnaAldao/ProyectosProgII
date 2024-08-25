using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoObjetos
{
    public class Veterinario
    {
        public Veterinario()
        {
            Matricula = 999;
        }
        public int Matricula { get; set; }
        public string NombreCompleto { get; set; }

        public override string? ToString() //tiene un signo de pregunta porque dice que puede ser nulo el retorno
        {
            return Matricula.ToString();
        }
    }
}
