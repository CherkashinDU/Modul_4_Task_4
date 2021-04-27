using EFCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCodeFirst.EntityConfigurations
{
   public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProject").HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("EmployeeProjectId");
            builder.Property(e => e.Rate).IsRequired().HasColumnName("Rate").HasColumnType("money");
            builder.Property(e => e.StartedDate).IsRequired().HasColumnName("StartedDate").HasColumnType("datetime2(7)");

            builder.HasOne(e => e.Employee)
                .WithMany(ep => ep.EmployeeProjects)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Project)
                .WithMany(ep => ep.EmployeeProjects)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
