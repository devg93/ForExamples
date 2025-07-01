
using Microsoft.EntityFrameworkCore;
using User.Domain;
using User.Infrastructure.Persistence;

namespace User.Infrastruqture.Persistence
{
    public class DataAcsess : DbContext
    {
        public DataAcsess(DbContextOptions<DataAcsess> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        // DbSet properties for your entities
        public DbSet<EUser> Users { get; set; }

    }
}
