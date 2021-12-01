using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Comportamiento
{
    public class Command
    {
        public class ProgramCommand
        {
            public static void CommandTest(string[] args)
            {
                Automovil auto = new Automovil();
                Control control = new Control(auto);
                string accion;
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Ejecute una opcion");
                    Console.WriteLine("1. Encerder Automovil");
                    Console.WriteLine("2. Apagar Automovil");
                    Console.WriteLine("3. Encender Alarma");
                    Console.WriteLine("4. Apagar Alarma");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("5. Salir");
                    Console.ForegroundColor = ConsoleColor.White;
                    accion = Console.ReadLine();
                    if (accion == "1")
                        control.Boton(0);
                    if (accion == "2")
                        control.Boton(1);
                    if (accion == "3")
                        control.Boton(2);
                    if (accion == "4")
                        control.Boton(3);
                } while (accion != "5");
            }
            interface ICommand
            {
                void ejecutar();
            }
            class Automovil
            {
                public void Encender()
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("El auto se ha encendido");
                }
                public void Apagar()
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El auto se ha apagado");
                }
                public void PrenderAlarma()
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Alarma encendida");
                }
                public void ApagarAlarma()
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Alarma apagada");
                }
            }
            class Control
            {
                private ICommand[] comandos = new ICommand[4];
                public Control(Automovil pAuto)
                {
                    comandos[0] = new ComandoEncender(pAuto);
                    comandos[1] = new ComandoApagar(pAuto);
                    comandos[2] = new ComandoEncenderAlarma(pAuto);
                    comandos[3] = new ComandoApagarAlarma(pAuto);
                }
                public void Boton(int pIndice)
                {
                    comandos[pIndice].ejecutar();
                }
            }
            class ComandoEncender : ICommand
            {
                Automovil auto;
                public ComandoEncender(Automovil pAuto)
                {
                    auto = pAuto;
                }
                public void ejecutar()
                {
                    auto.Encender();
                }
            }
            class ComandoApagar : ICommand
            {
                Automovil auto;
                public ComandoApagar(Automovil pAuto)
                {
                    auto = pAuto;
                }
                public void ejecutar()
                {
                    auto.Apagar();
                }
            }
            class ComandoEncenderAlarma : ICommand
            {
                Automovil auto;
                public ComandoEncenderAlarma(Automovil pAuto)
                {
                    auto = pAuto;
                }
                public void ejecutar()
                {
                    auto.PrenderAlarma();
                }
            }
            class ComandoApagarAlarma : ICommand
            {
                Automovil auto;
                public ComandoApagarAlarma(Automovil pAuto)
                {
                    auto = pAuto;
                }
                public void ejecutar()
                {
                    auto.ApagarAlarma();
                }
            }
        }
    }
}
