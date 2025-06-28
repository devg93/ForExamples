using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Observer.Contracts
{
    public interface IEventManager
    {
        void Attach<T>(IObserver observer);


        void Detach<T>(IObserver observer);


        void Notify<T>(T value);


    }
}