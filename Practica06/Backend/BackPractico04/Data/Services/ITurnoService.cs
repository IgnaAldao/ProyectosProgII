using BackPractico04.Data.Models;
using BackPractico04.Data.Models.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPractico04.Data.Services
{
    public interface ITurnoService
    {
        TTurno? CreateTurno(TurnoCreateDao turno);
        bool DeleteTurno(int id);
        List<TTurno>? GetAllTurnos();
        TTurno? GetTurnoById(int id);
        void UpdateTurno(int id, TurnoCreateDao turnoUpdate);
    }
}
