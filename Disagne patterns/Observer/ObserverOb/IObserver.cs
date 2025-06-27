using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Observer.ObserverOb
{
    public interface IObserver
    {
        // Receive update from subject
        void Update(ISubject subject);

    }
}