using Contenedores;
using System.Collections;
public class Program
{
    static void Main(string[] args)
    {
        //Genero objeto random para generar numeros aleatorios
        Random random = new Random();
        //Consultar el numero de contenedores
        int numContenedores = 0;
        Console.WriteLine("Introduce con cuantos contenedores crear la simulacion");
        numContenedores = int.Parse(Console.ReadLine());

        //ArrayList para almacenar contenedores
        ArrayList contenedores = new ArrayList();
        for(int i = 0; i < numContenedores; i++)
        {
            int lat = random.Next(100)+1;
            int lon = random.Next(100) + 1;
            Contenedor c = new Contenedor(i, lat, lon,0,0);
            contenedores.Add(c);
        }

        foreach (Contenedor cont in contenedores)
        {

        }
    }
}
