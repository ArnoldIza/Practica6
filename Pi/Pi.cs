using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;
namespace Pi
{
    internal class Pi
    {
        static void Main(string[] args)
        {
            int dartsPerProcessor = 10000000;   //variable
            MPI.Environment.Run(ref args, comm =>//se hace uso de entorno de MPI 
            {
                if (args.Length > 0)
                {
                    dartsPerProcessor = Convert.ToInt32(args[0]);   //conversion a entero del argumento ingresado y almacenado en variable
                }

                Random random = new Random(5 * comm.Rank);  //valor randomico
                int dartsInCircle = 0;
                for (int i = 0; i < dartsPerProcessor; ++i)
                {
                    double x = (random.NextDouble() - 0.5) * 2; //numero de punto flotante 
                    double y = (random.NextDouble() - 0.5) * 2; //numero de punto flotante 
                    if (x * x + y * y <= 1.0)   //consicion si el valor es menor a 1
                    {
                        ++dartsInCircle;    //aumento de la variable dartCircle
                    }
                }
                int totalDartsInCircle = comm.Reduce(dartsInCircle, Operation<int>.Add, 0); //obtencion de "dardos totales" sumados
                if (comm.Rank == 0) //condicion para el primer proceso
                {
                    Console.WriteLine("Pi is approximately {0:F15}.",   //Se imprime el valor de pi
                    4.0 * totalDartsInCircle / (comm.Size * dartsPerProcessor));
                }
            });
        }
    }
}
