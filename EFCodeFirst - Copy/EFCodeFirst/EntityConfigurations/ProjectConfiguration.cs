using System;
using System.Collections.Generic;
using EFCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCodeFirst.EntityConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ProjectId");
            builder.Property(e => e.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            builder.Property(e => e.Budget).IsRequired().HasColumnName("Budget").HasColumnType("money");
            builder.Property(e => e.StartedDate).IsRequired().HasColumnName("StartedDate").HasColumnType("datetime2(7)");

            builder.HasOne(c => c.Client)
                .WithMany(p => p.Projects)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}