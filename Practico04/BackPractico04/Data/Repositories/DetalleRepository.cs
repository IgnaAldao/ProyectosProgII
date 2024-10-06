﻿using BackPractico04.Data.Models;
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

        public bool Create(DetalleCreateDao detalleTurnoDao)
        {
            var detalleExiste = _context.TDetallesTurnos.Where(d => d.IdTurno == detalleTurnoDao.IdTurno && d.IdServicio == detalleTurnoDao.IdServicio).ToList();
            if(detalleExiste.Count() == 0 )
            {
                TDetallesTurno detalleTurno = new TDetallesTurno()
                {
                    IdTurno = detalleTurnoDao.IdTurno,
                    IdServicio = detalleTurnoDao.IdServicio,
                    Observaciones = detalleTurnoDao.Observaciones
                };
                _context.TDetallesTurnos.Add(detalleTurno);
                return _context.SaveChanges() > 0;
            }
            return false;
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

        public void Update(DetalleCreateDao detalleDao)
        {
            var detalleExistente = _context.TDetallesTurnos
                .FirstOrDefault(d => d.IdTurno == detalleDao.IdTurno && d.IdServicio == detalleDao.IdServicio);
            if(detalleExistente != null)
            {
                detalleExistente.Observaciones = detalleDao.Observaciones;
            }
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
