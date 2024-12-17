using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contenedores
{
    internal class Funciones
    {
        public static ArrayList ordenar(ArrayList contenedores)
        {
            ArrayList ordenado = new ArrayList();
            for (int i = 0; i < contenedores.Count;i++)
            {
                ordenado.Add(contenedores[i]);
            }

            return ordenado;
        }
    }
}
