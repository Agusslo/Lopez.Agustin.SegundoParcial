using System.Xml.Serialization;
using Entidades;

namespace ClassLibrary
{
    public class Elfo : Personaje
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

        public Elfo() { }

        public Elfo(string nombre, ECaracteristica caracteristica, EEdad edad, EEspecieElfo especie, bool inmortalidad)
            : base(nombre, edad, caracteristica)
        {
            Especie = especie;
            Inmortalidad = inmortalidad;
        }

        public Elfo(string nombre, EEdad edad, EEspecieElfo especie, bool inmortalidad)
            : base(nombre, edad)
        {
            Especie = especie;
            Inmortalidad = inmortalidad;
        }

        public override string ToString()
        {
            string inmortalString = Inmortalidad ? "Si" : "No";
            return $"Elfo - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Especie: {Especie} | Inmortal: {inmortalString}";
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;

            if (obj is Elfo elfo)
            {
                return Inmortalidad == elfo.Inmortalidad && Especie == elfo.Especie;
            }
            return false;
        }

        public EEspecieElfo GetEspecieElfo()
        {
            return Especie;
        }

        public bool GetInmortalidad()
        {
            return Inmortalidad;
        }
    }
}
