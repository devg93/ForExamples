
using Microsoft.Extensions.DependencyInjection;
using OrderService.domain.Abstractions;

namespace OrderService.Infrastruqture
{
    public static class Exstension
    {
        public static IServiceCollection AddInfrastruqtureServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<OutboxProcessor>();
            serviceDescriptors.AddScoped<IRepository, Repository>();
            serviceDescriptors.AddScoped<IOutboxService, EfOutboxService>();
            // serviceDescriptors.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            return serviceDescriptors;

        }
        
    }
}