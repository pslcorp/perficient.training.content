namespace PerficientCalendar.Model;

public interface IDeveloper
{
    public Guid IdDeveloper { get; set; }

    public string Name { get; set; }

    public string CurrentLocation { get; set; }

    public string Email { get; set; }

    public Guid IdOffice { get; set; }

    public string? Mobile { get; set; }
}
