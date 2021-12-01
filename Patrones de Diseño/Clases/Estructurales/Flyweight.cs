using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Estructurales
{
    public class ProgramFlywight
    {
      public static void ProgramFlywightTest(string[] args)
        {
            int i = 0;
            List<int> Americana = new List<int>();
            List<int> Italiana = new List<int>();
            List<int> Mexicana = new List<int>();
            FlyweightFactory fly = new FlyweightFactory();
            i = fly.add("Hamburguesa");
            Americana.Add(i);
            foreach (int n in Americana)
            {
                Receta receta = (Receta)fly[n];
                receta.CalcularCosto();
                receta.Mostrar();
            }
            Console.ReadLine();
        }
    }
   
    public interface IFlyweight //sera implementada por cada clase que vaya a crear objetos de tipo Flyweight
    {
        void ColocarNombre(string pNombre);
        void CalcularCosto();
        void Mostrar();
        string ObtenNombre();
    }
    class Receta : IFlyweight
    {
        private string nombre;
        private double costo;
        private double venta;

        public void CalcularCosto()
        {
            foreach (char letra in nombre)
                costo += (int)letra;
            venta = costo * 1.30;

        }

        public void ColocarNombre(string pNombre)
        {
            nombre = pNombre;
        }

        public void Mostrar()
        {
            Console.WriteLine("{0} cuesta {1}", nombre, venta);
        }

        public string ObtenNombre()
        {
            return nombre;
        }


    }
    public class FlyweightFactory
    {
        private List<IFlyweight> flyweight = new List<IFlyweight>();
        private int conteo = 0;  // the name field
        public int Conteo { get { return conteo; } set { conteo = value; } }

        public int add(string pNombre)
        {
            bool existe = false;
            foreach (IFlyweight f in flyweight)
            {
                if (f.ObtenNombre() == pNombre)
                    existe = true;
            }
            if (existe)
            {
                Console.WriteLine("El objeto ya existe, no se ha adicionado");
                return -1;
            }
            else
            {
                Receta miReceta = new Receta();
                miReceta.ColocarNombre(pNombre);
                flyweight.Add(miReceta);
                conteo = flyweight.Count;

                return conteo - 1;
            }

        }
        public IFlyweight this[int index]
        {
            get { return flyweight[index]; }

        }

    }
}
