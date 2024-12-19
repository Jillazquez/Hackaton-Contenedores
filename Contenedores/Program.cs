using System;
using System.Collections.Generic;

namespace Contenedores
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Objeto para crear aleatoriedad
            Random random = new Random();
            List<Contenedor> contenedores = new List<Contenedor>();
            List<Camion> camiones = new List<Camion>();
            int numContenedores = 0;
            bool inputValido = false;

            //Const 
            const int LATMAX = 100;
            const int LONMAX = 100;
            const int NIVELMAX = 100;
            const int CAPACIDADMAX = 300;

            // Solicitar el número de contenedores
            do
            {
                try
                {
                    Console.WriteLine("¿Cuántos contenedores desea generar?");
                    numContenedores = int.Parse(Console.ReadLine());
                    if (numContenedores >= 1)
                    {
                        inputValido = true;
                    }
                    else
                    {
                        Console.WriteLine("Por favor introduce un número mayor o igual a 1.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor introduce un número válido.");
                }
            } while (!inputValido);

            // Generar contenedores
            for (int i = 0; i < numContenedores; i++)
            {
                int lat = random.Next(LATMAX) + 1;
                int lon = random.Next(LONMAX) + 1;
                int nivel = random.Next(NIVELMAX) + 1;
                int capacidad = random.Next(CAPACIDADMAX) + 1;
                contenedores.Add(new Contenedor(i + 1, lat, lon, nivel, capacidad));
            }

            // Mostrar contenedores generados
            Console.WriteLine("\n--- Contenedores Generados ---");
            foreach (var contenedor in contenedores)
            {
                // Calculamos el peso real con el nivel y la capacidad total
                int peso = (contenedor.Nivel * contenedor.Capacidad) / 100;
                Console.WriteLine($"ID: {contenedor.Id}, Posición: ({contenedor.Ubicacion.Lat}, {contenedor.Ubicacion.Lon}),Nivel:{contenedor.Nivel}, Capacidad: {contenedor.Capacidad}, Peso: {peso} kg");
            }

            // Ordenar contenedores por peso
            contenedores.Sort((a, b) => (b.Nivel * b.Capacidad).CompareTo(a.Nivel * a.Capacidad));

            // Crear minimo numero de camiones
            int capacidadCamion = 500;
            Punto centroOperaciones = new Punto(50, 50);
            int camionesRequeridos = (int)Math.Ceiling((double)contenedores.Count / (capacidadCamion / 100));

            for (int i = 0; i < camionesRequeridos; i++)
            {
                camiones.Add(new Camion(capacidadCamion, centroOperaciones));
            }

            // Asignar contenedores a camiones
            Console.WriteLine("\n--- Asignación de Contenedores ---");
            foreach (var contenedor in contenedores)
            {
                Camion closest = null;
                double distanciaCercana = double.MaxValue;

                foreach (var camion in camiones)
                {
                    double distancia = camion.CalcularDistancia(contenedor.Ubicacion, camion.UbicacionActual);
                    if (distancia < distanciaCercana && (camion.CapacidadMaxima-camion.CargaActual) > (contenedor.Nivel * contenedor.Capacidad) / 100)
                    {
                        closest = camion;
                        distanciaCercana = distancia;
                    }
                }

                if (closest != null && closest.AgregarContenedor(contenedor))
                {
                    Console.WriteLine($"Contenedor {contenedor.Id} asignado al camión ubicado en ({closest.UbicacionActual.Lat}, {closest.UbicacionActual.Lon}).");
                }
                else
                {
                    Console.WriteLine($"Contenedor {contenedor.Id} no pudo ser asignado (sin capacidad disponible).");
                }
            }

            // Devolver los camiones a su punto de origen
            foreach (var camion in camiones)
            {
                camion.volverCentro(centroOperaciones);
            }

            // Mostrar información detallada de los camiones y sus rutas
            Console.WriteLine("\n--- Detalles de los Camiones ---");
            int camionIndex = 1;
            foreach (var camion in camiones)
            {
                Console.WriteLine($"\nCamión {camionIndex}:");
                Console.WriteLine($"  Capacidad utilizada: {camion.CargaActual}/{camion.CapacidadMaxima} kg");
                Console.WriteLine($"  Distancia recorrida: {camion.DistanciaRecorrida:F2} unidades");
                Console.WriteLine($"  Ruta seguida:");
                Console.Write("    ");
                foreach (var punto in camion.Ruta)
                {
                    Console.Write($"({punto.Lat}, {punto.Lon}) -> ");
                }
                Console.WriteLine($"Final ({camion.UbicacionActual.Lat}, {camion.UbicacionActual.Lon})");

                Console.WriteLine($"  Contenedores transportados:");
                foreach (var contenedor in camion.Contenedores)
                {
                    int peso = (contenedor.Nivel * contenedor.Capacidad) / 100;
                    Console.WriteLine($"    Contenedor ID: {contenedor.Id}, Peso: {peso} kg, Ubicación: ({contenedor.Ubicacion.Lat}, {contenedor.Ubicacion.Lon})");
                }
                camionIndex++;
            }

            Console.WriteLine("\n--- Fin de la Ejecución ---");
        }
    }
}
