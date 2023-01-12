using Microsoft.EntityFrameworkCore;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Data.EntityConfigurations;

namespace PerficientCalendar.Data.Contexts;

public class AplicationDBContext : DbContext
{
    public AplicationDBContext(DbContextOptions<AplicationDBContext> options)
    : base(options)
    {
    }
    public virtual DbSet<DeveloperDTO> Developers { get; set; }
    public virtual DbSet<TypeEventDTO> TypeEvents { get; set; }
    public virtual DbSet<OfficeDTO> Offices { get; set; }
    public virtual DbSet<RoomDTO> Rooms { get; set; }
    public virtual DbSet<MeetingDTO> Meetings { get; set; }
    public virtual DbSet<InvitationDTO> Invitations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new OfficeConfiguration().Configure(modelBuilder.Entity<OfficeDTO>());
        new DeveloperConfiguration().Configure(modelBuilder.Entity<DeveloperDTO>());
        new RoomConfiguration().Configure(modelBuilder.Entity<RoomDTO>());
        new TypeEventConfiguration().Configure(modelBuilder.Entity<TypeEventDTO>());
        new MeetingConfiguration().Configure(modelBuilder.Entity<MeetingDTO>());
        new InvitationConfiguration().Configure(modelBuilder.Entity<InvitationDTO>());
    }
}
