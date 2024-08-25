using RepasoObjetos;

//NOTAS
// para tener polimorfismo debo tener un metodo virtual o abstract el cual se va a redefinir
// virtual es cuando ya tiene una funcionalidad y lo voy a especializar y abstract es cuando el metodo no tiene ninguna implementacion y lo voy a
// redefinir
// las interfaces tienen los metodos publicos de una clase
// se puede tener un metodo abstracto sin que la clase sea abtracta, pero si la clase es abtrascta los metodos tienen que ser abstractos
// al hacer una clase abstract impido que se puedan instanciar objetos de esa clase -> para generalizar comportamientos y atributos comunes -> para
// reutlizar codigo
// las clases estaticas son como por ejemplo Math, Convert, etc usos los metodos tal como estan nomas
// las interfaces tienen todos los metodos abstractos 
// una clase puede implementar de mas de una interfaz siempre y cuando implemente todos sus metodos, en cambio una clase no puede heredar de muchas clases
// los atributos estaticos son atributos que son iguales para todas las instancias de la clase
// todo lo que no es estatico tiene acceso a lo que es estatico pero a la inversa no
// si no quiero instancia de la clase puedo usar clases estaticas -> no confundir con clases abstractas

object m = new object();
//object m2 = new Mascota();
//((Mascota)m2).Nombre = "Nacho"; //lo estoy casteando porque object no tiene una property Nombre pero Mascota si
object m2 = new Mascota("Gala"); //se puede resolver con un constructor asi no tengo que castear cada vez que le quiero asignar algo
object v = new Veterinario();

object[] array = { m, m2, v};

foreach(object x in array)
{
    Console.WriteLine(x.ToString()); // aca hay polimorfismo porque el mensaje es el mismo pero cada mensaje responde de manera distinta al mensaje
}

Math.Abs(-9); // estoy mandando un mensaje a la clase directamente sin tener que hacer una implementacion -> trato a la clase como un objeto
              // esto se puede hacer cuando tengo metodos estaticos