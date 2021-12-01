using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Comportamiento
{
    class Context
    {
        private IStrategy _strategy;

        public Context()
        { }

        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Programa para la rutina de la lavadora");
            var result = this._strategy.DoAlgorithm(new List<string> { "Lavado","Secado","Enjuague" });

            string resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }

    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }

    class ConcreteStrategyToallas : IStrategy
    {
        public object DoAlgorithm(object ropa)
        {
            var list = ropa as List<string>;

            return list;
        }
    }

    class ConcreteStrategyLigera : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Clear();
            list.Add("Lavado Suave");
            list.Add("Enjuague");
            list.Add("Secado con Aire");

            return list;
        }
    }

    class ConcreteStrategyZapatos : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Add("Secado con Aire Caliente");

            return list;
        }
    }

    public class ProgramStrategy
    {
       public static void StrategyTest(string[] args)
        {
            var context = new Context();

            Console.WriteLine("El cliente selecciona la funcion para toallas");
            context.SetStrategy(new ConcreteStrategyToallas());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("El cliente selecciona la funcion para ropa ligera");
            context.SetStrategy(new ConcreteStrategyLigera());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("El cliente selecciona la funcion para zapatos");
            context.SetStrategy(new ConcreteStrategyZapatos());
            context.DoSomeBusinessLogic();
        }
    }

}
