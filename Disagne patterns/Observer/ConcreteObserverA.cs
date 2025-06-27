using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Observer.ObserverOb;

namespace Observer
{
    class ConcreteObserverA : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State < 3)
            {
        
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
    }
}