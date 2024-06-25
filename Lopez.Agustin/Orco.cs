using System.Xml.Serialization;
using Entidades;

namespace ClassLibrary
{
    public class Orco : Personaje
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

        public Orco() { }

        public Orco(string nombre, ECaracteristica caracteristica, EEdad edad, EEspecieOrco especie, bool canibal)
            : base(nombre, edad, caracteristica)
        {
            Especie = especie;
            Canibal = canibal;
        }

        public Orco(string nombre, EEdad edad, EEspecieOrco especie, bool canibal)
            : base(nombre, edad)
        {
            Especie = especie;
            Canibal = canibal;
        }

        public override string ToString()
        {
            string canibalString = Canibal ? "Si" : "No";
            return $"Orco - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Especie: {Especie} | Canibal: {canibalString}";
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;

            if (obj is Orco orco)
            {
                return Especie == orco.Especie && Canibal == orco.Canibal;
            }
            return false;
        }

        public EEspecieOrco GetEspecieOrco()
        {
            return Especie;
        }

        public bool GetCanibal()
        {
            return Canibal;
        }
    }
}
