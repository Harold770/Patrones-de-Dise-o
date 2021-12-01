using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        //este patron con el mismo codigo y sin importar la estructura de datos es capaz de recorrer cada uno de los elementos
        static void Main(string[] args)
        {
            ListaNumeros LN = new ListaNumeros();
            ListaPalabras LP = new ListaPalabras();
            Iterator iterador;

            LN.agregar(5);
            LN.agregar(3);
            LN.agregar(1);
            LN.agregar(9);
            LN.agregar(2);
            LN.agregar(8);

            LP.agregar("OCHO");
            LP.agregar("CINCO");
            LP.agregar("DOS");
            LP.agregar("UNO");
            LP.agregar("TRES");

            iterador = LN.iterador();
            while (iterador.tieneSiguiente())
            {
                //acceder al elemento
                int numero = (int)iterador.siguiente();
                //hacer algo con el elemento
                Console.WriteLine(numero);
            }
            Console.WriteLine("------------------");
            iterador = LP.iterador();
            while (iterador.tieneSiguiente())
            {
                //acceder al elemento
                string palabra = (string)iterador.siguiente();
                //hacer algo con el elemento
                Console.WriteLine(palabra);
            }
            Console.ReadLine();

        }

        public class ListaNumeros
        {
            private int[] numeros;
            private int posicion;

            public ListaNumeros()
            {
                numeros = new int[10];
                posicion = 0;
            }

            public void agregar(int i)
            {
                numeros[posicion++] = i;
            }
            public ListaNumerosIterador iterador()
            {
                return new ListaNumerosIterador(numeros);
            }
        }
        public class ListaPalabras
        {
            public string palabra1, palabra2, palabra3, palabra4, palabra5;
            private int posicion;

            public ListaPalabras()
            {
                posicion = 0;
            }
            public void agregar(string p)
            {
                switch (posicion)
                {
                    case 0:
                        palabra1 = p;
                        break;
                    case 1:
                        palabra2 = p;
                        break;
                    case 2:
                        palabra3 = p;
                        break;
                    case 3:
                        palabra4 = p;
                        break;
                    case 4:
                        palabra5 = p;
                        break;
                }
                posicion++;
            }
            public ListaPalabrasIterador iterador()
            {
                return new ListaPalabrasIterador(palabra1,palabra2,palabra3,palabra4,palabra5);
            }
        }

        public interface Iterator
        {
            Object siguiente();
            Boolean tieneSiguiente();
        }
        public class ListaNumerosIterador : Iterator
        {
            private int[] numeros;
            private int posicion;

            public ListaNumerosIterador(int[] num)
            {
                this.numeros = num;
                this.posicion = 0;
            }

            public object siguiente()
            {
                return numeros[posicion++];
            }

            public bool tieneSiguiente()
            {
                if (posicion < numeros.Length && numeros[posicion] != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class ListaPalabrasIterador : Iterator
        {
            public string palabra1, palabra2, palabra3, palabra4, palabra5;
            private int posicion;

            public ListaPalabrasIterador(string p1, string p2, string p3, string p4, string p5)
            {
                this.palabra1 = p1;
                this.palabra2 = p2;
                this.palabra3 = p3;
                this.palabra4 = p4;
                this.palabra5 = p5;
                this.posicion = 0;
            }

            public object siguiente()
            {
                switch (posicion++)
                {
                    case 0:
                        return palabra1;
                    case 1:
                        return palabra2;
                    case 2:
                        return palabra3;
                    case 3:
                        return palabra4;
                    case 4:
                        return palabra5;

                }
                return null;
            }

            public bool tieneSiguiente()
            {
                if (posicion <= 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
