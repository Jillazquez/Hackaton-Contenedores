using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contenedores
{
    internal class Contenedor
    {
        private int _id { get; set; }
        private int lat { get; set; }
        private int lon { get; set; }
        private int nivel { get; set; }
        private int capacidad { get; set; }

        //Constructor de los contenedores
        public Contenedor(int id, int lat, int lon, int nivel, int capacidad)
        {
            this._id = id;
            this.lat = lat;
            this.lon = lon;

            if (nivel < 0 || nivel > 100)
                throw new ArgumentOutOfRangeException(nameof(nivel), "El nivel debe estar entre 0 y 100.");
            this.nivel = nivel;

            if (capacidad < 0)
                throw new ArgumentOutOfRangeException(nameof(capacidad), "La capacidad no puede ser negativa.");
            this.capacidad = capacidad;
        }

        public override string ToString()
        {
            return $"Contenedor ID: {_id}, Latitud: {lat}, Longitud: {lon}, Nivel: {nivel}%, Capacidad: {capacidad} unidades";
        }

        // Implementar CompareTo para ordenar por Nivel
        public int CompareTo(Contenedor other)
        {
            if (other == null) return 1; // Si el otro objeto es null, este es mayor
            return nivel.CompareTo(other.nivel); // Comparar por Nivel
        }
    }
}
