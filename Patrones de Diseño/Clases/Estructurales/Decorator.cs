using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Estructurales
{
    public class Decorator
    {
        public class ProgramDecorator
        {
            public static void DecoratorTest(string[] args)
            {

                Bebidas cafe = new CafePuro();
                cafe = new Leche(cafe);
                cafe = new Azucar(cafe);
                Console.WriteLine("El prodcuto {0} tiene un costo de {1}", cafe.Descripcion, cafe.Costo);
                Console.ReadKey();
            }
        }
        public abstract class Bebidas
        {
            public abstract double Costo { get; }
            public abstract string Descripcion { get; }

        }
        public class Azucar : Agregado
        {
            public Azucar(Bebidas bebida) : base(bebida) { }
            public override double Costo => bebida.Costo + 5;
            public override string Descripcion => string.Format("{0} + Azucar ", bebida.Descripcion);
        }
        public class Leche : Agregado
        {
            public Leche(Bebidas bebida) : base(bebida) { }
            public override double Costo => bebida.Costo + 10;
            public override string Descripcion => string.Format("{0} + Leche", bebida.Descripcion);
        }
        public abstract class Agregado : Bebidas
        {
            protected Bebidas bebida;
            public Agregado(Bebidas _bebida)
            {
                bebida = _bebida;
            }
        }
        public class CafeExpres : Bebidas
        {
            public override double Costo => 10;
            public override string Descripcion => "Cafe puro";
        }
        public class CafePuro : Bebidas
        {
            public override double Costo => 10;
            public override string Descripcion => "Cafe puro";

        }
    }
}
