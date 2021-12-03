using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Comportamiento
{
    public interface MensajesGlobales
    {
        void EnviarMensaje(string msg, User user);
        void AñadirUsuario(User user);
    }

    public class ConcreteFacebookGroupMediator : MensajesGlobales
    {
        private List<User> usersList = new List<User>();
        public void AñadirUsuario(User user)
        {
            usersList.Add(user);
        }
        public void EnviarMensaje(string message, User user)
        {
            foreach (var u in usersList)
            {
                // message should not be received by the user sending it
                if (u != user)
                {
                    u.Receive(message);
                }
            }
        }
    }

    public abstract class User
    {
        protected MensajesGlobales mediator;
        protected string name;
        public User(MensajesGlobales mediator, string name)
        {
            this.mediator = mediator;
            this.name = name;
        }
        public abstract void Send(string message);
        public abstract void Receive(string message);
    }
    public class ConcreteUser : User
    {
        public ConcreteUser(MensajesGlobales mediator, string name) : base(mediator, name)
        {
        }
        public override void Receive(string message)
        {
            Console.WriteLine(this.name + ": Mensaje Recibido: " + message);
        }
        public override void Send(string message)
        {
            Console.WriteLine(this.name + ": Enviando Mensaje: " + message + "\n");
            mediator.EnviarMensaje(message, this);
        }
    }

    class ProgramMediator
    {
        public static void MediatorTest(string[] args)
        {
            MensajesGlobales MsgMediador = new ConcreteFacebookGroupMediator();
            User James = new ConcreteUser(MsgMediador, "James");
            User Ninive = new ConcreteUser(MsgMediador, "Nínive");
            User David = new ConcreteUser(MsgMediador, "David");
            User Harold = new ConcreteUser(MsgMediador, "Harold");
            MsgMediador.AñadirUsuario(James);
            MsgMediador.AñadirUsuario(Ninive);
            MsgMediador.AñadirUsuario(David);
            MsgMediador.AñadirUsuario(Harold);
            James.Send("Buenos Días tenemos junta hoy");
            Console.WriteLine();
            Harold.Send("Que flojera");
            Console.Read();
        }
    }
}
