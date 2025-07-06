public class MyChannel<T> where T : class
{
    private readonly int Capacity;
    private readonly Queue<T> repository = new();
    private readonly SemaphoreSlim _freeSpace;
    private readonly SemaphoreSlim _availableItems = new(0);
    private readonly object Locker = new();

    public MyChannel(int capacity)
    {
        Capacity = capacity;
        _freeSpace = new SemaphoreSlim(capacity); // დასაშვები მაქს რაოდენობა
    }

    public async ValueTask WriteAsync(T value)
    {
        await _freeSpace.WaitAsync(); // დაელოდე სანამ ადგილი გამოჩნდება

        lock (Locker)
        {
            repository.Enqueue(value);
        }

        _availableItems.Release(); // ჩავამატეთ ელემენტი – წამკითხავს მივეცით ნიშანი
    }

    public async ValueTask<T> ReadAsync()
    {
        await _availableItems.WaitAsync(); // დაველოდოთ სანამ ახალი ელემენტი იქნება

        T item;
        lock (Locker)
        {
            item = repository.Dequeue();
        }

        _freeSpace.Release(); // წამკითხა → ერთი ადგილი გათავისუფლდა
        return item;
    }

    public int Count
    {
        get
        {
            lock (Locker)
            {
                return repository.Count;
            }
        }
    }

    public bool TryWrite(T value)
    {
        if (_freeSpace.Wait(0)) // არ დაელოდოს — თუ ადგილი არაა, დააბრუნოს false
        {
            lock (Locker)
            {
                repository.Enqueue(value);
            }

            _availableItems.Release();
            return true;
        }

        return false;
    }
}
