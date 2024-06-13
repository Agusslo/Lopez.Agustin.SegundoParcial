namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using Entidades;

    public class Orco : Personaje
    {
        private EEspecieOrco especie { get; set; }
        private bool canibal { get; set; }

        public Orco() { }
        public Orco(string nombre, EEdad edad, ECaracteristica caracteristica, EEspecieOrco especie, bool canibal, bool resucitado)
            : base(nombre, edad, caracteristica, resucitado)
        {
            this.especie = especie;
            this.canibal = canibal;
        }

        public Orco(string nombre, EEdad edad, EEspecieOrco especie, bool canibal)
            : base(nombre, edad)
        {
            this.especie = especie;
            this.canibal = canibal;
        }
        public override string EstaResucitado()
        {
            if (!base.Resucitado)
                return "El orco no esta Resucitado";
            return "El orco esta Resucitado";
        }
        public override string DevolverInfo()
        {
            string canibalstring;
            if (canibal)
                canibalstring = "Sí";
            else
                canibalstring = "No";
            return $"Oso - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Especie: {especie} | Canibal: {canibalstring} | {EstaResucitado()} ";
        }
        public override string ToString()
        {
            return DevolverInfo();
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType() && obj != null)
            {
                return ((Orco)obj) == this;
            }
            return false;
        }
        public static bool operator ==(Orco o1, Orco o2)
        {
            return o1.Nombre == o2.Nombre && o1.Edad == o2.Edad && o1.Caracteristica == o2.Caracteristica && o1.especie == o2.especie && o1.especie == o2.especie && o1.canibal == o2.canibal;
        }
        public static bool operator !=(Orco o1, Orco o2) { return !(o1 == o2); }
        public EEspecieOrco GetEspecieOrco() { return especie; }

        public bool GetCanibal() { return canibal; }
    }
}

