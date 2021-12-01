using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Patrones_de_Diseño.Clases.Comportamiento.State;

namespace Patrones_de_Diseño.Clases.Comportamiento
{
    public class ProgramState
    {
        public static void ProgramStateTest(string[] args)
        {
            Alarma alarma = new Alarma();
            Activa activo = new Activa();
            Mantenimiento mantenimiento = new Mantenimiento();
            int opcionSwitch = 0;
            do
            {
                muestraMenu();
                string opcion = Console.ReadLine();
                opcionSwitch = int.Parse(opcion);

                switch (opcionSwitch)
                {
                    case 1:
                        alarma.setEstado(activo);
                        break;
                    case 2:
                        alarma.setEstado(mantenimiento);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                alarma.ejecutarAccion();
            } while (opcionSwitch != 0);
            Console.ReadKey();
        }

    }

    public class State
    {
        //el objetivo de este patron es permitir a este objeto cambiar su comportamiento dependiendo del estado en el que se encuentra
        public static void muestraMenu()
        {
            Console.WriteLine("Selecciona el estado de la alarma");
            Console.WriteLine("1 - ACTIVA");
            Console.WriteLine("2 - Mantenimiento");
            Console.WriteLine("0 - Salir");
        }

        public interface Estado
        {
            void ejecutarAccion();
        }
        public class Activa : Estado
        {
            public void ejecutarAccion()
            {
                Console.WriteLine("Estado Activo: Atento");
            }
        }
        public class Mantenimiento : Estado
        {
            public void ejecutarAccion()
            {
                Console.WriteLine("Estado en mantenimiento: No atento");
                Console.WriteLine("Enviar Correo para informar estado");
            }
        }
        public class Alarma
        {
            private Estado miestado;
            public void setEstado(Estado e)
            {
                this.miestado = e;
            }
            public void ejecutarAccion()
            {
                miestado.ejecutarAccion();
            }
        }
    }
}
