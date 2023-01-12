namespace PerficientCalendar.Model;
public interface ICurrent
{
    public string ObservationTime { get; set; }
    public double Temperature { get; set; }
    public double WeatherCode { get; set; }
    public List<string> WeatherIcons { get; set; }
    public List<string> WeatherDescriptions { get; set; }
    public double WindSpeed { get; set; }
    public double WindDegree { get; set; }
    public string WinDirection { get; set; }
    public double Pressure { get; set; }
    public double Precipitation { get; set; }
    public double Humidity { get; set; }
    public double CloudCover { get; set; }
    public double FeelsLike { get; set; }
    public double UVIndex { get; set; }
    public double Visibility { get; set; }
}
