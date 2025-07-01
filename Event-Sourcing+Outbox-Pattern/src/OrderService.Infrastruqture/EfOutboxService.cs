using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using OrderService.domain;
using OrderService.domain.Abstractions;

namespace OrderService.Infrastruqture
{
    public class EfOutboxService : IOutboxService
    {
        private readonly IRepository _db;

        public EfOutboxService(IRepository db) => _db = db;

        public async Task SaveEventAsync(IDomainEvent domainEvent)
        {
            var outbox = new OutboxMessage
            {
                Type = domainEvent.GetType().AssemblyQualifiedName ?? string.Empty,
                Payload = JsonSerializer.Serialize((object)domainEvent),
                OccurredOn = DateTime.UtcNow
            };


            await _db.AddOutboxMessage(outbox);
        }
    }



    public interface IOutboxService
    {
        Task SaveEventAsync(IDomainEvent domainEvent);
    }
}