using System.Runtime.Serialization;

namespace PerficientCalendar.Model;

[DataContract]
public class Current : ICurrent
{
    [DataMember(Name = "observation_time", EmitDefaultValue = false)]
    public string ObservationTime { get; set; }

    [DataMember(Name = "temperature", EmitDefaultValue = false)]
    public double Temperature { get; set; }

    [DataMember(Name = "weather_code", EmitDefaultValue = false)]
    public double WeatherCode { get; set; }

    [DataMember(Name = "weather_icons", EmitDefaultValue = false)]
    public List<string> WeatherIcons { get; set; }

    [DataMember(Name = "weather_descriptions", EmitDefaultValue = false)]
    public List<string> WeatherDescriptions { get; set; }

    [DataMember(Name = "wind_speed", EmitDefaultValue = false)]
    public double WindSpeed { get; set; }

    [DataMember(Name = "wind_degree", EmitDefaultValue = false)]
    public double WindDegree { get; set; }

    [DataMember(Name = "wind_dir", EmitDefaultValue = false)]
    public string WinDirection { get; set; }

    [DataMember(Name = "pressure", EmitDefaultValue = false)]
    public double Pressure { get; set; }

    [DataMember(Name = "precip", EmitDefaultValue = false)]
    public double Precipitation { get; set; }

    [DataMember(Name = "humidity", EmitDefaultValue = false)]
    public double Humidity { get; set; }

    [DataMember(Name = "cloudcover", EmitDefaultValue = false)]
    public double CloudCover { get; set; }

    [DataMember(Name = "feelslike", EmitDefaultValue = false)]
    public double FeelsLike { get; set; }

    [DataMember(Name = "uv_index", EmitDefaultValue = false)]
    public double UVIndex { get; set; }

    [DataMember(Name = "visibility", EmitDefaultValue = false)]
    public double Visibility { get; set; }
}
