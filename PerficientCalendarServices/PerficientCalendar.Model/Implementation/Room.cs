namespace PerficientCalendar.Model;

public class Room : IRoom
{
    public Guid IdRoom { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public Guid IdOffice { get; set; }
}
