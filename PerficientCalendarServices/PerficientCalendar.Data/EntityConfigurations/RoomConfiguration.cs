using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerficientCalendar.Data.Entities;

namespace PerficientCalendar.Data.EntityConfigurations;

public class RoomConfiguration : IEntityTypeConfiguration<RoomDTO>
{
    public void Configure(EntityTypeBuilder<RoomDTO> builder)
    {
        builder.HasKey(e => e.IdRoom).HasName("PK_Room_IdRoom");

        builder.ToTable("Room");

        builder.Property(e => e.IdRoom).HasDefaultValueSql("(newid())");
        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.HasOne(d => d.Office).WithMany(p => p.Rooms)
            .HasForeignKey(d => d.IdOffice)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Room_IdOffice");
    }
}