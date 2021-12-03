using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Patrones_de_Diseño.Clases.Estructurales
{
    public interface ITarget
    {
        string GetRequest(string p1, string p2);
    }

    // The Adaptee contains some useful behavior, but its interface is
    // incompatible with the existing client code. The Adaptee needs some
    // adaptation before the client code can use it.
    class Adaptador
    {
        public string GetSpecificRequest(string p1, string p2)
        {
            var request = new String[2];
            request[0] = p1;
            request[1] = p2;

            string json = JsonConvert.SerializeObject(request);
            return json.ToString();
        }
    }

    // The Adapter makes the Adaptee's interface compatible with the Target's
    // interface.
    class Adapter : ITarget
    {
        private readonly Adaptador _adaptee;

        public Adapter(Adaptador adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest(string parametro1, string parametro2)
        {
            return $"Esta es la respuesta como Json '{this._adaptee.GetSpecificRequest(parametro1, parametro2)}'";
        }
    }

    class ProgramAdapter
    {
        public static void AdapterTest(string[] args)
        {
            Adaptador adaptee = new Adaptador();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("La representacion de los datos es incompatible con el cliente.");
            Console.WriteLine("Pero el adaptador responde con el formato necesario");

            Console.WriteLine(target.GetRequest("Pedro", "Sola"));
        }
    }
}

