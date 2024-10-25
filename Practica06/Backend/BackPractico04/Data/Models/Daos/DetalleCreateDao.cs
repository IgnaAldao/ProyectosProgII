using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPractico04.Data.Models.Daos
{
    public class DetalleCreateDao
    {
        public int IdTurno { get; set; }

        public int IdServicio { get; set; }

        public string Observaciones { get; set; }
    }
}
