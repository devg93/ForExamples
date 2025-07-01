using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.domain.Abstractions
{
    public interface IRepository
    {
        Task<string> AddOutboxMessage(OutboxMessage outboxMessage);
        Task<string> AddOrder(Order order);

        Task<OutboxMessage> GetOutboxById(int id);
        Task<Order> GetByOrderById(int id );
        Task<IEnumerable<OutboxMessage>> GetallOutBox();
        Task<IEnumerable<Order>> GetallOrders();
        public Task<int> SaveChanges();
    }
}