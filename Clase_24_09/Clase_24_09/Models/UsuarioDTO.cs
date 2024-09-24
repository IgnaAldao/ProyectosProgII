using System.ComponentModel.DataAnnotations.Schema;

namespace Clase_24_09.Models
{
    public class UsuarioDTO
    {
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public int IdRol { get; set; }
    }
}
