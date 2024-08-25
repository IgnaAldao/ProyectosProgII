using RepositoryExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Data
{
    public interface IProductoRepository //sufijo nombre del patron
                                         //interfaces publicas
                                         //los metodos son siempre publicos y abstractos entonces no hace falta ponerlos
    {
        List<Product> GetAll();
        Product GetById(int id);
        bool Save(Product product);
        bool Delete(int id);
    }
}
