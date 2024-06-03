namespace ClassLibrary
{
    using Entidades;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;


    public class Personaje
    {

        protected string Nombre { get; set; }
        protected ECaracteristica Caracteristica { get; set; }
        protected EEdad Edad { get; set; }
        public Personaje()
        {
            this.Nombre = "Sin nombre";
            this.Caracteristica = ECaracteristica.No_Especificado;
            this.Edad = EEdad.No_Especificado;
        }
        public Personaje(string nombre): this()
        {
            if (nombre == "")
                this.Nombre = "Sin nombre";
            else
            this.Nombre = nombre;
        }

        public Personaje(string nombre, ECaracteristica caracteristica) : this(nombre)
        {
            this.Caracteristica = caracteristica;
        }

        public Personaje(string nombre, ECaracteristica caracteristica, EEdad edad) : this(nombre, caracteristica)
        {
            this.Edad = edad;
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
            if (ReferenceEquals(c1, c2)) // Por si por algun error, los dos personajes estan en el mismo lugar de memoria
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
