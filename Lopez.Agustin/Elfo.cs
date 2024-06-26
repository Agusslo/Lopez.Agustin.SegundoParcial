using System.Xml.Serialization;
using Entidades;

namespace ClassLibrary
{
    public class Elfo : Personaje, IPersonaje
    {
        [XmlElement]
        public new string Nombre { get => base.Nombre; set => base.Nombre = value; }

        [XmlElement]
        public new EEdad Edad { get => base.Edad; set => base.Edad = value; }

        [XmlElement]
        public new ECaracteristica Caracteristica { get => base.Caracteristica; set => base.Caracteristica = value; }

        [XmlElement]
        public EEspecieElfo Especie { get; set; }

        [XmlElement]
        public bool Inmortalidad { get; set; }

        [XmlElement]
        public new bool Resucitado { get => base.Resucitado; set => base.Resucitado = value; }

        public Elfo() { }

        public Elfo(string nombre, EEdad edad) : base(nombre, edad) { }

        public Elfo(string nombre, EEdad edad, ECaracteristica caracteristica) : base(nombre, edad, caracteristica) { }

        public Elfo(string nombre, EEdad edad, ECaracteristica caracteristica, EEspecieElfo especie)
            : base(nombre, edad, caracteristica)
        {
            this.Especie = especie;
        }

        public Elfo(string nombre, EEdad edad, ECaracteristica caracteristica, bool resucitado, EEspecieElfo especie, bool inmortalidad)
            : base(nombre, edad, caracteristica, resucitado)
        {
            this.Inmortalidad = inmortalidad;
            this.Especie = especie;
        }

        public override string ToString()
        {
            string inmortalString = Inmortalidad ? "Si" : "No";
            return $"Elfo - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Especie: {Especie} | Inmortal: {inmortalString} | Resucitado: {EstaResucitado()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Elfo elfo)
            {
                return this == elfo;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Especie, Inmortalidad);
        }

        public static bool operator ==(Elfo l1, Elfo l2)
        {
            if (ReferenceEquals(l1, l2))
            {
                return true;
            }
            if (ReferenceEquals(l1, null) || ReferenceEquals(l2, null))
            {
                return false;
            }
            return l1.Nombre == l2.Nombre && l1.Edad == l2.Edad && l1.Caracteristica == l2.Caracteristica && l1.Resucitado == l2.Resucitado && l1.Especie == l2.Especie && l1.Inmortalidad == l2.Inmortalidad;
        }

        public static bool operator !=(Elfo l1, Elfo l2)
        {
            return !(l1 == l2);
        }

        public EEspecieElfo GetEspecieElfo()
        {
            return Especie;
        }

        public bool GetInmortalidad()
        {
            return Inmortalidad;
        }

        public override string EstaResucitado()
        {
            if (!base.Resucitado)
                return "El elfo no está resucitado";
            return "El elfo está resucitado";
        }
    }
}
