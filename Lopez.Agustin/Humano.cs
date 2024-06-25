using System.Xml.Serialization;
using Entidades;

namespace ClassLibrary
{
    public class Humano : Personaje
    {
        [XmlElement]
        public new string Nombre { get => base.Nombre; set => base.Nombre = value; }

        [XmlElement]
        public new EEdad Edad { get => base.Edad; set => base.Edad = value; }

        [XmlElement]
        public new ECaracteristica Caracteristica { get => base.Caracteristica; set => base.Caracteristica = value; }

        [XmlElement]
        public EColorPelo ColorPelo { get; set; }

        [XmlElement]
        public EColorHumano ColorHumano { get; set; }

        public Humano() { }

        public Humano(string nombre, EEdad edad, ECaracteristica caracteristica, EColorPelo colorPelo, EColorHumano colorHumano)
            : base(nombre, edad, caracteristica)
        {
            ColorPelo = colorPelo;
            ColorHumano = colorHumano;
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;

            if (obj is Humano humano)
            {
                return ColorPelo == humano.ColorPelo && ColorHumano == humano.ColorHumano;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Humano - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Pelo: {ColorPelo} | Piel: {ColorHumano}";
        }

        public EColorPelo GetColorPelo()
        {
            return ColorPelo;
        }

        public EColorHumano GetColorHumano()
        {
            return ColorHumano;
        }
    }
}
