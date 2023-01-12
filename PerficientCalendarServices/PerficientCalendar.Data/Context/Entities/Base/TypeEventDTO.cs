namespace PerficientCalendar.Data.Entities;

public class TypeEventDTO : ITypeEventDTO
{
    public int IdTypeEvent { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<MeetingDTO> Meetings { get; } = new List<MeetingDTO>();
}
