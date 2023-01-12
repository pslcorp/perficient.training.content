namespace PerficientCalendar.Model;

public class Developer : IDeveloper
{
    public Guid IdDeveloper { get; set; }

    public string Name { get; set; } = null!;
    public string CurrentLocation { get; set; } = null!;
    public string Email { get; set; } = null!;

    public Guid IdOffice { get; set; }

    public string? Mobile { get; set; }
}
