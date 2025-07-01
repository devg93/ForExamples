using Microsoft.EntityFrameworkCore;
using OrderService.domain;

namespace OrderService.Infrastruqture;

public class AppDbcontext : DbContext
{

    public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
    }

    public DbSet<OutboxMessage>  OutboxMessages { get; set; }

       public DbSet<Order> orders { get; set; }

    // public Task<int> SaveChangesAsync()
    // {
    //     return base.SaveChangesAsync();
    // }

    // public async Task<string> add(OutboxMessage outboxMessage)
    // {
    //     await OutboxMessages.AddAsync(outboxMessage);
    //     await SaveChangesAsync();
    //     return await Task.FromResult("OutboxMessage added");
    // }

  
}
