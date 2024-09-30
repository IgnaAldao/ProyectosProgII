using BackPractico04.Data.Models;
using BackPractico04.Data.Models.Daos;
using BackPractico04.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPractico04.Data.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;
        public TurnoService(ITurnoRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;
        }

        public void CreateTurno(TurnoCreateDao turno)
        {
            _turnoRepository.Create(turno);
        }

        public bool DeleteTurno(int id)
        {
            return _turnoRepository.Delete(id);
        }

        public List<TTurno>? GetAllTurnos()
        {
            return _turnoRepository.GetAll();
        }

        public TTurno? GetTurnoById(int id)
        {
            return _turnoRepository.GetById(id);
        }

        public void UpdateTurno(int id, TurnoCreateDao turnoUpdate)
        {
            _turnoRepository.Update(id, turnoUpdate);
        }
    }
}
