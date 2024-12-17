using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contenedores
{
    internal class CentroOperaciones
    {
        private int lat {  get; set; }
        private int lon { get; set; }
        private Contenedor[] contenedores { get; set; }

        public CentroOperaciones(int lat , int lon)
        {
            this.lat = lat;
            this.lon = lon;
        }
    }
}
