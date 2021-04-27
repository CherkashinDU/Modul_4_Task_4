using EFCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCodeFirst.EntityConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("ClientId");
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasMaxLength(100);
            builder.Property(c => c.Location).IsRequired().HasColumnName("Location").HasMaxLength(100);
            builder.Property(c => c.StartDate).IsRequired().HasColumnName("StartedDate").HasColumnType("date");
            builder.Property(c => c.EndDate).HasColumnName("EndedDate").HasColumnType("date");
        }
    }
}