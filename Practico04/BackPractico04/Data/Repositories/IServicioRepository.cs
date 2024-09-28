using BackPractico04.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPractico04.Data.Repositories
{
    public interface IServicioRepository
    {
        void Create(TServicio servicio);
        bool Delete(int id);
        List<TServicio>? GetAll();
        TServicio? GetById(int id);
    }
}
