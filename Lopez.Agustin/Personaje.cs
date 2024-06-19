namespace ClassLibrary
{
    using Entidades;
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text; //necesario para StringBuilder
    using System.Xml.Serialization;

    public abstract class Personaje
    {
        protected string Nombre { get; set; }
        protected EEdad Edad { get; set; }
        protected ECaracteristica Caracteristica { get; set; }
        protected bool Resucitado { get; set; }

        public Personaje()
        {
            this.Nombre = "Sin nombre";
            this.Caracteristica = ECaracteristica.No_Especificado;
            this.Edad = EEdad.No_Especificado;
        }

        public Personaje(string nombre) : this()
        {
            if (nombre == "")
                this.Nombre = "Sin nombre";
            else
                this.Nombre = nombre;
        }

        public Personaje(string nombre, EEdad edad) : this(nombre)
        {
            this.Edad = edad;
        }

        public Personaje(string nombre, EEdad edad, ECaracteristica caracteristica) : this(nombre, edad)
        {
            this.Caracteristica = caracteristica;
        }

        public Personaje(string nombre, EEdad edad, ECaracteristica caracteristica, bool resucitado) : this(nombre, edad, caracteristica)
        {
            this.Resucitado = resucitado;
        }


        public abstract string DevolverInfo();

        public virtual string EstaResucitado()
        {
            if (!Resucitado)
                return "El personaje no esta resucitado";
            return "El personaje esta resucitado";
        }


        public override bool Equals(object obj)
        {
            if (obj is Personaje)
            {
                return ((Personaje)obj) == this;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nombre, Edad, Caracteristica);
        }

        public static bool operator ==(Personaje c1, Personaje c2)
        {
            return c1.Nombre == c2.Nombre && c1.Edad == c2.Edad && c1.Caracteristica == c2.Caracteristica;
        }

        public static bool operator !=(Personaje c1, Personaje c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return this.DevolverInfo();
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
    }
}
