using Entidades;
using System;
using System.Xml.Serialization;

namespace ClassLibrary
{
    [XmlInclude(typeof(Humano))]
    [XmlInclude(typeof(Orco))]
    [XmlInclude(typeof(Elfo))]
    public abstract class Personaje
    {
        protected string Nombre { get; set; }
        protected EEdad Edad { get; set; }
        protected ECaracteristica Caracteristica { get; set; }

        public Personaje()
        {
            Nombre = "Sin nombre";
            Caracteristica = ECaracteristica.No_Especificado;
            Edad = EEdad.No_Especificado;
        }

        public Personaje(string nombre) : this()
        {
            Nombre = string.IsNullOrEmpty(nombre) ? "Sin nombre" : nombre;
        }

        public Personaje(string nombre, EEdad edad) : this(nombre)
        {
            Edad = edad;
        }

        public Personaje(string nombre, EEdad edad, ECaracteristica caracteristica) : this(nombre, edad)
        {
            Caracteristica = caracteristica;
        }

        public override bool Equals(object obj)
        {
            if (obj is Personaje personaje)
            {
                return Nombre == personaje.Nombre && Caracteristica == personaje.Caracteristica && Edad == personaje.Edad;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nombre, Caracteristica, Edad);
        }

        public static bool operator ==(Personaje c1, Personaje c2)
        {
            if (ReferenceEquals(c1, c2))
            {
                return true;
            }

            if (c1 is null || c2 is null)
            {
                return false;
            }

            return c1.Equals(c2);
        }

        public static bool operator !=(Personaje c1, Personaje c2)
        {
            return !(c1 == c2);
        }

        public string ObtenerNombre()
        {
            return Nombre;
        }

        public EEdad ObtenerEdad()
        {
            return Edad;
        }

        public ECaracteristica ObtenerCaracteristica()
        {
            return Caracteristica;
        }
    }
}
