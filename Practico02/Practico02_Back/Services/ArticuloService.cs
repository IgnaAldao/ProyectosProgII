using Practico02_Back.Data;
using Practico02_Back.Entities;
using Practico02_Back.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico02_Back.Services
{
    public class ArticuloService : IArticuloService
    {
        private IArticuloRepository repository;
        public ArticuloService()
        {
            repository = new ArticuloRepository();
        }

        public bool AddArticulo(ArticuloDTO articulo)
        {
            return repository.AddArticulo(articulo);
        }

        public List<Articulo> GetArticulos()
        {
            return repository.GetArticulos();
        }

        public bool RemoveArticulo(int id)
        {
            return repository.RemoveArticulo(id);
        }

        public bool UpdateArticulo(Articulo articulo)
        {
            return repository.UpdateArticulo(articulo);
        }
    }
}
