using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patrones_de_Diseño.Clases.Comportamiento
{
    public interface IObserver
    {
        void Actualizar(ISubject subject);
    }

    public interface ISubject
    {
        void Atar(IObserver observer);

        void Desatar(IObserver observer);

        void Notificar();
    }

    public class Subject : ISubject
    {
        public int State { get; set; } = -0;

        private List<IObserver> _observers = new List<IObserver>();

        // The subscription management methods.
        public void Atar(IObserver observer)
        {
            Console.WriteLine("Usuario suscrito a un boletín");
            this._observers.Add(observer);
        }

        public void Desatar(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Usuario desuscrito a un boletín");
        }

        
        public void Notificar()
        {
            Console.WriteLine("Se ha suscrito un usuario a este boletín");

            foreach (var observer in _observers)
            {
                observer.Actualizar(this);
            }
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.Notificar();
        }
    }

    class ConcreteObserverA : IObserver
    {
        public void Actualizar(ISubject subject)
        {
            if ((subject as Subject).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
    }

    class ConcreteObserverB : IObserver
    {
        public void Actualizar(ISubject subject)
        {
            if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }

    public class ProgramObserver
    {
        public static void ObserverTest(string[] args)
        {
            var subject = new Subject();
            var observerA = new ConcreteObserverA();
            subject.Atar(observerA);

            var observerB = new ConcreteObserverB();
            subject.Atar(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Desatar(observerB);

            subject.SomeBusinessLogic();
        }
    }
}
