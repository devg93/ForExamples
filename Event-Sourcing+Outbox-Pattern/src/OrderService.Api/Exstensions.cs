using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OrderService.Api
{
    public static class Exstensions
    {
        public static IServiceCollection AddOrdeApirService(this IServiceCollection services)
        {
            // Register your services here
            // Example: services.AddScoped<IOrderService, OrderService>();

            // Register the DbContext
            // Example: services.AddDbContext<AppDbcontext>(options => options.UseSqlServer("YourConnectionString"));

            // Register the OutboxProcessor
            // Example: services.AddHostedService<OutboxProcessor>();

            return services;
        }
    }
}