using Clase_24_09.Models;

namespace Clase_24_09.Repositories
{
    public interface IUsuarioRepository
    {
        void Create(UsuarioDTO usuario);
        List<Usuario> GetByFilters(int idRol);
        List<Usuario> GetAll();
        Usuario? GetById(int id);
        void Delete(int id);
    }
}
