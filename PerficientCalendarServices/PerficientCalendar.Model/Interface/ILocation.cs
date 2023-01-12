namespace PerficientCalendar.Model;
public interface ILocation
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string TimeZoneId { get; set; }
    public string LocalTime { get; set; }
    public int LocalTimeEpoch { get; set; }
    public string UTCOffSet { get; set; }
}
