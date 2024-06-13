using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Xsl;

namespace ClassLibrary
{
    public class Coleccion
    {
        public List<Personaje> personajes;

        public Coleccion()
        {
            personajes = new List<Personaje>();
        }

        public static Coleccion operator +(Coleccion co, Personaje personaje)
        {
            if (!co.personajes.Any(c => c.Equals(personaje))) // Verifica cualquier(Any) elemento en la coleccion, crea un lambda comparandolo con el carnivoro eliminado, si existe, lo elimina
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
            if (co.personajes.Any(c => c.Equals(personaje))) // Verifica cualquier(Any) elemento en la coleccion, crea un lambda comparandolo con el carnivoro eliminado, si existe, lo elimina
            {
                co.personajes.Remove(personaje);
            }
            return co;
        }
        public static bool operator ==(Coleccion co, Personaje personaje)
        {
            return co.personajes.Equals(personaje);
        }

        public static bool operator !=(Coleccion co, Personaje personaje)
        {
            return !(co == personaje);
        }

        public void OrdenarPorNombre(bool ascendente = true)
        {
            if (ascendente)
            {
                personajes = personajes.OrderBy(c => c.ObtenerNombre()).ToList();
            }
            else
            {
                personajes = personajes.OrderByDescending(c => c.ObtenerNombre()).ToList();
            }
        }

        public void OrdenarPorEdad(bool ascendente = true)
        {
            if (ascendente)
            {
                personajes = personajes.OrderBy(c => c.ObtenerEdad()).ToList();
            }
            else
            {
                personajes = personajes.OrderByDescending(c => c.ObtenerEdad()).ToList();
            }
        }

        public List<Personaje> FiltrarPorTipos(bool incluirHumano, bool incluirOrco, bool incluirElfo)
        {
            List<Personaje> resultado = new List<Personaje>();

            foreach (var personaje in personajes)
            {
                // Comprobar si el carnivoro es del tipo solicitado y debe incluirse en el resultado
                if ((personaje is Humano && incluirHumano) || (personaje is Orco && incluirOrco) || (personaje is Elfo && incluirElfo))
                {
                    resultado.Add(personaje);
                }
            }

            return resultado;
        }
        public void SerializarAJson(List<Personaje> personajes, string path)
        {
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;

            using (StreamWriter sw = new StreamWriter(path + ".json"))
            {
                string objJSON = JsonSerializer.Serialize(personajes, opciones);
                sw.WriteLine(objJSON);
            }
        }

        public static Coleccion DeserializarDeJson(string jsonString)
        {
            return JsonSerializer.Deserialize<Coleccion>(jsonString);
        }

        public void SerializarAXml(string path)
        {
            using (XmlTextWriter w = new XmlTextWriter(path + ".xml", null))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Personaje>));
                ser.Serialize(w, personajes);
            }
        }

        public static Coleccion DeserializarDeXml(string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Coleccion));
            using (StringReader textReader = new StringReader(xmlString))
            {
                return (Coleccion)serializer.Deserialize(textReader);
            }
        }
        public List<Personaje> GetColeccion() { return personajes; }

    }
}
