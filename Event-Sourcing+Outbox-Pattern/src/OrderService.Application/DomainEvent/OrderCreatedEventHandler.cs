using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrderService.domain;

namespace OrderService.Application.DomainEvent
{
    public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Order created for {notification.CustomerName}");
        return Task.CompletedTask;
    }
}

}