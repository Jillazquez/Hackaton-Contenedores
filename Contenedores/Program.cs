using System;
using System.Collections.Generic;

namespace Contenedores
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<Contenedor> contenedores = new List<Contenedor>();
            List<Camion> camiones = new List<Camion>();
            int numContenedores = 0;
            bool inputValido = false;

            // Bucle para solicitar el número de contenedores, solo acepta valores válidos.
            do
            {
                try
                {
                    Console.WriteLine("¿Cuántos contenedores desea generar?");
                    numContenedores = int.Parse(Console.ReadLine());
                    // Verificar que el número ingresado sea mayor o igual a 1
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
            } while (!inputValido); // Se repite hasta que se ingrese un número válido

            // Generación de contenedores
            for (int i = 0; i < numContenedores; i++)
            {
                int lat = random.Next(100) + 1;
                int lon = random.Next(100) + 1;
                int nivel = random.Next(100) + 1;
                int capacidad = random.Next(300) + 1;

                contenedores.Add(new Contenedor(i + 1, lat, lon, nivel, capacidad));
            }

            Console.WriteLine("\nContenedores generados:");
            foreach (var contenedor in contenedores)
            {
                int peso = (contenedor.Nivel * contenedor.Capacidad) / 100;
                Console.WriteLine($"ID: {contenedor.Id}, Posición: ({contenedor.Ubicacion.Lat}, {contenedor.Ubicacion.Lon}), Peso: {peso} kg");
            }

            // Ordenar contenedores por prioridad (peso)
            contenedores.Sort((a, b) => (b.Nivel * b.Capacidad).CompareTo(a.Nivel * a.Capacidad));

            int capacidadCamion = 500;
            Punto centroOperaciones = new Punto(50, 50);

            // Generación de camiones vacíos
            // Supongamos que necesitamos crear el número mínimo de camiones necesarios, basado en la cantidad de contenedores y la capacidad de los camiones
            int camionesRequeridos = (int)Math.Ceiling((double)contenedores.Count / (double)(capacidadCamion / 100)); // Este cálculo puede ser mejorado si lo deseas

            // Crear camiones vacíos
            for (int i = 0; i < camionesRequeridos; i++)
            {
                camiones.Add(new Camion(capacidadCamion,centroOperaciones));
            }

            // Mostrar camiones generados
            Console.WriteLine($"\nNúmero total de camiones creados: {camionesRequeridos}");
            int camionIndex = 1;
            foreach (var camion in camiones)
            {
                Console.WriteLine($"Camión {camionIndex++}: Capacidad {camion.CargaActual}kg Posicion ({camion.UbicacionActual.Lat},{camion.UbicacionActual.Lon})");
            }


            //Here we have containers sorted and trucks created

            // Give the container to the closest Truck

            foreach()
            {
                Console.WriteLine(camion);
            }

        }
    }
}
