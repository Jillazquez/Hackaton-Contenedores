using System;

namespace Contenedores
{
    internal class Contenedor : IComparable<Contenedor>
    {
        private int _id { get; set; }
        private int lat { get; set; }
        private int lon { get; set; }
        private int nivel { get; set; }
        private int capacidad { get; set; }

        // Constructor
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

        public int Id => _id;
        public int Nivel => nivel; // Propiedad pública para acceder al nivel
        public int Capacidad => capacidad;

        public override string ToString()
        {
            return $"Contenedor ID: {_id}, Nivel: {nivel}%, Capacidad: {capacidad} unidades";
        }

        public int CompareTo(Contenedor other)
        {
            if (other == null) return 1;

            int pesoActual = this.nivel * this.capacidad;
            int pesoOtro = other.nivel * other.capacidad;

            return pesoOtro.CompareTo(pesoActual);
        }

    }
}
