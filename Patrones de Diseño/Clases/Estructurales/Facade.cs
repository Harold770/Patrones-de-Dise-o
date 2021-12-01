using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckFachada cliente1 = new CheckFachada();
            cliente1.buscar("02/07/2018", "08/07/2018", "Lima", "Cancún");
            CheckFachada cliente2 = new CheckFachada();
            cliente2.buscar("02/07/2018", "08/07/2018", "Lima", "Quito");
            Console.ReadLine();
        }
        public class avionapi
        {
            public void buscarvuelos(string fechaida, string fechavuelta, string origen, string destino)
            {
                Console.WriteLine("Vuelos encontrados para " + destino + " desde " + origen);
                Console.WriteLine("Fecha Ida: " + fechaida + " fecha vuelta: " + fechavuelta);
            }
        }
        public class hotelapi
        {
            public void buscarhoteles(string fechaEntrada, string fechaSalida, string origen, string destino)
            {
                Console.WriteLine("Hoteles encontrados");
                Console.WriteLine("Entrada: " + fechaEntrada + " Salida: " + fechaSalida);
                Console.WriteLine("Hotel A");
                Console.WriteLine("Hotel B");

            }
        }

        public class CheckFachada
        {
            private avionapi AvionApi;
            private hotelapi HotelApi;

            public CheckFachada()
            {
                AvionApi = new avionapi();
                HotelApi = new hotelapi();
            }

            public void buscar(string fechaIda, string fechavuelta, string origen, string destino)
            {
                AvionApi.buscarvuelos(fechaIda, fechavuelta, origen, destino);
                HotelApi.buscarhoteles(fechaIda, fechavuelta, origen, destino);
            }
        }
    }
}
