using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerficientCalendar.Data.Entities;

namespace PerficientCalendar.Data.EntityConfigurations;

public class MeetingConfiguration : IEntityTypeConfiguration<MeetingDTO>
{
    public void Configure(EntityTypeBuilder<MeetingDTO> builder)
    {
        builder.HasKey(e => e.IdMeeting).HasName("PK_Meeting_IdMeeting");

        builder.ToTable("Meeting");

        builder.Property(e => e.IdMeeting).HasDefaultValueSql("(newid())");
        builder.Property(e => e.Description)
                 .HasMaxLength(255)
                 .IsUnicode(false);
        builder.Property(e => e.EndHour).HasColumnType("datetime");
        builder.Property(e => e.EventName)
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.StartHour).HasColumnType("datetime");

        builder.HasOne(d => d.Office).WithMany(p => p.Meetings)
            .HasForeignKey(d => d.IdOffice)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Meeting_IdOffice");

        builder.HasOne(d => d.TypeEvent).WithMany(p => p.Meetings)
            .HasForeignKey(d => d.IdTypeEvent)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Meeting_IdTypeEvent");
    }
}