namespace PerficientCalendar.Model;
public interface IInvitation
{
    public Guid IdInvitation { get; set; }

    public Guid IdMeeting { get; set; }

    public Guid IdDeveloper { get; set; }

    public string Status { get; set; }

    public double UtctimeZone { get; set; }

    public DateTime LocalStartTime { get; set; }

    public DateTime LocalEndTime { get; set; }
}
