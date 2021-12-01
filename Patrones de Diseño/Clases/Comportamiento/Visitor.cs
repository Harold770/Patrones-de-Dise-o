using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Comportamiento
{
    class Visitor
    {
        public class ProgramVisitor
        {
            public static void visitorTest(string[] args)
            {
                double totalCosto = 0;
                int totalObjetos = 0;
                int totalclasificaciones = 0;
                Elemento estructuraObjeto =
                new Elemento(89.0, "Botiquin",
                new Elemento(25.60, "Termometro",
                new ElementoL(
                    new Elemento(35.8, "Antibiotico",
                    new Elemento(15.5, "Antiacido",
                        new ElementoL(
                            new Elemento(12.8, "Aspirina", null),
                            new Elemento(56.6, "Anti inflamatorio",
                            null)))),
                new Elemento(12.8, "Gasa",
                new Elemento(23.5, "Cinta",
                new Elemento(112.5, "Tijeras", null))))));
                Visitante visitante = new Visitante();
                visitante.ContarElementos(estructuraObjeto);
                totalCosto = visitante.Total;
                totalclasificaciones = visitante.Clasificacion;
                totalObjetos = visitante.Conteo;
                Console.WriteLine("Se tienen {0} objetos con un costo de {1} en {2} clasificaciones", totalObjetos, totalCosto, totalclasificaciones);
                Console.ReadKey();
            }
        }
        interface IVisitor
        {
            void Visitar(Elemento pElemento);
            void Visitar(ElementoL pElemento);
        }
        interface IElement
        {
            void Aceptar(IVisitor pVisitante);
        }
        class Elemento : IElement
        {
            public Elemento siguiente;
            public Elemento hijo;
            public double Costo { get; set; }
            public string Nombre { get; set; }
            public Elemento()
            {
                Console.WriteLine("Elemento Creado");
            }
            public Elemento(double pCosto, string pNombre, Elemento pSiguiente)
            {
                Console.WriteLine("Elemento creado seguido por {0} => ${1}", pNombre, pCosto);
                siguiente = pSiguiente;
                Costo = pCosto;
                Nombre = pNombre;

            }

            public virtual void Aceptar(IVisitor pvisitante)
            {
                pvisitante.Visitar(this);
            }


        }
        class ElementoL : Elemento
        {
            public ElementoL(Elemento pHijo, Elemento pSiguiente)
            {
                hijo = pHijo;
                siguiente = pSiguiente;
            }
            public override void Aceptar(IVisitor pvisitante)
            {
                pvisitante.Visitar(this);
            }
        }
        class Visitante : IVisitor
        {
            public int Conteo { get; set; }
            public int Clasificacion { get; set; }
            public double Total { get; set; }
            public void ContarElementos(Elemento elemento)
            {
                elemento.Aceptar(this);
                if (elemento.hijo != null)
                    ContarElementos(elemento.hijo);
                if (elemento.siguiente != null)
                    ContarElementos(elemento.siguiente);
            }
            public void Visitar(Elemento elemento)
            {
                Conteo++;
                Total += elemento.Costo;
            }
            public void Visitar(ElementoL elemento)
            {
                Clasificacion++;
                Console.WriteLine("No existen elementos");
            }
        }
    }
}
