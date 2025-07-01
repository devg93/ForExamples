using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrderService.domain.Abstractions;

namespace OrderService.domain
{
    public class OrderCreatedEvent : IDomainEvent, INotification
    {
        public int Id { get; }
        public string CustomerName { get; }
        public decimal Amount { get; }

        public OrderCreatedEvent(int id, string customerName, decimal amount)
        {
            Id = id;
            CustomerName = customerName;
            Amount = amount;
        }

        public void OrderCreated(int id, string customerName, decimal amount)
        {
            throw new NotImplementedException();
        }
    }

}