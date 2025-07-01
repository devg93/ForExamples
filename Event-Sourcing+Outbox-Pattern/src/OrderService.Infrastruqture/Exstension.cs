using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderService.domain.Abstractions;

namespace OrderService.Infrastruqture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<OutboxProcessor>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IOutboxService, EfOutboxService>();
            services.AddHostedService<OutboxProcessor>();

            services.AddDbContext<AppDbcontext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
