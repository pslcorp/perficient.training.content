using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerficientCalendar.Data.Entities;

namespace PerficientCalendar.Data.EntityConfigurations;

public class DeveloperConfiguration : IEntityTypeConfiguration<DeveloperDTO>
{
    public void Configure(EntityTypeBuilder<DeveloperDTO> builder)
    {
        builder.HasKey(e => e.IdDeveloper).HasName("PK_Developer_IdDeveloper");

        builder.ToTable("Developer");

        builder.Property(e => e.IdDeveloper).HasDefaultValueSql("(newid())");
        builder.Property(e => e.CurrentLocation)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.Email)
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.Mobile)
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.HasOne(d => d.Office).WithMany(p => p.Developers)
            .HasForeignKey(d => d.IdOffice)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Developer_IdOffice");
    }
}