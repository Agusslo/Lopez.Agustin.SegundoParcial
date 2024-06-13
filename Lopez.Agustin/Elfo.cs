namespace ClassLibrary
{
    using Entidades;
    using System;

    public class Elfo : Personaje
    {
        private EEspecieElfo especie { get; set; }
        private bool inmortal { get; set; }

        public Elfo() { }

        public Elfo(string nombre, EEdad edad, ECaracteristica caracteristica, EEspecieElfo especie, bool inmortal, bool resucitado)
            : base(nombre, edad, caracteristica, resucitado)
        {
            this.especie = especie;
            this.inmortal = inmortal;
        }

        public Elfo(string nombre, EEdad edad, EEspecieElfo especie, bool inmortal)
            : base(nombre, edad)
        {
            this.especie = especie;
            this.inmortal = inmortal;
        }

        public override string EstaResucitado()
        {
            if (!base.Resucitado)
                return "El elfo no está resucitado";
            return "El elfo está resucitado";
        }

        public override string DevolverInfo()
        {
            string inmortalString = inmortal ? "Sí" : "No";
            return $"Elfo - Nombre: {Nombre} | Característica: {Caracteristica} | Edad: {Edad} | Especie: {especie} | Inmortal: {inmortalString} | {EstaResucitado()}";
        }

        public override string ToString()
        {
            return DevolverInfo();
        }

        public override bool Equals(object obj)
        {
            if (obj is Elfo elfo)
            {
                return base.Equals(elfo) && this.especie == elfo.especie && this.inmortal == elfo.inmortal;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), especie, inmortal);
        }

        public static bool operator ==(Elfo e1, Elfo e2)
        {
            if (ReferenceEquals(e1, null))
            {
                return ReferenceEquals(e2, null);
            }
            return e1.Equals(e2);
        }

        public static bool operator !=(Elfo e1, Elfo e2)
        {
            return !(e1 == e2);
        }

        public EEspecieElfo GetEspecieElfo() { return especie; }

        public bool GetInmortal() { return inmortal; }
    }
}
