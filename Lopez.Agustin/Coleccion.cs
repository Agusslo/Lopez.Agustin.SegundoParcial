using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;

namespace ClassLibrary
{
    [XmlRoot("Coleccion")]
    public class Coleccion
    {
        [XmlElement("Personaje")]
        public List<Personaje> personajes;

        public Coleccion()
        {
            personajes = new List<Personaje>();
        }

        public static Coleccion operator +(Coleccion co, Personaje personaje)
        {
            if (!co.personajes.Any(c => c == personaje))
            {
                co.personajes.Add(personaje);
            }
            else
            {
                throw new ArgumentException("El personaje ya existe en la colección.");
            }
            return co;
        }

        public static Coleccion operator -(Coleccion co, Personaje personaje)
        {
            if (co.personajes.Any(c => c == personaje))
            {
                co.personajes.Remove(personaje);
            }
            return co;
        }

        public static bool operator ==(Coleccion co, Personaje personaje)
        {
            return co.personajes.Contains(personaje);
        }

        public static bool operator !=(Coleccion co, Personaje personaje)
        {
            return !(co == personaje);
        }

        public void OrdenarPorNombre(bool ascendente = true)
        {
            personajes = ascendente
                ? personajes.OrderBy(c => c.ObtenerNombre()).ToList()
                : personajes.OrderByDescending(c => c.ObtenerNombre()).ToList();
        }

        public void OrdenarPorEdad(bool ascendente = true)
        {
            personajes = ascendente
                ? personajes.OrderBy(c => c.ObtenerEdad()).ToList()
                : personajes.OrderByDescending(c => c.ObtenerEdad()).ToList();
        }

        public void OrdenarPorTamaño(bool ascendente = true)
        {
            personajes = ascendente
                ? personajes.OrderBy(c => c.ObtenerCaracteristica()).ToList()
                : personajes.OrderByDescending(c => c.ObtenerCaracteristica()).ToList();
        }

        public List<Personaje> FiltrarPorTipos(bool incluirHumano, bool incluirOrco, bool incluirElfo)
        {
            return personajes.Where(personaje =>
                (personaje is Humano && incluirHumano) ||
                (personaje is Orco && incluirOrco) ||
                (personaje is Elfo && incluirElfo)).ToList();
        }

        public List<Personaje> GetColeccion()
        {
            return personajes;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
