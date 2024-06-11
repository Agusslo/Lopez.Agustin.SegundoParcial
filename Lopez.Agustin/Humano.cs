namespace ClassLibrary
{
    using ClassLibrary;
    using System;
    using System.Collections.Generic;
    using Entidades;
    using System.Drawing;
    using System.Reflection.PortableExecutable;

    public class Humano : Personaje
    {
        private EColorPelo colorPelo { get; set; }
        private EColorHumano colorHumano { get; set; }

        public Humano() { }
        public Humano(string nombre, EEdad edad, EColorPelo colorPelo)
            : base(nombre, edad)
        {
            this.colorPelo = colorPelo;
        }
        public Humano(string nombre, EEdad edad, ECaracteristica caracteristica, EColorPelo colorPelo, EColorHumano colorHumano)
            : base(nombre, edad, caracteristica)
        {
            this.colorPelo = colorPelo;
            this.colorHumano = colorHumano;
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;

            if (obj is Humano humano)
            {
                return this.colorPelo == humano.colorPelo && this.colorHumano == humano.colorHumano;
            }
            return false;
        }
        public override string ToString()
        {
            return $"Humano - Nombre: {Nombre} | Caracteristica: {Caracteristica} |  Edad: {Edad} | Pelo: {colorPelo} | Piel: {colorHumano}";
        }

        public override int GetHashCode()
        {
            unchecked  //indica al compilador que las operaciones aritméticas de desbordamiento no deben generar excepciones
            {
                int hash = 17;
                hash = hash * 23 + base.GetHashCode();
                hash = hash * 23 + colorPelo.GetHashCode();
                hash = hash * 23 + colorHumano.GetHashCode();
                return hash;
            }
        }


        public EColorPelo GetColorPelo() { return colorPelo; }

        public EColorHumano GetColorHumano() {  return colorHumano; }
    }
}
