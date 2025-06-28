

using Observer.Contracts;

namespace Observer
{
    public class EventManager:IEventManager
    {
        volatile List<IObserver> observers = new();
        private readonly object _lock = new object();

        public void Attach<T>(IObserver observer)
        {
            lock(_lock)
            {
                if (!observers.Contains(observer))
                {
                    observers.Add(observer);
                }
            }
        }

        public void Detach<T>(IObserver observer)
        {
            lock(_lock)
            {
                if (observers.Contains(observer))
                {
                    observers.Remove(observer);
                }
            }
            
        }

        public void Notify<T>(T value)
        {
            lock(_lock)
            {
                foreach (var observer in observers)
                {
                    observer.Event(value);
                }
            }
            
        }
    }
    
}