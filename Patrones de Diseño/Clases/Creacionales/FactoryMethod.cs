using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Creacionales
{

    /*Define una interfaz para crear un objeto, pero dejak
    que sean las subclases quienes decidan qué clase
    instanciar. Permite que una clase delegue en sus
    subclases la creación de objetos.*/

    /*Este patrón puede ser utilizado cuando:
    • Una clase no puede anticipar el tipo de objeto
      que debe crear.
    • Subclases pueden especificar qué objetos deben
      ser creados*/
    public class programFactory
    {
        public static void programFactoryTest(string[] args)
        {
            string Fondo;
            FactoriaFondo factoria = new FactoriaFIAMM(); // se instancia un Factoria fondo como un nuevo FactoriaFIM (FIM tipo de fondo de inversion)
            Console.WriteLine("Introduzca un fondo de inversion");
            Fondo = Console.ReadLine();
            FondoInversion fondo = factoria.crearFondoInversion(int.Parse(Fondo));
            Console.WriteLine("Mi fondo es = " + fondo.saldo + " ," + fondo.toString());
            Console.ReadKey();
        }


    }
    public abstract class FondoInversion //clase padre
    {
        public int saldo;
        protected string nombre;
        public string toString()
        {
            return nombre;
        }
    }
    class FIAMM : FondoInversion //tipo de fondo de inversion FIAMM el cual hereda de la clase padre Fondo de inversion
    {
        public FIAMM(int s)
        {
            saldo = s;
            nombre = "FIAAM";
        }
    }
    class FIM : FondoInversion //tipo de fondo de inversion FIM el cual hereda de la clase padre Fondo de inversion
    {
        public FIM(int s)
        {
            saldo = s;
            nombre = "FIM";
        }
    }
    abstract class FactoriaFondo // instancia un objeto u otro dependiendo del tipo que solicitemos FIM o FIAMM
    {
        public abstract FondoInversion crearFondoInversion(int saldo);
    }
    class FactoriaFIAMM : FactoriaFondo // Clase FactoriaFiamm que hereda de la clase anterior, obligando a implementar el mismo metodo Crearfondodeinversion devolviendo el tipo de fondo a crear en este caso el FIAMM
    {
        public override FondoInversion crearFondoInversion(int saldo)
        {
            return new FIAMM(saldo);
        }

    }
    class FactoriaFIM : FactoriaFondo // Clase FactoriaFiamm que hereda de la clase anterior, obligando a implementar el mismo metodo Crearfondodeinversion devolviendo el tipo de fondo a crear en este caso el FIM
    {
        public override FondoInversion crearFondoInversion(int saldo)
        {
            return new FIM(saldo);
        }
    }
}
