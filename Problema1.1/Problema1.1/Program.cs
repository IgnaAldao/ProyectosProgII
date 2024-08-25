using Problema1._1.Clases;

Pila pila = new Pila(3);
Cola cola = new Cola(3);

Console.WriteLine("-------------FUNCIONAMIENTO PILA-------------");
Console.WriteLine(pila.estaVacia());

pila.anadir("hola");
pila.anadir(41);
pila.anadir(32);

Console.WriteLine(pila.estaVacia());

Console.WriteLine(pila.primero());

Console.WriteLine(pila.extraer());
Console.WriteLine(pila.extraer());

Console.WriteLine("-------------FUNCIONAMIENTO COLA-------------");
Console.WriteLine(cola.estaVacia());

cola.anadir("pollo");
cola.anadir("gastaxx");
cola.anadir("huevo");

Console.WriteLine(cola.estaVacia());

Console.WriteLine(cola.primero());

Console.WriteLine(cola.extraer());

Console.WriteLine(cola.extraer());
