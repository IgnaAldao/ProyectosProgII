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
    public class TurnoRepository : ITurnoRepository
    {
        private readonly db_turnosContext _context;

        public TurnoRepository(db_turnosContext context)
        {
            _context = context;
        }
        public TTurno? Create(TurnoCreateDao turnoDao)
        {
            var turnoExiste = _context.TTurnos.Where(t => t.Hora == turnoDao.Hora && t.Fecha == turnoDao.Fecha).ToList();
            if (turnoExiste.Count == 0) 
            {
                var fechaMin = DateTime.Now.AddDays(1).ToString();
                var fechaMax = DateTime.Now.AddDays(45);
                if(turnoDao.Fecha != null || !String.IsNullOrEmpty(turnoDao.Fecha))
                    if(DateTime.Parse(turnoDao.Fecha) >= DateTime.Parse(fechaMin) && DateTime.Parse(turnoDao.Fecha) <= fechaMax) 
                    fechaMin = turnoDao.Fecha;
                
                TTurno turno = new TTurno()
                {
                    Fecha = fechaMin,
                    Hora = turnoDao.Hora,
                    Cliente = turnoDao.Cliente,
                };
                _context.TTurnos.Add(turno);
                _context.SaveChanges();
                return turno;
            }
            return null;
        }

        public List<TTurno>? GetAll()
        {
            return _context.TTurnos
                .Include(t => t.TDetallesTurnos)
                .ThenInclude(dt => dt.IdServicioNavigation)
                .ToList();
        }

        public TTurno? GetById(int id)
        {
            return _context.TTurnos.Include(t => t.TDetallesTurnos)
                .ThenInclude(d => d.IdServicioNavigation)
                .FirstOrDefault(t => t.Id == id);
        }

        public void Update(int id, TurnoCreateDao turnoUpdate)
        {
            var turnoExistente = _context.TTurnos.Find(id);
            if(turnoExistente != null)
            {
                turnoExistente.Fecha = turnoUpdate.Fecha;
                turnoExistente.Hora = turnoUpdate.Hora;
                turnoExistente.Cliente = turnoUpdate.Cliente;
            }
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var turno = GetById(id);
            if (turno != null)
            {
                _context.TTurnos.Remove(turno);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
