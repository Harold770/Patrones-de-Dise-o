using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Creacionales
{
    internal class Builder
    {
       
    }

    public interface Ibuilder
    {
        void BuildManilla();
        void BuildRuedaDelantera();
        void BuildRuedaTrasera();
        void BuildCuadro();
        void BuildAsiento();
        void BuildPedales();
        void BuildPlato();
        void BuildTimbre();
        void BuildEspejos();
        void BuildColor();
        void BuildPortaBotellas();
        void BuildFrenos();

    }

    public class ConcreteBuilder : Ibuilder
    {
        private Bicicleta bicicleta = new Bicicleta();

        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.bicicleta = new Bicicleta();
        }

        public void BuildCuadro() { this.bicicleta.Añadir("Cuadro"); }
        public void BuildPedales() { this.bicicleta.Añadir("Pedales"); }
        public void BuildTimbre() { this.bicicleta.Añadir("Timbre"); }
        public void BuildEspejos() { this.bicicleta.Añadir("Espejos"); }
        public void BuildPortaBotellas() { this.bicicleta.Añadir("Porta Botellas"); }
        public void BuildFrenos() { this.bicicleta.Añadir("Frenos"); }
        public void BuildPlato() { this.bicicleta.Añadir("Plato"); }
        public void BuildAsiento() { this.bicicleta.Añadir("Asiento"); }
        public void BuildColor() { this.bicicleta.Añadir("Color"); }
        public void BuildRuedaDelantera() { this.bicicleta.Añadir("Ruedas Delanteras"); }
        public void BuildRuedaTrasera() { this.bicicleta.Añadir("Ruedas Traseras"); }
        public void BuildManilla() { }

        public Bicicleta GetProduct()
        {
            Bicicleta result = this.bicicleta;

            this.Reset();

            return result;
        }
    }

    public class Bicicleta
    {
        private List<object> partes = new List<object>();
        public void Añadir(string part)
        {
            this.partes.Add(part);
        }

        public string ListarPartes()
        {
            string str = string.Empty;
            
            for (int i = 0; i < this.partes.Count; i++)
            {
                str += this.partes[i] + ", ";
            }
            str = str.Remove(str.Length - 2);

            return "Partes del producto: " + str + "\n";
        }
    }

    public class Director
    {
        private Ibuilder _builder;

        public Ibuilder Builder
        {
            set { _builder = value; }
        }

        public void BicletaBasica()
        {
            this._builder.BuildCuadro();
            this._builder.BuildAsiento();
            this._builder.BuildPlato();
            this._builder.BuildPedales();
            this._builder.BuildFrenos();
            this._builder.BuildColor();
            this._builder.BuildRuedaDelantera();
            this._builder.BuildRuedaTrasera();

        }

        public void BicletaCompleta()
        {
            this._builder.BuildCuadro();
            this._builder.BuildAsiento();
            this._builder.BuildPlato();
            this._builder.BuildPedales();
            this._builder.BuildFrenos();
            this._builder.BuildColor();
            this._builder.BuildPortaBotellas();
            this._builder.BuildEspejos();
            this._builder.BuildTimbre();

        }
    }

    public class ProgramBuilder
    {
        public static void BuildTest(string[] args)
        {
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Producto Basico:");
            director.BicletaBasica();
            Console.WriteLine(builder.GetProduct().ListarPartes());

            Console.WriteLine("Prodcto con todas las caracteristicas");
            director.BicletaCompleta();
            Console.WriteLine(builder.GetProduct().ListarPartes());

            // Remember, the Builder pattern can be used without a Director
            // class.
            Console.WriteLine("Producto Personalizado");
            builder.BuildCuadro();
            builder.BuildAsiento();
            builder.BuildPlato();
            builder.BuildPedales();
            builder.BuildFrenos();
            builder.BuildColor();
            builder.BuildRuedaTrasera();
            builder.BuildRuedaDelantera();
            builder.BuildEspejos();
            Console.Write(builder.GetProduct().ListarPartes());
        }
    }
}

