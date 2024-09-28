using BackPractico04.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPractico04.Data.Services
{
    public interface IServicioService
    {
        List<TServicio>? GetAllServicios();
        void CreateServicio(TServicio servicio);
        bool DeleteServicio(int id);
        TServicio? GetServicioById(int id);
    }
}
