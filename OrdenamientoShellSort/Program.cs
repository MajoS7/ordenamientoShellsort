using System;
using System.IO;

namespace OrdenamientoShellSort
{
    class Program
    {
        public int capturarCantidad()
        {
            Console.Write("cantidad de numeros: ");
            int cantidad = Int32.Parse(Console.ReadLine());
            return cantidad;
        }

        public int[] capturarHora(int[] listaHora, bool inicioFinal)
        {
            int hora = Convert.ToInt32(DateTime.Now.ToString("hh"));
            int minutos = Convert.ToInt32(DateTime.Now.ToString("mm"));
            int segundos = Convert.ToInt32(DateTime.Now.ToString("ss"));
            int milisegundos = Convert.ToInt32(DateTime.Now.ToString("fff"));
            Console.WriteLine(hora + ":" + minutos + ":" + segundos + "." + milisegundos);

            if (inicioFinal == true)
            {
                //hora inicial
                listaHora[0] = hora;
                listaHora[1] = minutos;
                listaHora[2] = segundos;
                listaHora[3] = milisegundos;
            }
            else
            {
                //hora final
                listaHora[4] = hora;
                listaHora[5] = minutos;
                listaHora[6] = segundos;
                listaHora[7] = milisegundos;
            }

            return listaHora;
        }

        public void calcularTiempo(int[] listahora)
        {

            int cantidadSegundos, cantidadminutos, cantidadmilisegundos;
            if (listahora[3] > listahora[7])
            {
                cantidadmilisegundos = listahora[3] - listahora[7];
            }
            else
            {
                cantidadmilisegundos = listahora[7] - listahora[3];
            }
            if (listahora[2] > listahora[6])
            {
                cantidadSegundos = listahora[2] - listahora[6];
            }
            else
            {
                cantidadSegundos = listahora[6] - listahora[2];
            }
            if (listahora[1] > listahora[5])
            {
                cantidadminutos = listahora[1] - listahora[5];
            }

            else
            {
                cantidadminutos = listahora[5] - listahora[1];
            }

            Console.WriteLine("\tDemora: \nMinutos: " + cantidadminutos + "\nSegundos: " + cantidadSegundos + "\nMilisegundos: " + cantidadmilisegundos);
        }

        public TextWriter crearArchivo(int cantidad)
        {

            //Creacion del archivo .txt
            TextWriter archivo = new StreamWriter("archivo.txt");
            Random aleoratorios = new Random();

            //Escribir en el archivo 

            for (int i = 1; i <= cantidad; i++)
            {
                int numaleatorio = aleoratorios.Next(-1000, 1000);
                archivo.WriteLine(numaleatorio);
            }

            archivo.Close();
            return archivo;

        }

        public int[] crearvector(int[] lista)
        {

            // Lectura del archivo:
            TextReader leer = new StreamReader("archivo.txt");

            //Colocar el contenido del archivo en una lista
            int posicion = 0;
            String Line;
            while ((Line = leer.ReadLine()) != null)
            {
                lista[posicion] = Int32.Parse(Line);
                posicion = posicion + 1;
            }
            leer.Close();
            return lista;
        }

        public int[] ordenamientoShellSort(int[] lista)
        {

            int salto = 0;
            bool salir = true;
            int numerocambio = 0;
            int contador = 0;
            salto = lista.Length / 2;
            while (salto > 0)
            {
                salir = false;
                while (salir != true)
                {
                    salir = true;
                    contador = 1;
                    while (contador <= (lista.Length - salto))
                    {
                        if (lista[contador - 1] > lista[(contador - 1) + salto])
                        {
                            numerocambio = lista[(contador - 1) + salto];
                            lista[(contador - 1) + salto] = lista[contador - 1];
                            lista[(contador - 1)] = numerocambio;
                            salir = false;
                        }
                        contador++;
                    }
                }
                salto = salto / 2;
            }
            return lista;

        }

        // public void mostrarVector(int[] lista){

        //     foreach(int numero in lista)
        //     {
        //        Console.Write(" "+numero);
        //     }
        // }

        static void Main(string[] args)
        {
            Program metodo = new Program();

            int cantidad = metodo.capturarCantidad();

            bool inicioFinal = true;
            Console.WriteLine("\tGuardar y generar el listado: \nInicia: ");
            int[] listaHora = new int[8];
            metodo.capturarHora(listaHora, inicioFinal);

            TextWriter archivo = metodo.crearArchivo(cantidad);
            int[] vector = new int[cantidad];
            vector = metodo.crearvector(vector);

            Console.WriteLine("Termina: ");
            inicioFinal = false;
            listaHora = metodo.capturarHora(listaHora, inicioFinal);
            metodo.calcularTiempo(listaHora);

            inicioFinal = true;
            Console.WriteLine("\tEl ordenamiento: \nInicia: ");
            metodo.capturarHora(listaHora, inicioFinal);

            vector = metodo.ordenamientoShellSort(vector);

            Console.WriteLine("Termina: ");
            inicioFinal = false;
            listaHora = metodo.capturarHora(listaHora, inicioFinal);
            metodo.calcularTiempo(listaHora);

            // metodo.mostrarVector(vector);
        }
    }
}
