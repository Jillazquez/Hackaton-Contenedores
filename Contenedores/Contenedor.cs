public class Contenedor
{
    public int Id { get; }
    public Punto Ubicacion { get; }
    public int Nivel { get; }
    public int Capacidad { get; }

    public Contenedor(int id, int lat, int lon, int nivel, int capacidad)
    {
        Id = id;
        Ubicacion = new Punto(lat, lon);
        Nivel = nivel;
        Capacidad = capacidad;
    }
}