using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Creacionales
{
    public class AbstracFactory
    {
        public class ProgramAbstracFactory
        {
            public static void AbstracFactoryTest(string[] args)
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
        public abstract class Menu
        {
            protected string mimenu;

            public object MenuRestauran
            {
                get
                {
                    return mimenu;
                }
            }
        }
        public class MenuMexico : Menu
        {
            public MenuMexico()
            {
                mimenu = "-Panuchos - Tacos - Frijol con puerco";
            }
        }
        public class restauranMexicano : Restauran
        {
            public override Menu mostrarmenu()
            {
                return new MenuMexico();
            }
        }
        public class MenuChina : Menu
        {
            public MenuChina()
            {
                mimenu = "-pollo a la planca - arroz - pasta";
            }
        }
        public class restauranChino : Restauran
        {
            public override Menu mostrarmenu()
            {
                return new MenuChina();
            }
        }
        public abstract class Restauran
        {
            public abstract Menu mostrarmenu();
        }
    }
}
