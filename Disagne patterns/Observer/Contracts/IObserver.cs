

namespace Observer.Contracts
{
    public interface IObserver
    {
        void Event<T>(T value);

    }
}