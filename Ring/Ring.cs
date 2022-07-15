using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;
namespace Ring
{
    internal class Ring
    {
        static void Main(string[] args)
        {

            MPI.Environment.Run(ref args, comm => //Se hace uso de entorno de MPI 
            {
                if (comm.Size < 2) // Si se utiliza menos de 2 procesos
                {
                    Console.WriteLine("The Ring example must be run with at least two processes."); // Mensaje de error al solo usar una iteración
                    Console.WriteLine("Try: mpiexec -np 4 ring.exe"); // Recomendacion
                }
                else if (comm.Rank == 0) // Si el rango es 0
                {
                    string data = "Hello, World!";

                    comm.Send(data, (comm.Rank + 1) % comm.Size, 0); // Se suma 1 al rango 
                    comm.Receive((comm.Rank + comm.Size - 1) % comm.Size, 0, out data); // Se resta uno a la suma del rango que es 0 mas el número te iteraciones totales
                    data += " 0"; // Se suma el data mas un número
                    Console.WriteLine(data); // Escritura del data
                }
                else // Si el número de iteraciones es mas de 2
                {
                    String data; // se ituliza el mismo string
                    comm.Receive((comm.Rank + comm.Size - 1) % comm.Size, 0, out data); // Se resta en uno a la suma del rango mas el número de iteraciones
                    data = data + " " + comm.Rank.ToString() + ","; // Se rescribe la data
                    comm.Send(data, (comm.Rank + 1) % comm.Size, 0); //Se envia la data
                }
            });
        }
    }
}
