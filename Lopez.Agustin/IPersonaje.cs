using Entidades;

namespace ClassLibrary
{
    public interface IPersonaje
    {
        string Nombre { get; set; }
        EEdad Edad { get; set; }
        ECaracteristica Caracteristica { get; set; }
        bool Resucitado { get; set; }

        string ObtenerNombre();
        EEdad ObtenerEdad();
        ECaracteristica ObtenerCaracteristica();
        bool ObtenerResucitado();
        string EstaResucitado();
    }
}
