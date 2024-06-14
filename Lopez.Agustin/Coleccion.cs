using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;

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
            if (!co.personajes.Any(c => c.Equals(personaje)))
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
            if (co.personajes.Any(c => c.Equals(personaje)))
            {
                co.personajes.Remove(personaje);
            }
            return co;
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

        /*public void SerializarAXml(string filePath, List<Personaje> personajes, string[] listBoxItems)
        {
            var datos = new
            {
                Personajes = personajes,
                ListBoxItems = listBoxItems
            };
            XmlSerializer serializer = new XmlSerializer(datos.GetType());
            using (StreamWriter write = new StreamWriter(filePath))
            {
                serializer.Serialize(write, datos);
            }
        }

        public static Coleccion DeserializarDeXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Coleccion));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (Coleccion)serializer.Deserialize(reader);
            }
        }*/
    }
}
