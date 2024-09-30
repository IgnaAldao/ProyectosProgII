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
    public class DetalleService : IDetalleService
    {
        private readonly IDetalleRepository _detalleRepository;
        public DetalleService(IDetalleRepository detalleRepository)
        {
            _detalleRepository = detalleRepository;
        }

        public void CreateDetalle(DetalleCreateDao detalleTurno)
        {
            _detalleRepository.Create(detalleTurno);
        }

        public bool DeleteDetalle(int idTurno, int idServicio)
        {
            return _detalleRepository.Delete(idTurno, idServicio);
        }

        public List<TDetallesTurno>? GetAllDetalles()
        {
            return _detalleRepository.GetAll();
        }

        public TDetallesTurno? GetDetalleById(int idTurno, int idServicio)
        {
            return _detalleRepository.GetById(idTurno, idServicio);
        }

        public void UpdateDetalle(DetalleCreateDao detalleDao)
        {
            _detalleRepository.Update(detalleDao);
        }
    }
}
