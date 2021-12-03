using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Estructurales
{
    public interface IComponent
    {
        void DisplayPrice();
    }

    public class Leaf : IComponent
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public Leaf(string name, int price)
        {
            this.Price = price;
            this.Name = name;
        }

        public void DisplayPrice()
        {
            Console.WriteLine(Name + " : " + Price);
        }
    }

    public class Composite : IComponent
    {
        public string Name { get; set; }
        List<IComponent> components = new List<IComponent>();
        public Composite(string name)
        {
            this.Name = name;
        }
        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public void DisplayPrice()
        {
            Console.WriteLine(Name);
            foreach (var item in components)
            {
                item.DisplayPrice();
            }
        }
    }

    public class ProgramComposite
    {
        public static void CompositeTest(string[] args)
        {

            IComponent hardDisk = new Leaf("Disco Duro", 2000);
            IComponent ram = new Leaf("RAM", 3000);
            IComponent cpu = new Leaf("CPU", 2000);
            IComponent mouse = new Leaf("Mouse", 2000);
            IComponent keyboard = new Leaf("Teclado", 2000);


            Composite motherBoard = new Composite("Tarjeta Madre");
            Composite cabinet = new Composite("Gabinete");
            Composite peripherals = new Composite("Perifericos");
            Composite computer = new Composite("Computadora");

            //Añadiendo la cpu y ram
            motherBoard.AddComponent(cpu);
            motherBoard.AddComponent(ram);
            //Añadiendo la tarjeta madre y la disco al gabinete
            cabinet.AddComponent(motherBoard);
            cabinet.AddComponent(hardDisk);
            //Añadiendo el mouse y teclado a la computadora
            peripherals.AddComponent(mouse);
            peripherals.AddComponent(keyboard);
            //Añadiendo gabinete y perifericos a la computadora
            computer.AddComponent(cabinet);
            computer.AddComponent(peripherals);


            computer.DisplayPrice();
            Console.WriteLine();

            keyboard.DisplayPrice();
            Console.WriteLine();

            cabinet.DisplayPrice();
            Console.Read();
        }
    }
}
