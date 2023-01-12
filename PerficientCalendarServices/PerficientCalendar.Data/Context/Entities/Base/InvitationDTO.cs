namespace PerficientCalendar.Data.Entities;
public class InvitationDTO : IInvitationDTO
{
    public Guid IdInvitation { get; set; }

    public Guid IdMeeting { get; set; }

    public Guid IdDeveloper { get; set; }

    public string Status { get; set; } = null!;

    public double UtctimeZone { get; set; }

    public DateTime LocalStartTime { get; set; }

    public DateTime LocalEndTime { get; set; }

    public virtual DeveloperDTO Developer { get; set; } = null!;

    public virtual MeetingDTO Meeting { get; set; } = null!;
}
