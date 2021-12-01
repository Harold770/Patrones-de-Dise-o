using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Estructurales
{
    public class Bridge
    {
        public class ProgramBridge
        {
            public static void BrindgeTest(string[] args)
            {
                Dictionary<string, double> productos = new Dictionary<string, double>();
                productos.Add("CProt-1", 50.00);
                productos.Add("CProt-2", 15.00);
                productos.Add("BProt-3", 40.00);
                productos.Add("BProt-4", 39.99);
                productos.Add("AProt-5", 18.10);
                productos.Add("CProt-5", 20.10);
                Console.WriteLine("1. Version 1");
                Console.WriteLine("2. Version 2");
                Console.Write("Escribe el número de la version a consultar:");
                int imp = Convert.ToInt16(Console.ReadLine());
                CAbstraccion bridge = new CAbstraccion(imp, productos);
                Console.Clear();
                bridge.MostrarTotales();
                bridge.Listar();
            }
        }
        interface IBridge
        {
            void MostrarTotales(Dictionary<string, double> pProductos);
            void ListarProductos(Dictionary<string, double> pProductos);

        }
        internal class CImplementacion3 : IBridge
        {
            public void MostrarTotales(Dictionary<string, double> pProductos)
            {
                double total = 0;
                double totalA = 0;
                double totalB = 0;
                double totalC = 0;
                int cantidad = 0;
                foreach (KeyValuePair<string, double> p in pProductos)
                {
                    total += p.Value;
                    if (p.Key[0] == 'A')
                        totalA += p.Value;
                    if (p.Key[0] == 'B')
                        totalB += p.Value;
                    if (p.Key[0] == 'C')
                        totalC += p.Value;
                    cantidad++;
                }
                Console.WriteLine("El total de Productos A es de ${0} que es igual a {1}% de todos los productos", totalA, total * 100);
                Console.WriteLine("El total de Productos C es de ${0} que es igual a {1}% de todos los productos", totalB, total * 100);
                Console.WriteLine("El total de Productos B es de ${0} que es igual a {1}% de todos los productos", totalC, total * 100);
                Console.WriteLine("El total de {0} productos es de ${1} ", cantidad, total);

            }
            public void ListarProductos(Dictionary<string, double> pProductos)
            {
                foreach (KeyValuePair<string, double> p in pProductos)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (p.Key[0] == 'A')
                        Console.WriteLine("{0} - {1}", p.Key, p.Value);
                }
                foreach (KeyValuePair<string, double> p in pProductos)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (p.Key[0] == 'B')
                        Console.WriteLine("{0} - {1}", p.Key, p.Value);
                }
                foreach (KeyValuePair<string, double> p in pProductos)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (p.Key[0] == 'C')
                        Console.WriteLine("{0} - {1}", p.Key, p.Value);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Presione una tecla para cerrar...");
                Console.ReadKey();
            }
        }
        internal class CImplementacion2 : IBridge
        {
            public void MostrarTotales(Dictionary<string, double> pProductos)
            {
                double total = 0;
                double totalA = 0;
                double totalB = 0;
                double totalC = 0;
                int cantidad = 0;
                foreach (KeyValuePair<string, double> p in pProductos)
                {
                    total += p.Value;
                    if (p.Key[0] == 'A')
                        totalA += p.Value;
                    if (p.Key[0] == 'B')
                        totalB += p.Value;
                    if (p.Key[0] == 'C')
                        totalC += p.Value;
                    cantidad++;
                }
                Console.WriteLine("El total de Productos A es de ${0}", totalA);
                Console.WriteLine("El total de Productos C es de ${0}", totalB);
                Console.WriteLine("El total de Productos B es de ${0}", totalC);
                Console.WriteLine("El total de {0} productos es de ${1}", cantidad, total);

            }
            public void ListarProductos(Dictionary<string, double> pProductos)
            {
                foreach (KeyValuePair<string, double> p in pProductos)
                {
                    if (p.Key[0] == 'A')
                        Console.ForegroundColor = ConsoleColor.Blue;
                    if (p.Key[0] == 'B')
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    if (p.Key[0] == 'C')
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} - {1}", p.Key, p.Value);
                }
                Console.Write("Presione una tecla para cerrar...");
                Console.ReadKey();
            }
        }
        class CImplementacion1 : IBridge
        {
            public void MostrarTotales(Dictionary<string, double> pProductos)
            {
                double total = 0;
                int cantidad = 0;
                foreach (KeyValuePair<string, double> p in pProductos)
                {
                    total += p.Value;
                    cantidad++;
                }
                Console.WriteLine("El total de {0} productos es de ${1}", cantidad, total);
            }
            public void ListarProductos(Dictionary<string, double> pProductos)
            {
                foreach (KeyValuePair<string, double> p in pProductos)
                {
                    Console.WriteLine(p.Key);
                }
                Console.Write("Presione una tecla para cerrar...");
                Console.ReadKey();
            }
        }
        class CAbstraccion
        {
            IBridge implementacion;
            Dictionary<string, double> productos;
            public CAbstraccion(IBridge pImp, Dictionary<string, double> pProd)
            {
                implementacion = pImp;
                productos = pProd;
            }
            public CAbstraccion(int pTipo, Dictionary<string, double> pProd)
            {
                if (pTipo == 1)
                    implementacion = new CImplementacion1();
                if (pTipo == 2)
                    implementacion = new CImplementacion2();
                if (pTipo == 3)
                    implementacion = new CImplementacion3();
                productos = pProd;
            }
            public void MostrarTotales()
            {
                implementacion.MostrarTotales(productos);
            }
            public void Listar()
            {
                implementacion.ListarProductos(productos);
            }

        }
    }
}
