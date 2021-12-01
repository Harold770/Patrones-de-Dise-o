using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Comportamiento
{
    //hace que varios objetos compartan el mismo algoritmo, haciendo que estos objetos hereden de una super clase
    public class ProgramTemplate
    {
      public  static void ProgramTemplateTest(string[] args)
        {
            Console.WriteLine("Cajero automatico con valor 1");
            CajeroAutomatico ca = new CajeroAutomatico("F678AB", 20, 1);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Cajero automatico con valir 2");
            ca.processar("F678AB", 20, 2);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Cajero  con valor 1");
            Cajero caj = new Cajero("ABC123", 1000, 1);
            Console.WriteLine("Cajero  con valor 2");
            caj.processar("ABC123", 1000, 2);
            Console.ReadLine();


        }
    }


    public abstract class CuentaBancaria
    {
        private string cuenta;
        private int saldo = 0;

        private void setCuenta(string c)
        {
            this.cuenta = c;
        }
        private void consignar(int i)
        {
            Console.WriteLine("Consignando......");
            this.saldo += i;
        }
        private void retirar(int i)
        {
            Console.WriteLine("Retirando......");
            if (i <= this.saldo - 10)
            {
                this.saldo -= i;
            }
            else
            {
                Console.WriteLine("No se puede retirar el monto");
            }
        }
        private void ConsultarSaldo()
        {
            Console.WriteLine("el saldo es " + this.saldo);
        }
        protected void auditoria()
        {
            Console.WriteLine("se ha procesado la cuenta " + this.cuenta);
        }

        public abstract void saludar();

        public void processar(string c, int i, int t)
        {
            saludar();
            setCuenta(c);
            switch (t)
            {
                case 1:
                    consignar(i);
                    break;
                case 2:
                    retirar(i);
                    break;
                default:
                    Console.Write("Opcion no valida");
                    break;

            }
            ConsultarSaldo();
            auditoria();
        }
    }

    public class CajeroAutomatico : CuentaBancaria
    {
        public CajeroAutomatico(string c, int i, int t)
        {
            processar(c, i, t);
        }
        public override void saludar()
        {
            Console.WriteLine("Ingrese los datos...........");
        }
    }

    public class Cajero : CuentaBancaria
    {
        public Cajero(string c, int i, int t)
        {
            processar(c, i, t);
        }
        public override void saludar()
        {
            Console.WriteLine("Bienvenido a su banco, en que le podemos ayudar?");
        }
        public new void auditoria()
        {
            auditoria();
            Console.WriteLine("Con mucho gusto, vuelva pronto");
        }
    }
}
