using BackPractico04.Data.Models;
using BackPractico04.Data.Models.Daos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPractico04.Data.Repositories
{
    public class DetalleRepository : IDetalleRepository
    {
        private readonly db_turnosContext _context;

        public DetalleRepository(db_turnosContext context)
        {
            _context = context;
        }

        public void Create(DetalleCreateDao detalleTurnoDao)
        {
            TDetallesTurno detalleTurno = new TDetallesTurno()
            {
                IdTurno = detalleTurnoDao.IdTurno,
                IdServicio = detalleTurnoDao.IdServicio,
                Observaciones = detalleTurnoDao.Observaciones
            };
            _context.TDetallesTurnos.Add(detalleTurno);
            _context.SaveChanges();
        }

        public List<TDetallesTurno> GetAll()
        {
            return _context.TDetallesTurnos.Include(d => d.IdServicioNavigation).Include(d => d.IdTurnoNavigation).ToList();
        }

        public TDetallesTurno? GetById(int idTurno, int idServicio)
        {
            return _context.TDetallesTurnos
                .Include(d => d.IdServicioNavigation)
                .Include(d => d.IdTurnoNavigation)
                .FirstOrDefault(d => d.IdTurno == idTurno && d.IdServicio == idServicio);
        }

        public void Update(TDetallesTurno detalleTurno)
        {
            _context.TDetallesTurnos.Update(detalleTurno);
            _context.SaveChanges();
        }

        public bool Delete(int idTurno, int idServicio)
        {
            var detalleTurno = GetById(idTurno, idServicio);
            if (detalleTurno != null)
            {
                _context.TDetallesTurnos.Remove(detalleTurno);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
