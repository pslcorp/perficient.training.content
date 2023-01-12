namespace PerficientCalendar.Data.Entities;

public class RoomDTO : IRoomDTO
{
    public Guid IdRoom { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public Guid IdOffice { get; set; }

    public virtual OfficeDTO Office { get; set; } = null!;
}
