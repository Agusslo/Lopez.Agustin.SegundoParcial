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
            Console.WriteLine("\nAgregando humano a la colecci�n...");
            coleccion += humano;
            Console.WriteLine("Humano agregado.");

            // Assert
            Console.WriteLine("Verificando que el humano est� en la colecci�n...");
            CollectionAssert.Contains(coleccion.Personajes, humano, "El humano deber�a estar en la colecci�n.");
            Console.WriteLine("El humano est� en la colecci�n.");

            // Act
            Console.WriteLine("Eliminando humano de la colecci�n...");
            coleccion -= humano;
            Console.WriteLine("Humano eliminado.");

            // Assert
            Console.WriteLine("Verificando que el humano no est� en la colecci�n...");
            CollectionAssert.DoesNotContain(coleccion.Personajes, humano, "El humano no deber�a estar en la colecci�n despu�s de eliminarlo.");
            Console.WriteLine("El humano no est� en la colecci�n.");
        }

        [Test]
        public void TestAgregarYEliminarOrco()
        {
            // Arrange
            Coleccion coleccion = new Coleccion();
            Orco orco = new Orco("Grishn�kh", EEdad.Ninio, ECaracteristica.Enano, true, EEspecieOrco.OrcosGrises, true);

            // Act
            Console.WriteLine("\nAgregando orco a la colecci�n...");
            coleccion += orco;
            Console.WriteLine("Orco agregado.");

            // Assert
            Console.WriteLine("Verificando que el orco est� en la colecci�n...");
            CollectionAssert.Contains(coleccion.Personajes, orco, "El orco deber�a estar en la colecci�n.");
            Console.WriteLine("El orco est� en la colecci�n.");

            // Act
            Console.WriteLine("Eliminando orco de la colecci�n...");
            coleccion -= orco;
            Console.WriteLine("Orco eliminado.");

            // Assert
            Console.WriteLine("Verificando que el orco no est� en la colecci�n...");
            CollectionAssert.DoesNotContain(coleccion.Personajes, orco, "El orco no deber�a estar en la colecci�n despu�s de eliminarlo.");
            Console.WriteLine("El orco no est� en la colecci�n.");
        }

        [Test]
        public void TestAgregarYEliminarElfo()
        {
            // Arrange
            Coleccion coleccion = new Coleccion();
            Elfo elfo = new Elfo("Legolas", EEdad.Adulto, ECaracteristica.Mediano, true, EEspecieElfo.Lunar, true);

            // Act
            Console.WriteLine("\nAgregando elfo a la colecci�n...");
            coleccion += elfo;
            Console.WriteLine("Elfo agregado.");

            // Assert
            Console.WriteLine("Verificando que el elfo est� en la colecci�n...");
            CollectionAssert.Contains(coleccion.Personajes, elfo, "El elfo deber�a estar en la colecci�n.");
            Console.WriteLine("El elfo est� en la colecci�n.");

            // Act
            Console.WriteLine("Eliminando elfo de la colecci�n...");
            coleccion -= elfo;
            Console.WriteLine("Elfo eliminado.");

            // Assert
            Console.WriteLine("Verificando que el elfo no est� en la colecci�n...");
            CollectionAssert.DoesNotContain(coleccion.Personajes, elfo, "El elfo no deber�a estar en la colecci�n despu�s de eliminarlo.");
            Console.WriteLine("El elfo no est� en la colecci�n.");
        }
    }
}
