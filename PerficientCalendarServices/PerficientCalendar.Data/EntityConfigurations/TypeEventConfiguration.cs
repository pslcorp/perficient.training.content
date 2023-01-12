using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerficientCalendar.Data.Entities;

namespace PerficientCalendar.Data.EntityConfigurations;

public class TypeEventConfiguration : IEntityTypeConfiguration<TypeEventDTO>
{
    public void Configure(EntityTypeBuilder<TypeEventDTO> builder)
    {
        builder.HasKey(e => e.IdTypeEvent).HasName("PK_TypeEvent_IdTypeEvent");

        builder.ToTable("TypeEvent");

        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);
    }
}