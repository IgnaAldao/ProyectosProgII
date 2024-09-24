using Clase_24_09.Models;
using Microsoft.EntityFrameworkCore;

namespace Clase_24_09.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(UsuarioDTO usuarioDTO) // hacerl ocon if id == 0 asi puedo hacer al mismo tiempo el
                                                  // create y update al mismo tiempo sin haer un DTO
        {
            
            var rol = _context.Roles.Find(usuarioDTO.IdRol);

            if (rol == null)
            {
                throw new Exception("Rol no encontrado.");
            }

            
            var usuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Clave = usuarioDTO.Clave,
                Activo = usuarioDTO.Activo,
                IdRol = usuarioDTO.IdRol,
                Rol = rol 
            };

            
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }


        public void Delete(int id)
        {
            var usuDelete = GetById(id);
            if (usuDelete != null)
            {
                _context.Usuarios.Remove(usuDelete);
                _context.SaveChanges();
            }
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public List<Usuario> GetByFilters(int idRol)
        {
            return _context.Usuarios.Where(u => u.IdRol == idRol).ToList();
        }

        public Usuario? GetById(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }


    }
}
