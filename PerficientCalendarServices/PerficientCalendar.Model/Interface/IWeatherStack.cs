namespace PerficientCalendar.Model;
public interface IWeatherStack
{
    public Request Request { get; set; }
    public Location Location { get; set; }
    public Current Current { get; set; }
}
