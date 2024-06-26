using Entidades;
using System;
using System.Xml.Serialization;

namespace ClassLibrary
{
    [XmlInclude(typeof(Humano))]
    [XmlInclude(typeof(Orco))]
    [XmlInclude(typeof(Elfo))]
    public abstract class Personaje : IPersonaje
    {
        public string Nombre { get; set; }
        public EEdad Edad { get; set; }
        public ECaracteristica Caracteristica { get; set; }
        public bool Resucitado { get; set; }

        public Personaje()
        {
            Nombre = "Sin nombre";
            Caracteristica = ECaracteristica.No_Especificado;
            Edad = EEdad.No_Especificado;
            Resucitado = false;
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

        public Personaje(string nombre, EEdad edad, ECaracteristica caracteristica, bool resucitado) : this(nombre, edad, caracteristica)
        {
            Resucitado = resucitado;
        }

        public override bool Equals(object obj)
        {
            if (obj is Personaje personaje)
            {
                return this == personaje;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nombre, Edad, Caracteristica, Resucitado);
        }

        public static bool operator ==(Personaje c1, Personaje c2)
        {
            if (ReferenceEquals(c1, c2))
            {
                return true;
            }
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
            {
                return false;
            }
            return c1.Nombre == c2.Nombre && c1.Edad == c2.Edad && c1.Caracteristica == c2.Caracteristica && c1.Resucitado == c2.Resucitado;
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

        public bool ObtenerResucitado()
        {
            return Resucitado;
        }

        public virtual string EstaResucitado()
        {
            if (!Resucitado)
                return "El personaje no esta resucitado";
            return "El personaje esta resucitado";
        }
    }
}
