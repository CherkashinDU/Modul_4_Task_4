using EFCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCodeFirst.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("EmployeeId");
            builder.Property(e => e.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(50);
            builder.Property(e => e.HiredDate).IsRequired().HasColumnName("HiredDate").HasColumnType("datetime2(7)");
            builder.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth").HasColumnType("date");

            builder.HasOne(e => e.Office)
                .WithMany(ep => ep.Employees)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Title)
                .WithMany(ep => ep.Employees)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
