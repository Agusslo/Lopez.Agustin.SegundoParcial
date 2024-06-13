namespace ClassLibrary
{
    using Entidades;
    using System;

    public class Humano : Personaje
    {
        private EColorPelo colorPelo { get; set; }
        private EColorHumano colorHumano { get; set; }

        public Humano() { }

        public Humano(string nombre, EEdad edad, ECaracteristica caracteristica, EColorPelo colorPelo, EColorHumano colorHumano, bool resucitado)
            : base(nombre, edad, caracteristica, resucitado)
        {
            this.colorPelo = colorPelo;
            this.colorHumano = colorHumano;
        }

        public Humano(string nombre, EEdad edad, EColorPelo colorPelo, EColorHumano colorHumano)
            : base(nombre, edad)
        {
            this.colorPelo = colorPelo;
            this.colorHumano = colorHumano;
        }

        public override bool Equals(object obj)
        {
            if (obj is Humano humano)
            {
                return base.Equals(humano) && this.colorPelo == humano.colorPelo && this.colorHumano == humano.colorHumano;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), colorPelo, colorHumano);
        }

        public static bool operator ==(Humano h1, Humano h2)
        {
            if (ReferenceEquals(h1, null))
            {
                return ReferenceEquals(h2, null);
            }
            return h1.Equals(h2);
        }

        public static bool operator !=(Humano h1, Humano h2)
        {
            return !(h1 == h2);
        }

        public override string EstaResucitado()
        {
            return base.Resucitado ? "El humano está resucitado" : "El humano no está resucitado";
        }

        public override string DevolverInfo()
        {
            return $"Humano - Nombre: {Nombre} | Característica: {Caracteristica} | Edad: {Edad} | Color de Pelo: {colorPelo} | Color de Piel: {colorHumano} | {EstaResucitado()}";
        }

        public EColorPelo GetColorPelo() { return colorPelo; }

        public EColorHumano GetColorHumano() { return colorHumano; }
    }
}
