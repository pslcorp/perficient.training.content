namespace PerficientCalendar.Data.Entities;

public class MeetingDTO : IMeetingDTO
{
    public Guid IdMeeting { get; set; }

    public string EventName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartHour { get; set; }

    public DateTime EndHour { get; set; }

    public int IdTypeEvent { get; set; }

    public Guid IdOffice { get; set; }

    public virtual OfficeDTO Office { get; set; } = null!;
    public virtual TypeEventDTO TypeEvent { get; set; } = null!;
    public virtual ICollection<InvitationDTO> Invitations { get; } = new List<InvitationDTO>();
}
