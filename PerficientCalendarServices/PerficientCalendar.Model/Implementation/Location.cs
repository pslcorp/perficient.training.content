using System.Runtime.Serialization;

namespace PerficientCalendar.Model;

[DataContract]
public class Location : ILocation
{
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    [DataMember(Name = "country", EmitDefaultValue = false)]
    public string Country { get; set; }

    [DataMember(Name = "region", EmitDefaultValue = false)]
    public string Region { get; set; }

    [DataMember(Name = "lat", EmitDefaultValue = false)]
    public string Latitude { get; set; }

    [DataMember(Name = "lon", EmitDefaultValue = false)]
    public string Longitude { get; set; }

    [DataMember(Name = "timezone_id", EmitDefaultValue = false)]
    public string TimeZoneId { get; set; }

    [DataMember(Name = "localtime", EmitDefaultValue = false)]
    public string LocalTime { get; set; }

    [DataMember(Name = "localtime_epoch", EmitDefaultValue = false)]
    public int LocalTimeEpoch { get; set; }

    [DataMember(Name = "utc_offset", EmitDefaultValue = false)]
    public string UTCOffSet { get; set; }
}
