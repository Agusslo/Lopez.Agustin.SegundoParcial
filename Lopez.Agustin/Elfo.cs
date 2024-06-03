namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection.PortableExecutable;
    using Entidades;

    public class Elfo : Personaje
    {
        private EEspecieElfo especie { get; set; }
        private bool inmortalidad { get; set; }

        public Elfo() { }
        public Elfo(string nombre, ECaracteristica caracteristica, EEdad edad, EEspecieElfo especie, bool inmortalidad)
            : base(nombre, edad, caracteristica)
        {
            this.especie = especie;
            this.inmortalidad = inmortalidad;
        }

        public Elfo(string nombre, EEdad edad, EEspecieElfo especie, bool inmortalidad)
            : base(nombre, edad)
        {
            this.especie = especie;
            this.inmortalidad = inmortalidad;
        }
        public override string ToString()
        {
            if (inmortalidad)
                return $"Elfo - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Especie: {especie} | inmortal: Sí.";
            else
            {
                return $"Elfo - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Especie: {especie} | inmortal: No.";
            }
        }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;

            if (obj is Elfo elfo)
            {
                return this.inmortalidad == elfo.inmortalidad && this.especie == elfo.especie;
            }
            return false;
        }
        public EEspecieElfo GetEspecieElfo() { return especie; }

        public bool GetInmortalidad() { return inmortalidad; }
    }
}
