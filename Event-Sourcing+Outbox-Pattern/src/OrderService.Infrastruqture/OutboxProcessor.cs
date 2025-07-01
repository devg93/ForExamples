
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrderService.domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace OrderService.Infrastruqture
{
   public class OutboxProcessor : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public OutboxProcessor(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbcontext>();

            var messages = await db.OutboxMessages
                .Where(m => m.ProcessedOn == null)
                .ToListAsync(stoppingToken);

            foreach (var msg in messages)
            {
                try
                {
                    Console.WriteLine($"[Publish] {msg.Type}: {msg.Payload}");

                    // Publishing logic here...

                    msg.ProcessedOn = DateTime.UtcNow;
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // Log
                }
            }

            await Task.Delay(3000, stoppingToken);
        }
    }
}

}