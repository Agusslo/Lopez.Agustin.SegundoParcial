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

        [XmlElement]
        public new bool Resucitado { get => base.Resucitado; set => base.Resucitado = value; }




        public Humano() { }

        public Humano(string nombre, EEdad edad) : base(nombre, edad) { }

        public Humano(string nombre, EEdad edad, ECaracteristica caracteristica) : base(nombre, edad, caracteristica) { }

        public Humano(string nombre, EEdad edad, ECaracteristica caracteristica, EColorPelo colorPelo)
            : base(nombre, edad, caracteristica)
        {
            this.ColorPelo = colorPelo;
        }

        public Humano(string nombre, EEdad edad, ECaracteristica caracteristica, bool resucitado, EColorPelo colorPelo, EColorHumano colorHumano)
            : base(nombre, edad, caracteristica, resucitado)
        {
            this.ColorHumano = colorHumano;
            this.ColorPelo = colorPelo;
        }

        public override bool Equals(object obj)
        {
            if (obj is Humano humano)
            {
                return this == humano;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), ColorPelo, ColorHumano);
        }

        public static bool operator ==(Humano l1, Humano l2)
        {
            if (ReferenceEquals(l1, l2))
            {
                return true;
            }
            if (ReferenceEquals(l1, null) || ReferenceEquals(l2, null))
            {
                return false;
            }
            return l1.Nombre == l2.Nombre && l1.Edad == l2.Edad && l1.Caracteristica == l2.Caracteristica && l1.Resucitado == l2.Resucitado && l1.ColorPelo == l2.ColorPelo && l1.ColorHumano == l2.ColorHumano;
        }

        public static bool operator !=(Humano l1, Humano l2)
        {
            return !(l1 == l2);
        }

        public override string ToString()
        {
            return $"Humano - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Pelo: {ColorPelo} | Piel: {ColorHumano} | Resucitado: {EstaResucitado()}";
        }

        public EColorPelo GetColorPelo()
        {
            return ColorPelo;
        }

        public EColorHumano GetColorHumano()
        {
            return ColorHumano;
        }

        public override string EstaResucitado()
        {
            if (!Resucitado)
                return "El humano no está resucitado";
            return "El humano está resucitado";
        }
    }
}
