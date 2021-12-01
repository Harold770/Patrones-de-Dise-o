using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patrones_de_Diseño.Clases;
using Patrones_de_Diseño.Clases.Comportamiento;
using Patrones_de_Diseño.Clases.Creacionales;
using static Patrones_de_Diseño.Clases.Prototype;

namespace Patrones_de_Diseño
{
    internal class Program
    {
      static void Main(string[] args)
        {
            ProgramStrategy.StrategyTest(args);
            Console.ReadKey();
        }
       
    }
}
