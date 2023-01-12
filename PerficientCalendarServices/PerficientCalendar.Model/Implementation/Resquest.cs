using System.Runtime.Serialization;

namespace PerficientCalendar.Model;

[DataContract]
public class Request : IResquet
{
    [DataMember(Name = "type", EmitDefaultValue = false)]
    public string Type { get; set; }

    [DataMember(Name = "query", EmitDefaultValue = false)]
    public string Query { get; set; }

    [DataMember(Name = "language", EmitDefaultValue = false)]
    public string Language { get; set; }

    [DataMember(Name = "unit", EmitDefaultValue = false)]
    public string Unit { get; set; }
}
