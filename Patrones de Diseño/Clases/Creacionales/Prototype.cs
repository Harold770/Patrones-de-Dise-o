using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases
{
    public class Prototype
    {
        public string title;
        public DateTime publicationDate;
        public string text;

        public Prototype EqCopy()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public Prototype UpCopy()
        {
            Prototype clone = (Prototype) this.MemberwiseClone();
            clone.title = String.Copy("Titulo diferente");
            clone.text = String.Copy("Texto difente");
            return clone;
        }

        public class ProgramPrototype
        {
            public static void PrototypeTest(string[] args)
            {
                Prototype p1 = new Prototype();
                p1.title = "Hola Mundo";
                p1.publicationDate = DateTime.Now;
                p1.text = "Hello World";

                Prototype p2 = p1.EqCopy();
                Prototype p3 = p1.UpCopy();

                Console.WriteLine("Valores de los prototipados:"); Console.WriteLine();
                Console.WriteLine("Prototipo 1");
                Console.WriteLine(p1.title);
                Console.WriteLine(p1.publicationDate);
                Console.WriteLine(p1.text); Console.WriteLine();
                Console.WriteLine("Prototipo 2");
                Console.WriteLine(p2.title);
                Console.WriteLine(p2.publicationDate);
                Console.WriteLine(p2.text); Console.WriteLine();
                Console.WriteLine("Prototipo 3");
                Console.WriteLine(p3.title);
                Console.WriteLine(p3.publicationDate);
                Console.WriteLine(p3.text);
            }
        }
    }
}
