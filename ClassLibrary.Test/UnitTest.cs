using ClassLibrary;
using Entidades;
using NUnit.Framework;
using System;

namespace ClassLibrary.Test
{
    [TestFixture]
    public class TesteoClassLibrary
    {
        [Test]
        public void TestAgregarYEliminarHumano()
        {
            // Arrange
            Coleccion coleccion = new Coleccion();
            Humano humano = new Humano("Juan", EEdad.Adulto, ECaracteristica.Alto, true, EColorPelo.Rubio, EColorHumano.Blanco);

            // Act
            Console.WriteLine("\nAgregando humano a la colección...");
            coleccion += humano;
            Console.WriteLine("Humano agregado.");

            // Assert
            Console.WriteLine("Verificando que el humano está en la colección...");
            CollectionAssert.Contains(coleccion.Personajes, humano, "El humano debería estar en la colección.");
            Console.WriteLine("El humano está en la colección.");

            // Act
            Console.WriteLine("Eliminando humano de la colección...");
            coleccion -= humano;
            Console.WriteLine("Humano eliminado.");

            // Assert
            Console.WriteLine("Verificando que el humano no está en la colección...");
            CollectionAssert.DoesNotContain(coleccion.Personajes, humano, "El humano no debería estar en la colección después de eliminarlo.");
            Console.WriteLine("El humano no está en la colección.");
        }

        [Test]
        public void TestAgregarYEliminarOrco()
        {
            // Arrange
            Coleccion coleccion = new Coleccion();
            Orco orco = new Orco("Grishnákh", EEdad.Ninio, ECaracteristica.Enano, true, EEspecieOrco.OrcosGrises, true);

            // Act
            Console.WriteLine("\nAgregando orco a la colección...");
            coleccion += orco;
            Console.WriteLine("Orco agregado.");

            // Assert
            Console.WriteLine("Verificando que el orco está en la colección...");
            CollectionAssert.Contains(coleccion.Personajes, orco, "El orco debería estar en la colección.");
            Console.WriteLine("El orco está en la colección.");

            // Act
            Console.WriteLine("Eliminando orco de la colección...");
            coleccion -= orco;
            Console.WriteLine("Orco eliminado.");

            // Assert
            Console.WriteLine("Verificando que el orco no está en la colección...");
            CollectionAssert.DoesNotContain(coleccion.Personajes, orco, "El orco no debería estar en la colección después de eliminarlo.");
            Console.WriteLine("El orco no está en la colección.");
        }

        [Test]
        public void TestAgregarYEliminarElfo()
        {
            // Arrange
            Coleccion coleccion = new Coleccion();
            Elfo elfo = new Elfo("Legolas", EEdad.Adulto, ECaracteristica.Mediano, true, EEspecieElfo.Lunar, true);

            // Act
            Console.WriteLine("\nAgregando elfo a la colección...");
            coleccion += elfo;
            Console.WriteLine("Elfo agregado.");

            // Assert
            Console.WriteLine("Verificando que el elfo está en la colección...");
            CollectionAssert.Contains(coleccion.Personajes, elfo, "El elfo debería estar en la colección.");
            Console.WriteLine("El elfo está en la colección.");

            // Act
            Console.WriteLine("Eliminando elfo de la colección...");
            coleccion -= elfo;
            Console.WriteLine("Elfo eliminado.");

            // Assert
            Console.WriteLine("Verificando que el elfo no está en la colección...");
            CollectionAssert.DoesNotContain(coleccion.Personajes, elfo, "El elfo no debería estar en la colección después de eliminarlo.");
            Console.WriteLine("El elfo no está en la colección.");
        }
    }
}
