using Practico02_Back.Entities.DTOs;
using Practico02_Back.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico02_Back.Services
{
    public interface IArticuloService
    {
        List<Articulo> GetArticulos();
        bool AddArticulo(ArticuloDTO articulo);
        bool RemoveArticulo(int id);
        bool UpdateArticulo(Articulo articulo);
    }
}
