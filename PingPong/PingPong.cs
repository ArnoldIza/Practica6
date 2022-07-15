using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;

namespace PingPong
{
    internal class PingPong
    {
        static void Main(string[] args)
        {
            MPI.Environment.Run(ref args, comm => // se hace uso de entorno de MPI 
            {
                if (comm.Rank == 0) // Si el valor es igual a cero
                {
                    Console.WriteLine("Rank 0 is alive and running on " +MPI.Environment.ProcessorName);// Escribe el numero de rango vivo con el nombre del Procesador (computadora loca)
                    for (int dest = 1; dest < comm.Size; ++dest) // Cantidad de rangos, desde 1 hasta el tamaño del comando
                    {
                        Console.Write("Pinging process with rank " + dest + "...");
                        comm.Send("Ping!", dest, 0); // Envio del mensaje 
                        string destHostname = comm.Receive<string>(dest, 1);
                        Console.WriteLine(" Pong!"); // Regreso del mensaje
                        Console.WriteLine(" Rank " + dest + " is alive and running on " + destHostname); // Se vuelve escribir el rango +1 hasta que se acabe el for 
                    }
                }
                else
                {
                    comm.Receive<string>(0, 0); // Mensaje que recibe
                    comm.Send(MPI.Environment.ProcessorName,0,1); // Mensaje que envia con el nombre del procesador
                }
            });
        }
    }
}
