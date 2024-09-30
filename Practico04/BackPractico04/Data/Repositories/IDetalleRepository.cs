using BackPractico04.Data.Models;
using BackPractico04.Data.Models.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPractico04.Data.Repositories
{
    public interface IDetalleRepository
    {
        void Create(DetalleCreateDao detalleTurno);
        bool Delete(int idTurno, int idServicio);
        List<TDetallesTurno>? GetAll();
        TDetallesTurno? GetById(int idTurno, int idServicio);
        void Update(DetalleCreateDao detalleDao);
    }
}
