using BackPractico04.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPractico04.Data.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private db_turnosContext _context;
        public ServicioRepository(db_turnosContext context)
        {
            _context = context;
        }
        public void Create(TServicio servicio)
        {
            var existingServicio = GetById(servicio.Id);
            if(existingServicio == null)
            {
                var newServicio = new TServicio()
                {
                    Id = servicio.Id,
                    Nombre = servicio.Nombre,
                    Costo = servicio.Costo,
                    EnPromocion = servicio.EnPromocion
                };
            _context.TServicios.Add(newServicio);
                
            }
            else
            {
                existingServicio.Nombre = servicio.Nombre;
                existingServicio.Costo = servicio.Costo;
                existingServicio.EnPromocion = servicio.EnPromocion;

                _context.TServicios.Update(existingServicio);
            }
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool aux = false;
            var servicioDelete = GetById(id);
            if (servicioDelete != null)
            {
                _context.TServicios.Remove(servicioDelete);
                _context.SaveChanges();
                return aux = true;
            }
            return aux;
        }

        public List<TServicio>? GetAll()
        {
            return _context.TServicios.ToList();
        }

        public TServicio? GetById(int id)
        {
            return _context.TServicios.Find(id);
        }
    }
}
