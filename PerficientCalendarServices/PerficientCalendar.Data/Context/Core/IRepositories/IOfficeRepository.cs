using PerficientCalendar.Data.Entities;

namespace PerficientCalendar.Core.Repositories;

public interface IOfficeRepository : IGenericRepository<OfficeDTO>, IDisposable
{
    Task<OfficeDTO> GetByName(string name);
}