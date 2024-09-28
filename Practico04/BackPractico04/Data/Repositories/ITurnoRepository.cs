using BackPractico04.Data.Models;
using BackPractico04.Data.Models.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPractico04.Data.Repositories
{
    public interface ITurnoRepository
    {
        void Create(TurnoCreateDao turno);
        bool Delete(int id);
        List<TTurno>? GetAll();
        TTurno? GetById(int id);
        void Update(TTurno turno);
    }
}
