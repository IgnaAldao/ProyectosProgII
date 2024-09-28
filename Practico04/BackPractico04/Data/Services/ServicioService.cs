using BackPractico04.Data.Models;
using BackPractico04.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPractico04.Data.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _servicioRepository;
        public ServicioService(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public void CreateServicio(TServicio servicio)
        {
             _servicioRepository.Create(servicio);
        }

        public bool DeleteServicio(int id)
        {
            return _servicioRepository.Delete(id);
        }

        public List<TServicio>? GetAllServicios()
        {
            return _servicioRepository.GetAll();
        }

        public TServicio? GetServicioById(int id)
        {
            return _servicioRepository.GetById(id);
        }
    }
}
