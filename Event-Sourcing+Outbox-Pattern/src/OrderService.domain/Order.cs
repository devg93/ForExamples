using OrderService.domain.Abstractions;

namespace OrderService.domain;


public class Order
{
    public int Id { get; private set; }
    public string CustomerName { get; private set; }
    public decimal Amount { get; private set; }

    private readonly List<IDomainEvent> _events = new();
    public IReadOnlyCollection<IDomainEvent> Events => _events;

    public Order(string customerName, decimal amount)
    {

        CustomerName = customerName;
        Amount = amount;

        _events.Add(new OrderCreatedEvent(Id, CustomerName, Amount));
    }
    public void ClearEvents()
    {
        _events.Clear();
    }
}

