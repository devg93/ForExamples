using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.domain;
using OrderService.domain.Abstractions;
using OrderService.Infrastruqture;

namespace OrderService.Application
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, string>
    {

        private readonly IOutboxService _outboxService;

        private readonly IRepository _repository;
        private readonly IDomainEventDispatcher _dispatcher;
        public CreateOrderHandler(IOutboxService outboxService, IRepository repository, IDomainEventDispatcher dispatcher)
        {
            _dispatcher = dispatcher;

            _outboxService = outboxService;
            _repository = repository;
        }

        public async Task<string> Handle(CreateOrderCommand cmd, CancellationToken cancellationToken)
        {


            var order = new Order(cmd.CustomerName, cmd.Amount);

            await _repository.AddOrder(order);



            foreach (var @event in order.Events)
                await _outboxService.SaveEventAsync(@event);



            await _dispatcher.DispatchAsync(order.Events);

            order.ClearEvents();

            return "";
        }
    }
}