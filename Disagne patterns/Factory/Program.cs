public class ServiceA : IService
{
    public void Speak()
    {
        Console.WriteLine("service A ");
    }
}
public class ServiceB : IService
{
    public void Speak()
    {
       Console.WriteLine("service A ");
    }
}


public interface IService
{
    void Speak();
}


public static class ServiceFactory
{
    public static IService CreateService(int key)
    {
        return key switch
        {
            1 => new ServiceA(),
            2 => new ServiceB(),
            _ => throw new ArgumentException("Unknown key type")

        };
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        IService animal = ServiceFactory.CreateService(1);
        animal.Speak();
        int key = 4;
        if (key == 1)
        {
            animal.Speak();
        }

    }
}