using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerficientCalendar.Data.Entities;

namespace PerficientCalendar.Data.EntityConfigurations;

public class InvitationConfiguration : IEntityTypeConfiguration<InvitationDTO>
{
    public void Configure(EntityTypeBuilder<InvitationDTO> builder)
    {
        builder.HasKey(e => e.IdInvitation).HasName("PK_Invitation_IdInvitation");

        builder.ToTable("Invitation");

        builder.HasKey(e => e.IdInvitation).HasName("PK_Invitation_IdInvitation");

        builder.ToTable("Invitation");

        builder.Property(e => e.IdInvitation).HasDefaultValueSql("(newid())");
        builder.Property(e => e.IdDeveloper).HasDefaultValueSql("(newid())");
        builder.Property(e => e.IdMeeting).HasDefaultValueSql("(newid())");
        builder.Property(e => e.LocalEndTime).HasColumnType("datetime");
        builder.Property(e => e.LocalStartTime).HasColumnType("datetime");
        builder.Property(e => e.Status)
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.UtctimeZone).HasColumnName("UTCTimeZone");

        builder.HasOne(d => d.Developer).WithMany(p => p.Invitations)
            .HasForeignKey(d => d.IdDeveloper)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Invitation_IdDeveloper");

        builder.HasOne(d => d.Meeting).WithMany(p => p.Invitations)
            .HasForeignKey(d => d.IdMeeting)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Invitation_IdMeeting");
    }
}