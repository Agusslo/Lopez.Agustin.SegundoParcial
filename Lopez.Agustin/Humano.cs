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

        public Humano()
        {
            
        }
        public Humano(string nombre, ECaracteristica caracteristica, EColorPelo colorPelo)
            : base(nombre, caracteristica)
        {
            this.colorPelo = colorPelo;
        }
        public Humano(string nombre, EEdad edad, ECaracteristica caracteristica, EColorPelo colorPelo, EColorHumano colorHumano)
            : base(nombre, caracteristica, edad )
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

        public EColorPelo GetolorPelo() { return colorPelo; }

        public EColorHumano GetColorHumano() {  return colorHumano; }
    }
}
