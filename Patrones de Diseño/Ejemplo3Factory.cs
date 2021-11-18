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
            string Tipo;
            FactoriaFondo factoria = new FactoriaFondo();
            Console.WriteLine("Introduzca un fondo de inversion");
            Fondo = Console.ReadLine();
            Console.WriteLine("Introduzca un tipo de fondo de inversion");
            Tipo = Console.ReadLine();
            FondoInversion fondo = factoria.CrearFondoInversion(int.Parse(Tipo), int.Parse(Fondo));
            Console.WriteLine("Mi fondo es = " + fondo.saldo + " ," + fondo.toString());
            Console.ReadKey();

        }
        public abstract class FondoInversion
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
            public FondoInversion CrearFondoInversion(int tipo, int saldo)
            {
                switch (tipo)
                {
                    case 1: return new FIAMM(saldo);
                    case 2: return new FIM(saldo);
                    default: return new FIAMM(saldo);
                }
            }
        }
        class FactoriaExtendida : FactoriaFondo
        {
            public new FondoInversion CrearFondoInversion(int tipo, int saldo)
            {
                switch (tipo)
                {
                    case 1: return new FIAMM(saldo);
                    case 2: return new FIM(saldo);
                    default: return new FIM(saldo);
                }
            }
        }
    }
}
