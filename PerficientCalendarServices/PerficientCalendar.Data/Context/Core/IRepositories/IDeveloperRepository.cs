using PerficientCalendar.Data.Entities;

namespace PerficientCalendar.Core.Repositories;

public interface IDeveloperRepository : IGenericRepository<DeveloperDTO>, IDisposable
{
    Task<DeveloperDTO> GetByName(string name);
    Task<IEnumerable<DeveloperDTO>> GetByIdentifier(string identifier);
}