using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Comportamiento
{
    class Memento
    {
        public class ProgramMemento
        {
            public static void MementoTest(string[] args)
            {
                Constructor auto = new Constructor("Focus", 2019, 300000);
                auto.Mostrar();
                CareTaker taker = new CareTaker();
                taker.memento = auto.CrearMemento();
                auto.Nombre = "Audi R8";
                auto.Modelo = 2020;
                auto.Costo = 3500000;
                auto.Mostrar();
                auto.Restaurar(taker.memento);
                auto.Mostrar();
                Console.ReadKey();
            }
            [Serializable]
            class Constructor
            {
                public string Nombre { get; set; }
                public int Modelo { get; set; }
                public double Costo { get; set; }

                public Constructor(string _Nombre, int _Modelo, double _Costo)
                {
                    Nombre = _Nombre;
                    Modelo = _Modelo;
                    Costo = _Costo;
                }
                public void Mostrar()
                {
                    Console.WriteLine("{0}-{1} con un costo de {2}", Nombre, Modelo, Costo);
                }
                public Memento CrearMemento()
                {
                    Memento memento = new Memento();
                    memento.Guardar(this);
                    return memento;
                }
                public void Restaurar(Memento memento)
                {
                    Constructor temp = memento.Restaurar();
                    Nombre = temp.Nombre;
                    Modelo = temp.Modelo;
                    Costo = temp.Costo;
                }

            }
            public class Memento
            {
                internal void Guardar(Constructor obj)
                {
                    BinaryFormatter reset = new BinaryFormatter();
                    Stream stream = new FileStream("Autos.out", FileMode.Create, FileAccess.Write, FileShare.None);
                    reset.Serialize(stream, obj);
                    stream.Close();
                    Console.WriteLine("archivo guardado");
                }
                internal Constructor Restaurar()
                {
                    BinaryFormatter reset = new BinaryFormatter();
                    Stream stream = new FileStream("Autos.out", FileMode.Open, FileAccess.Read, FileShare.None);
                    Constructor temp = (Constructor)reset.Deserialize(stream);
                    stream.Close();
                    Console.WriteLine("Se han restaurado los datos");
                    return temp;
                }
            }
            class CareTaker
            {
                public Memento memento { get; set; }
            }
        }
    }
}
