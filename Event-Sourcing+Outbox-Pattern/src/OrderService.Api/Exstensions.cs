using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Event;
using OrderService.domain.Abstractions;
using System.Reflection;

namespace OrderService.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddOrderApiServices(this IServiceCollection services)
        {
            // თუ შენი Handler-ები სხვა პროექტშია:
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(Application.CreateOrderHandler).Assembly); });
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            // ან თუ ესაა ერთპროექტიანი აპი:
            // services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
