using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clase_24_09.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
        [ForeignKey("Roles")]
        public int IdRol {  get; set; }
        public Rol Rol { get; set; }

    }
}
