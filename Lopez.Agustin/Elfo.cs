namespace ClassLibrary
{
    using Entidades;
    using System;

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
            string esInmortal = inmortalidad ? "No" : "Si";
            return $"Elfo - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Especie: {especie} | Inmortal: {esInmortal}";
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

        public override int GetHashCode()
        {
            unchecked //indica al compilador que las operaciones aritméticas de desbordamiento no deben generar excepciones
            {
                int hash = 17;
                hash = hash * 23 + base.GetHashCode();
                hash = hash * 23 + especie.GetHashCode();
                hash = hash * 23 + inmortalidad.GetHashCode();
                return hash;
            }
        }

        public EEspecieElfo GetEspecieElfo() { return especie; }

        public bool GetInmortalidad() { return inmortalidad; }
    }
}
