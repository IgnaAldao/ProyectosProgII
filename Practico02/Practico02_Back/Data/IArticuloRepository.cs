using Practico02_Back.Entities;
using Practico02_Back.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico02_Back.Data
{
    public interface IArticuloRepository    
    {
        List<Articulo> GetArticulos();
        bool AddArticulo(ArticuloDTO articulo);
        bool RemoveArticulo(int id);
        bool UpdateArticulo(Articulo articulo);
    }
}
