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
        public List<Personaje> Personajes { get; private set; }

        public Coleccion()
        {
            Personajes = new List<Personaje>();
        }

        public static Coleccion operator +(Coleccion co, Personaje personaje)
        {
            if (!co.Personajes.Any(c => c == personaje))
            {
                co.Personajes.Add(personaje);
            }
            else
            {
                throw new ArgumentException("El personaje ya existe en la colección.");
            }
            return co;
        }

        public static Coleccion operator -(Coleccion co, Personaje personaje)
        {
            if (co.Personajes.Any(c => c == personaje))
            {
                co.Personajes.Remove(personaje);
            }
            return co;
        }

        public static bool operator ==(Coleccion co, Personaje personaje)
        {
            return co.Personajes.Contains(personaje);
        }

        public static bool operator !=(Coleccion co, Personaje personaje)
        {
            return !(co == personaje);
        }

        public void OrdenarPorNombre(bool ascendente = true)
        {
            Personajes = ascendente
                ? Personajes.OrderBy(c => c.ObtenerNombre()).ToList()
                : Personajes.OrderByDescending(c => c.ObtenerNombre()).ToList();
        }

        public void OrdenarPorEdad(bool ascendente = true)
        {
            Personajes = ascendente
                ? Personajes.OrderBy(c => c.ObtenerEdad()).ToList()
                : Personajes.OrderByDescending(c => c.ObtenerEdad()).ToList();
        }

        public void OrdenarPorTamaño(bool ascendente = true)
        {
            Personajes = ascendente
                ? Personajes.OrderBy(c => c.ObtenerCaracteristica()).ToList()
                : Personajes.OrderByDescending(c => c.ObtenerCaracteristica()).ToList();
        }

        public List<Personaje> FiltrarPorTipos(bool incluirHumano, bool incluirOrco, bool incluirElfo)
        {
            return Personajes.Where(personaje =>
                (personaje is Humano && incluirHumano) ||
                (personaje is Orco && incluirOrco) ||
                (personaje is Elfo && incluirElfo)).ToList();
        }

        public List<Personaje> GetColeccion()
        {
            return Personajes;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
