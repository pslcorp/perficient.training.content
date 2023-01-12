using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerficientCalendar.Data.Entities;

namespace PerficientCalendar.Data.EntityConfigurations;

public class OfficeConfiguration : IEntityTypeConfiguration<OfficeDTO>
{
    public void Configure(EntityTypeBuilder<OfficeDTO> builder)
    {
        builder.HasKey(e => e.IdOffice).HasName("PK_Office_IdOffice");

        builder.ToTable("Office");

        builder.Property(e => e.IdOffice).HasDefaultValueSql("(newid())");
        builder.Property(e => e.Address)
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.City)
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.Country)
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.Latitude)
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.Longitude)
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.Phone)
            .HasMaxLength(255)
            .IsUnicode(false);
    }
}