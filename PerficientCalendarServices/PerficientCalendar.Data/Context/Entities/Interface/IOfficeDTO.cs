namespace PerficientCalendar.Data.Entities;
public interface IOfficeDTO
{
    public Guid IdOffice { get; set; }

    public string Name { get; set; }

    public string City { get; set; }

    public string Address { get; set; }

    public string Country { get; set; }

    public string? Phone { get; set; }

    public string Latitude { get; set; }

    public string Longitude { get; set; }
}
