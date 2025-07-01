using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.domain;
using OrderService.domain.Abstractions;

namespace OrderService.Infrastruqture
{
    public class Repository : IRepository
    {
        private readonly AppDbcontext dbcontext;

        public Repository(AppDbcontext appDbcontext)
        => dbcontext = appDbcontext;
        

        public async Task<string> AddOrder(Order order)
        {
            await dbcontext.orders.AddAsync(order);
            return "Order added successfully";
        }


        public async Task<string> AddOutboxMessage(OutboxMessage outboxMessage)
        {
            await dbcontext.OutboxMessages.AddAsync(outboxMessage);
            return "Outbox message added successfully";
        }


        public async Task<IEnumerable<Order>> GetallOrders()
        {
          return await dbcontext.orders.ToListAsync();
        }

        public async Task<IEnumerable<OutboxMessage>> GetallOutBox()
        {
          return await dbcontext.OutboxMessages.ToListAsync();
        }

        public async Task<Order> GetByOrderById(int id)
        {
            if (dbcontext.orders is not null)
            {
                var order = await dbcontext.orders.FirstOrDefaultAsync(o => o.Id == id);
                if (order is null)
                {
                    throw new InvalidOperationException($"Order with Id {id} not found.");
                }
                return order;
            }
            else
            {
                throw new NullReferenceException("Orders DbSet is null");
            }
        }
          

        public async Task<OutboxMessage> GetOutboxById(int id)
        {
            if (dbcontext.OutboxMessages is not null)
            {
                var outbox = await dbcontext.OutboxMessages.FirstOrDefaultAsync(o => o.Id == id);
                if (outbox is null)
                {
                    throw new InvalidOperationException($"Outbox message with Id {id} not found.");
                }
                return outbox;
            }
            else
            {
                throw new NullReferenceException("OutboxMessages DbSet is null");
            }
        }

        public async Task<int> SaveChanges()
        {
           
            return  await dbcontext.SaveChangesAsync(); 
        }
    }
}