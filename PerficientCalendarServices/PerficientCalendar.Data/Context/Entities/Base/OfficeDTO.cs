
namespace PerficientCalendar.Data.Entities;

public class OfficeDTO : IOfficeDTO
{
    public Guid IdOffice { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? Phone { get; set; }

    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public virtual ICollection<DeveloperDTO> Developers { get; } = new List<DeveloperDTO>();
    public virtual ICollection<MeetingDTO> Meetings { get; } = new List<MeetingDTO>();
    public virtual ICollection<RoomDTO> Rooms { get; } = new List<RoomDTO>();
}
