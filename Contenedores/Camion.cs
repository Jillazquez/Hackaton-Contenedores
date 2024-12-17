public class Camion
{
    private int CapacidadMaxima { get; }
    public int CargaActual { get; private set; }
    public List<Contenedor> Contenedores { get; }
    public List<Punto> Ruta { get; }
    public double DistanciaRecorrida { get; private set; }
    public Punto UbicacionActual;

    public Camion(int capacidadMaxima, Punto centroOperaciones)
    {
        CapacidadMaxima = capacidadMaxima;
        CargaActual = 0;
        Contenedores = new List<Contenedor>();
        Ruta = new List<Punto> { centroOperaciones };
        DistanciaRecorrida = 0;
        UbicacionActual = centroOperaciones;
    }

    public bool AgregarContenedor(Contenedor contenedor)
    {
        int pesoContenedor = (contenedor.Nivel * contenedor.Capacidad) / 100;
        if (CargaActual + pesoContenedor > CapacidadMaxima)
            return false;

        CargaActual += pesoContenedor;
        Contenedores.Add(contenedor);
        Ruta.Add(contenedor.Ubicacion);

        DistanciaRecorrida += CalcularDistancia(UbicacionActual, contenedor.Ubicacion);
        UbicacionActual = contenedor.Ubicacion;

        return true;
    }

    private double CalcularDistancia(Punto a, Punto b)
    {
        double dx = b.Lat - a.Lat;
        double dy = b.Lon - a.Lon;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}