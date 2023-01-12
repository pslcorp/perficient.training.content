namespace PerficientCalendar.Model;
public interface IRoom
{
    public Guid IdRoom { get; set; }

    public string Name { get; set; }

    public int Capacity { get; set; }

    public Guid IdOffice { get; set; }
}
