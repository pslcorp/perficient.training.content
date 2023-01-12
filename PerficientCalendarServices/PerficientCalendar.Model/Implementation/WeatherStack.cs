using System.Runtime.Serialization;

namespace PerficientCalendar.Model;

[DataContract]
public class WeatherStack : IWeatherStack
{
    [DataMember(Name = "request", EmitDefaultValue = false)]
    public Request Request { get; set; }

    [DataMember(Name = "location", EmitDefaultValue = false)]
    public Location Location { get; set; }

    [DataMember(Name = "current", EmitDefaultValue = false)]
    public Current Current { get; set; }
}
