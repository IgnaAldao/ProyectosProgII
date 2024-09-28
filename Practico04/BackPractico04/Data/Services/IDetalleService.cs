using BackPractico04.Data.Models;
using BackPractico04.Data.Models.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPractico04.Data.Services
{
    public interface IDetalleService
    {
        void CreateDetalle(DetalleCreateDao detalleTurno);
        bool DeleteDetalle(int idTurno, int idServicio);
        List<TDetallesTurno>? GetAllDetalles();
        TDetallesTurno? GetDetalleById(int idTurno, int idServicio);
        void UpdateDetalle(TDetallesTurno detalleTurno);
    }
}
