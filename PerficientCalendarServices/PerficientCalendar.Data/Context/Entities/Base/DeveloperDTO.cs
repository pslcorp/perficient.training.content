using System.ComponentModel.DataAnnotations.Schema;
namespace PerficientCalendar.Data.Entities;

public class DeveloperDTO : IDeveloperDTO
{
    public Guid IdDeveloper { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string CurrentLocation { get; set; } = null!;
    public Guid IdOffice { get; set; }
    public string? Mobile { get; set; }
    public virtual OfficeDTO Office { get; set; } = null!;
    public virtual ICollection<InvitationDTO> Invitations { get; } = new List<InvitationDTO>();
}