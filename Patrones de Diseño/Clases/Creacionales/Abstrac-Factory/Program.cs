using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron_abstrac_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Restauran restauran;
            restauran = new restauranChino();
            Menu menu = restauran.mostrarmenu();
            Console.WriteLine("Menu Restauran chino: " + menu.MenuRestauran);

            restauran = new restauranMexicano();
            menu = restauran.mostrarmenu();
            Console.WriteLine("Menu Restauran mexicano: " + menu.MenuRestauran);
            Console.ReadKey();
        }
    }
}
