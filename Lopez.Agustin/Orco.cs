﻿namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using Entidades;

    public class Orco : Personaje
    {
        private EEspecieOrco especie { get; set; }
        private bool canibal { get; set; }

        public Orco() { }
        public Orco(string nombre, ECaracteristica caracteristica,  EEdad edad, EEspecieOrco especie, bool canibal)
            : base(nombre, edad, caracteristica)
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
        public override string ToString()
        {
            if (canibal)
                return $"Orco - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Especie: {especie} | canibal: No.";
            else
            {
                return $"Orco - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Especie: {especie} | canibal: Si.";
            }
        }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;

            if (obj is Orco orco)
            {
                return this.canibal == orco.canibal && this.especie == orco.especie;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked  //indica al compilador que las operaciones aritméticas de desbordamiento no deben generar excepciones
            {
                int hash = 17;
                hash = hash * 23 + base.GetHashCode();
                hash = hash * 23 + especie.GetHashCode();
                hash = hash * 23 + canibal.GetHashCode();
                return hash;
            }
        }

        public EEspecieOrco GetEspecieOrco() { return especie;  }

        public bool GetCanibal() {  return canibal; }
    }
}
