using System.Xml.Serialization;
using Entidades;

namespace ClassLibrary
{
    public class Orco : Personaje, IPersonaje
    {
        [XmlElement]
        public new string Nombre { get => base.Nombre; set => base.Nombre = value; }

        [XmlElement]
        public new EEdad Edad { get => base.Edad; set => base.Edad = value; }

        [XmlElement]
        public new ECaracteristica Caracteristica { get => base.Caracteristica; set => base.Caracteristica = value; }

        [XmlElement]
        public EEspecieOrco Especie { get; set; }

        [XmlElement]
        public bool Canibal { get; set; }

        [XmlElement]
        public new bool Resucitado { get => base.Resucitado; set => base.Resucitado = value; }

        public Orco() { }

        public Orco(string nombre, EEdad edad) : base(nombre, edad) { }

        public Orco(string nombre, EEdad edad, ECaracteristica caracteristica) : base(nombre, edad, caracteristica) { }

        public Orco(string nombre, EEdad edad, ECaracteristica caracteristica, EEspecieOrco especie)
            : base(nombre, edad, caracteristica)
        {
            this.Especie = especie;
        }

        public Orco(string nombre, EEdad edad, ECaracteristica caracteristica, bool resucitado, EEspecieOrco especie, bool canibal)
            : base(nombre, edad, caracteristica, resucitado)
        {
            this.Canibal = canibal;
            this.Especie = especie;
        }

        public override string ToString()
        {
            string canibalString = Canibal ? "Si" : "No";
            return $"Orco - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Especie: {Especie} | Canibal: {canibalString} | Resucitado: {EstaResucitado()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Orco orco)
            {
                return this == orco;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Especie, Canibal);
        }

        public static bool operator ==(Orco l1, Orco l2)
        {
            if (ReferenceEquals(l1, l2))
            {
                return true;
            }
            if (ReferenceEquals(l1, null) || ReferenceEquals(l2, null))
            {
                return false;
            }
            return l1.Nombre == l2.Nombre && l1.Edad == l2.Edad && l1.Caracteristica == l2.Caracteristica && l1.Resucitado == l2.Resucitado && l1.Especie == l2.Especie && l1.Canibal == l2.Canibal;
        }

        public static bool operator !=(Orco l1, Orco l2)
        {
            return !(l1 == l2);
        }

        public EEspecieOrco GetEspecieOrco()
        {
            return Especie;
        }

        public bool GetCanibal()
        {
            return Canibal;
        }

        public override string EstaResucitado()
        {
            if (!base.Resucitado)
                return "El orco no está resucitado";
            return "El orco está resucitado";
        }
    }
}
