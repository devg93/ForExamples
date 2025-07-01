
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain;


namespace User.Infrastructure.Persistence
{
    public class UserConfiguration : IEntityTypeConfiguration<EUser>
    {
        public void Configure(EntityTypeBuilder<EUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Users");
            builder.OwnsOne(u => u.Name, nameBuilder =>
            {
                nameBuilder.Property(p => p.FirstName).
                HasColumnName("FirstName").
                IsRequired(true).
                HasMaxLength(50);


            });
        }
    }
}