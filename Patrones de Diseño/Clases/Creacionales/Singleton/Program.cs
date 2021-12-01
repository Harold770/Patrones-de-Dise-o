using System;
using System.Threading;

namespace patron_singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Singleton.Instancia.mensaje);
            Thread.Sleep(2000);
            Console.WriteLine("Reasignando datos");
            Thread.Sleep(2000);
            Singleton.Instancia.mensaje = "Hola mundo";
            Console.WriteLine("Cargando nuevos datos en la instancia");
            Console.Write(".");
            Thread.Sleep(900);
            Console.Write(".");
            Thread.Sleep(900);
            Console.Write(".");
            Thread.Sleep(900);
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.WriteLine("Mostrando datos");
            Thread.Sleep(2000);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Singleton.Instancia.mensaje);
                Thread.Sleep(200);

            }
            Console.WriteLine("Create by Fernando Cancino");
            Console.ReadKey();
        }
        public class Singleton
        {
            private static Singleton instancia = null;
            public string mensaje = "";
            protected Singleton()
            {
                mensaje = "instancia cargada";
            }
            public static Singleton Instancia
            {
                get
                {
                    if (instancia == null)
                        instancia = new Singleton();
                    return instancia;
                }
            }
        }
    }
}
