namespace PerficientCalendar.Data.Entities;
public interface IMeeting
{
    public Guid IdMeeting { get; set; }

    public string EventName { get; set; }

    public string? Description { get; set; }
    public DateTime StartHour { get; set; }

    public DateTime EndHour { get; set; }

    public int IdTypeEvent { get; set; }

    public Guid IdOffice { get; set; }

}
