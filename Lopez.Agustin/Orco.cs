using System.Threading.Tasks;
using System.Xml.Serialization;
using Entidades;

namespace ClassLibrary
{
    public delegate void OrcoResucitadoEventHandler(Orco orco);

    [XmlInclude(typeof(Orco))]
    public class Orco : Personaje, IPersonaje
    {
        public new string Nombre { get => base.Nombre; set => base.Nombre = value; }

        public new EEdad Edad { get => base.Edad; set => base.Edad = value; }

        public new ECaracteristica Caracteristica { get => base.Caracteristica; set => base.Caracteristica = value; }

        public EEspecieOrco EspecieOrco { get; set; }

        public bool Canibal { get; set; }

        public new bool Resucitado { get => base.Resucitado; set => base.Resucitado = value; }

        public string Tipo { get; } = "Orco"; 

        public event OrcoResucitadoEventHandler OrcoResucitado;

        public Orco() { }

        public Orco(string nombre, EEdad edad) : base(nombre, edad) { }

        public Orco(string nombre, EEdad edad, ECaracteristica caracteristica) : base(nombre, edad, caracteristica) { }

        public Orco(string nombre, EEdad edad, ECaracteristica caracteristica, EEspecieOrco especie)
            : base(nombre, edad, caracteristica)
        {
            this.EspecieOrco = especie;
        }

        public Orco(string nombre, EEdad edad, ECaracteristica caracteristica, bool resucitado, EEspecieOrco especie, bool canibal)
            : base(nombre, edad, caracteristica, resucitado)
        {
            this.Canibal = canibal;
            this.EspecieOrco = especie;
        }

        public override string ToString()
        {
            string canibalString = Canibal ? "Si" : "No";
            return $"Orco - Nombre: {Nombre} | Caracteristica: {Caracteristica} | Edad: {Edad} | Especie: {EspecieOrco} | Canibal: {canibalString} | Resucitado: {EstaResucitado()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Orco orco)
            {
                return this == orco;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), EspecieOrco, Canibal);
        }

        public static bool operator ==(Orco l1, Orco l2)
        {
            if (ReferenceEquals(l1, l2))
            {
                return true;
            }
            if (ReferenceEquals(l1, null) || ReferenceEquals(l2, null))
            {
                return false;
            }
            return l1.Nombre == l2.Nombre && l1.Edad == l2.Edad && l1.Caracteristica == l2.Caracteristica && l1.Resucitado == l2.Resucitado && l1.EspecieOrco == l2.EspecieOrco && l1.Canibal == l2.Canibal;
        }

        public static bool operator !=(Orco l1, Orco l2)
        {
            return !(l1 == l2);
        }

        public EEspecieOrco GetEspecieOrco()
        {
            return EspecieOrco;
        }

        public bool GetCanibal()
        {
            return Canibal;
        }

        public override async Task<string> EstaResucitadoAsync()
        {
            if (!base.Resucitado)
                return "El orco no está resucitado";
            return "El orco está resucitado";
        }
    }
}
