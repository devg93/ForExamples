using Observer;
using Observer.Contracts;
using Observer.Cusomer;

public class Program
{

    public static void Main(string[] args)
    {
        // Example usage of the EventManager
        IEventManager eventManager = new EventManager();
        eventManager.Attach<CusomerA>(new CusomerA());
        eventManager.Attach<CusomerB>(new CusomerB());

        eventManager.Notify("Hello, Observers!");
        // Create observers and attach them to the event manager
        // var observer1 = new ConcreteObserver();
        // eventManager.Attach(observer1);

        // Notify observers with some value
        // eventManager.Notify("Hello, Observers!");

        // Detach an observer
        // eventManager.Detach(observer1);
    }
}