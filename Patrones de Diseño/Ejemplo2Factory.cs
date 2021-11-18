using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Fondo;
            FactoriaFondo factoria = new FactoriaFondo();
            Console.WriteLine("Introduzca un fondo de inversion");
            Fondo = Console.ReadLine();
            FondoInversion fondo = factoria.crearFondoInversion(int.Parse(Fondo));
            Console.WriteLine("Mi fondo es = " + fondo.saldo + " ," + fondo.toString());
            Console.ReadKey();

        }
        public  class FondoInversion
        {
            public int saldo;
            protected string nombre;
            public string toString()
            {
                return nombre;
            }
        }
        class FIAMM : FondoInversion
        {
            public FIAMM(int s)
            {
                saldo = s;
                nombre = "FIAAM";
            }
        }
        class FIM : FondoInversion
        {
            public FIM(int s)
            {
                saldo = s;
                nombre = "FIM";
            }
        }
        class FactoriaFondo
        {
            public  FondoInversion crearFondoInversion(int saldo)
            {
                return new FIAMM(saldo);
            }
        }
        class FactoriaFIAMM : FactoriaFondo
        {
            public new  FondoInversion crearFondoInversion(int saldo)
            {
                return new FIAMM(saldo);
            }

        }
        class FactoriaFIM : FactoriaFondo
        {
            public new FondoInversion crearFondoInversion(int saldo)
            {
                return new FIM(saldo);
            }
        }
    }
}
