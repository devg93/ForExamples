using System;
using System.Text.Json;

namespace OrderService.domain
{
    public interface IDomainEvent { }

    public class OrderCreatedEvent : IDomainEvent
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }

        public OrderCreatedEvent() { } // Required for deserialization
        public OrderCreatedEvent(int id, string customerName, decimal amount)
        {
            Id = id;
            CustomerName = customerName;
            Amount = amount;
        }
    }


    public class OutboxMessage
    {
        public string Type { get; set; }
        public string Payload { get; set; }
        public DateTime OccurredOn { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // var domainEvent = new OrderCreatedEvent(1, "Nika", 99.99m); // ✅ სრული წვდომა ყველა ველზე

            // // ან ასე:
            // OrderCreatedEvent domainEvent = new OrderCreatedEvent(1, "Nika", 99.99m); // ✅

            IDomainEvent domainEvent = new OrderCreatedEvent(1, "Nika", 99.99m);

            var outbox = new OutboxMessage
            {
                Type = domainEvent.GetType().AssemblyQualifiedName!,
                Payload = JsonSerializer.Serialize((object)domainEvent), // ✅ cast to object
                OccurredOn = DateTime.UtcNow
            };


            Console.WriteLine($"[Outbox] Type: {outbox.Type}");
            Console.WriteLine($"[Outbox] Payload: {outbox.Payload}");

            // 3. Deserialize (simulate from DB)
            var eventType = Type.GetType(outbox.Type);
            if (eventType == null)
            {
                Console.WriteLine("[ERROR] Cannot resolve type.");
                return;
            }

            var deserialized = JsonSerializer.Deserialize(outbox.Payload, eventType);

            Console.WriteLine($"[Deserialized] Type: {deserialized?.GetType().Name}");
        }
    }
}
