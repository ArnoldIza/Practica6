// *****************************************************************************
// Practica 05
// GenesisC_ArnoldI 
// Fecha de realización: 17/06/2022
// Fecha de entrega: 24/06/2022
// RESULTADOS:
// Resultados:
//
//  EJERCICIO 2
//  [COMANDO UTILIZADO EN CMD: mpiexec -8 Hello.exe]
//   -  El resultado al realizar dos ejecuciones no es el mismo, debido ya que con el comando utilziado se crean
//      los números de procesos indicados que corresponden a hilos y estos no pueden se contrlados, por esta razón
//      se muestra en orden aleatorio y diferenteen los dos casos.
//
//   -  Al cambiar el valor de n menos, ocurrió los mismo que se explicó anteriormente, los hilos no tienen algún
//      patrón de comportamiento, lo mismo se tiene para un valor de n mayor.
//		
//   -  Primera ejecucion:
//      Con el comando usado se puede ejecutar una aplicación, con el cual se indica el número de procesos, como
//      resultado se tiene el rank de cada proceso este último se identifica del 0 al 7. 
//   -  Ejecucion con n máx:
//      Al utilizar  un número máximo de procesos aumenta el tiempo y consumo de recursos al momento de ejecutar,
//      con n = 100 la aplicacion tardo en ejecutarse y con n = 1000 el sistema no pudo ejecutar la aplicacion
//      con el numero de procesos indicados.
//   -  Ejecucion con n mín:
//      Se tuvo una ejecución rápido, se utilizó un n=2.
//
//
//  EJERCICIO 3
//   -  A medida que se aumenta el valor de n, se acer al valor de pi, el valor en un inicio que se dió era similar
//      al valor de pi pero al aumentar el valor era mas exacto, pero a partir de darle un valor de n=230 los valores
//      comenzaron a ser incorrectos y el ejecutar tomaba mas tiempo.
//
//  EJERCICIO 4
//   -  Hace referencia a su nombre PingPong porque son mensajes que envian y vuelven, como se asemeja en el juego, se
//      envia el primer mensaje con un Rango 0 y luego el rango suma +1, como se utilizo n=4, entonces se obtuvo que el
//      último mensaje recibido fué con rango 3 si contamos el mensaje desde 0.
//
//  EJERCICIO 5
//   -  Con n = 1
//      Se obtiene el mensaje de que no puede utilizar con menos de 2 iteraciones.
//   -  Con n = 4
//      Se puede obtener el mensaje original más 4 números, el 0 siempre va a estar al final, mientras que los demás digitos van
//      estar listado ascendentemente.
//   -  Con n = [5,10,15,20,25]
//      Mientras mas aumenta el n más se demora el proceso de obtener el mensaje, debido a que tiene más dígitos que sumar al data
//      original.
// CONCLUSIONES
// *  La utilización de MPI tiene que ver mucho con las características de nuestro ordenador, es decir, el tiempo de
//    ejecución puede ser más rápido y MPI tiene un mejor trabajo si nuestro computador tiene buenas prestaciones.
// *  Es importante instalar de manera correcta el MPI en nuestro ordenador para evitar errores y de igualforma el
//    nuget debe ser instalado en cada proyecto para que el proyecto pueda hacer utilización de los comandos que nos
//    da MPI para posteriormente ejecutarlo desde nuestro ordenador a través del terminal.
// *  Cada programa ejecutado tiene un rank, esta variable es importante ya que identifica el proceso que se ejecuta en cada
//    iteracion del programa a utilizar,el rango de un proceso es un número entero que va desde cero hasta el tamaño del
//    comunicador menos uno.
//
//
// RECOMENDACIONES
// *  Para tener un mejor resultado al usar MPI se requiere usar ordenadores con buenas prestaciones.
// *  Colocar el using MPI para poder utilizar los métodos que nos brinda esta libreria.
// *  Es utilil estudiar y analizar los métodos que nos brindan MPI para entender por completo todos los códigos de la
//    práctica.
//
//
// 
// *****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;

namespace Hello
{
    class Hello
    {
        static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))   //Se hace uso de entorno de MPI 
            {
                Console.WriteLine("Hello, from process number " //Se imprime mensaje en conosola
                + Communicator.world.Rank + " of "      //Imprime rank (identificador) de cada proceso
               + Communicator.world.Size);  //Imprime tamaño del Communicator, número de procesos que se tiene en el communicator

            }
        }
    }
}
