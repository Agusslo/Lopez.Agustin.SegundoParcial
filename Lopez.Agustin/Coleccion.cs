﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;

namespace ClassLibrary
{
    [XmlRoot("Coleccion")]
    public class Coleccion<T> where T : Personaje
    {
        [XmlElement("Personaje")]
        public List<T> Personajes { get; private set; }
        public Coleccion()
        {
            Personajes = new List<T>();
        }

        /// <summary>
        /// Sobrecarga del operador + para agregar un personaje a la colección si no existe.
        /// </summary>
        /// <param name="co">Colección en la que se desea agregar el personaje.</param>
        /// <param name="personaje">Personaje a agregar.</param>
        /// <returns>La colección actualizada con el nuevo personaje.</returns>
        public static Coleccion<T> operator +(Coleccion<T> co, T personaje)
        {
            if (!co.Personajes.Any(c => c.ObtenerNombre() == personaje.ObtenerNombre() && c.GetType() == personaje.GetType()))
            {
                co.Personajes.Add(personaje);
            }
            else
            {
                throw new ArgumentException("El personaje ya existe en la colección.");
            }
            return co;
        }

        /// <summary>
        /// Sobrecarga del operador - para eliminar un personaje de la colección si existe.
        /// </summary>
        /// <param name="co">Colección de la que se desea eliminar el personaje.</param>
        /// <param name="personaje">Personaje a eliminar.</param>
        /// <returns>La colección actualizada sin el personaje especificado.</returns>
        public static Coleccion<T> operator -(Coleccion<T> co, T personaje)
        {
            var existingPersonaje = co.Personajes.FirstOrDefault(c => c.ObtenerNombre() == personaje.ObtenerNombre() && c.GetType() == personaje.GetType());
            if (existingPersonaje != null)
            {
                co.Personajes.Remove(existingPersonaje);
            }
            return co;
        }

        /// <summary>
        /// Sobrecarga del operador == para verificar si un elemento existe en la colección.
        /// </summary>
        /// <param name="co">Colección en la que se desea buscar el personaje.</param>
        /// <param name="elemento">Personaje a verificar.</param>
        /// <returns>True si el personaje existe en la colección, de lo contrario false.</returns>
        public static bool operator ==(Coleccion<T> co, T elemento)
        {
            return co.Personajes.Any(c => c.Equals(elemento));
        }

        /// <summary>
        /// Sobrecarga del operador != para verificar si un elemento no existe en la colección.
        /// </summary>
        /// <param name="co">Colección en la que se desea buscar el personaje.</param>
        /// <param name="elemento">Personaje a verificar.</param>
        /// <returns>True si el personaje no existe en la colección, de lo contrario false.</returns>
        public static bool operator !=(Coleccion<T> co, T elemento)
        {
            return !(co == elemento);
        }

        /// <summary>
        /// Ordena los personajes en la colección por nombre, de manera ascendente o descendente.
        /// </summary>
        /// <param name="ascendente">Indica si se desea ordenar de manera ascendente (true) o descendente (false).</param>
        public void OrdenarPorNombre(bool ascendente = true)
        {
            Personajes = ascendente
                ? Personajes.OrderBy(c => c.ObtenerNombre()).ToList()
                : Personajes.OrderByDescending(c => c.ObtenerNombre()).ToList();
        }

        /// <summary>
        /// Ordena los personajes en la colección por edad, de manera ascendente o descendente.
        /// </summary>
        /// <param name="ascendente">Indica si se desea ordenar de manera ascendente (true) o descendente (false).</param>
        public void OrdenarPorEdad(bool ascendente = true)
        {
            Personajes = ascendente
                ? Personajes.OrderBy(c => c.ObtenerEdad()).ToList()
                : Personajes.OrderByDescending(c => c.ObtenerEdad()).ToList();
        }

        /// <summary>
        /// Ordena los personajes en la colección por tamaño (característica), de manera ascendente o descendente.
        /// </summary>
        /// <param name="ascendente">Indica si se desea ordenar de manera ascendente (true) o descendente (false).</param>
        public void OrdenarPorTamaño(bool ascendente = true)
        {
            Personajes = ascendente
                ? Personajes.OrderBy(c => c.ObtenerCaracteristica()).ToList()
                : Personajes.OrderByDescending(c => c.ObtenerCaracteristica()).ToList();
        }

        /// <summary>
        /// Filtra los personajes en la colección según los tipos especificados.
        /// </summary>
        /// <param name="incluirHumano">Indica si se deben incluir los personajes de tipo Humano en el filtro.</param>
        /// <param name="incluirOrco">Indica si se deben incluir los personajes de tipo Orco en el filtro.</param>
        /// <param name="incluirElfo">Indica si se deben incluir los personajes de tipo Elfo en el filtro.</param>
        /// <returns>Lista de personajes filtrados según los tipos especificados.</returns>
        public List<T> FiltrarPorTipos(bool incluirHumano, bool incluirOrco, bool incluirElfo)
        {
            return Personajes.Where(personaje =>
                (personaje is Humano && incluirHumano) ||
                (personaje is Orco && incluirOrco) ||
                (personaje is Elfo && incluirElfo)).ToList();
        }

        /// <summary>
        /// Obtiene la lista completa de personajes en la colección.
        /// </summary>
        /// <returns>Lista de todos los personajes en la colección.</returns>
        public List<T> GetColeccion()
        {
            return Personajes;
        }

        /// <summary>
        /// Convierte la colección a su representación en formato JSON.
        /// </summary>
        /// <returns>Cadena JSON que representa la colección.</returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
