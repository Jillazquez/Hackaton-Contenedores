using Contenedores;

public class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        List<Contenedor> contenedores = new List<Contenedor>();
        List<Camion> camiones = new List<Camion>();

        // Generar contenedores aleatorios
        for (int i = 0; i < 10; i++)
        {
            int lat = random.Next(100) + 1;
            int lon = random.Next(100) + 1;
            int nivel = random.Next(100) + 1;
            int capacidad = random.Next(300) + 1;

            contenedores.Add(new Contenedor(i, lat, lon, nivel, capacidad));
        }

        // Ordenar contenedores por nivel * capacidad (peso real)
        contenedores.Sort((a, b) =>
            (b.Nivel * b.Capacidad).CompareTo(a.Nivel * a.Capacidad));

        // Capacidad máxima de cada camión
        int capacidadCamion = 500;

        // Asignar contenedores a camiones
        foreach (var contenedor in contenedores)
        {
            int pesoContenedor = (contenedor.Nivel * contenedor.Capacidad) / 100;
            bool asignado = false;

            // Intentar asignar el contenedor a un camión existente
            foreach (var camion in camiones)
            {
                if (camion.AgregarContenedor(contenedor))
                {
                    asignado = true;
                    break;
                }
            }

            // Si no se asignó a ningún camión, crear uno nuevo
            if (!asignado)
            {
                if (pesoContenedor <= capacidadCamion)
                {
                    Camion nuevoCamion = new Camion(capacidadCamion);
                    nuevoCamion.AgregarContenedor(contenedor);
                    camiones.Add(nuevoCamion);
                }
                else
                {
                    Console.WriteLine($"Advertencia: Contenedor ID {contenedor.Id} excede la capacidad de un camión. Peso: {pesoContenedor} kg.");
                }
            }
        }

        // Mostrar la información de los camiones
        Console.WriteLine("\nInformación de Camiones:");
        int camionIndex = 1;
        foreach (var camion in camiones)
        {
            Console.WriteLine($"Camión {camionIndex++}: {camion}");
            foreach (var contenedor in camion.Contenedores)
            {
                int peso = (contenedor.Nivel * contenedor.Capacidad) / 100;
                Console.WriteLine($"  - Contenedor ID: {contenedor.Id}, Peso: {peso} kg");
            }
        }
    }
}
