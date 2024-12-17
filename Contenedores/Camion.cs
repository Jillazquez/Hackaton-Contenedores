using System.Collections.Generic;

namespace Contenedores
{
    internal class Camion
    {
        public int CapacidadMaxima { get; private set; } // Capacidad total del camión
        public int CapacidadActual { get; private set; } // Capacidad usada
        public List<Contenedor> Contenedores { get; private set; } // Contenedores asignados

        public Camion(int capacidadMaxima)
        {
            CapacidadMaxima = capacidadMaxima;
            CapacidadActual = 0;
            Contenedores = new List<Contenedor>();
        }

        // Intenta añadir un contenedor al camión
        public bool AgregarContenedor(Contenedor contenedor)
        {
            int pesoContenedor = (contenedor.Nivel * contenedor.Capacidad) / 100;

            // Verificar si el contenedor cabe en el camión
            if (CapacidadActual + pesoContenedor <= CapacidadMaxima)
            {
                Contenedores.Add(contenedor);
                CapacidadActual += pesoContenedor;
                return true; // Contenedor añadido
            }

            return false; // No se pudo añadir
        }

        public override string ToString()
        {
            return $"Camión con {Contenedores.Count} contenedores, Carga Actual: {CapacidadActual}/{CapacidadMaxima}";
        }
    }
}
