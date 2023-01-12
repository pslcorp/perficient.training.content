namespace PerficientCalendar.Model;

public class Office : IOffice
{
    public Guid IdOffice { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? Phone { get; set; }

    public string Latitude { get; set; }

    public string Longitude { get; set; }
}
