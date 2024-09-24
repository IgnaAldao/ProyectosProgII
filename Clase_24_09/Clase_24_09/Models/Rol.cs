using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clase_24_09.Models
{
    [Table("Roles")]
    public class Rol
    {
        [Key] //primary key
        [Column("id_rol")] //columna como se llama o quiero que se llame en la base de datos
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public  ICollection<Usuario> Usuarios = new List<Usuario>(); //a los atributos que denotan relacion
                                                                     //se le ponen como virtual para que el ORM entienda
                                                                     //que quiero habilitar el lazyload (carga diferida)
                                                                     //esto hace que no haga siempre todos los joins(carga
                                                                     //anticipada)
                                                                     //no tiene que estar instanciada para eso
        //tener cuidado con la lista porque puedo generar una busqueda ciclica en algunos casos entonces no la pongo

    }
}
