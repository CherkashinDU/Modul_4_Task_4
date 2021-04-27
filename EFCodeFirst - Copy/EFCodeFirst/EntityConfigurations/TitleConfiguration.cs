using System.Collections.Generic;
using EFCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCodeFirst.EntityConfigurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title").HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("TitleId");
            builder.Property(e => e.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
        }
    }
}
