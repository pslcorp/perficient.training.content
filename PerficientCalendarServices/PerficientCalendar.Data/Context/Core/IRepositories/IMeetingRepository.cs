using PerficientCalendar.Data.Entities;

namespace PerficientCalendar.Core.Repositories;

public interface IMeetingRepository : IGenericRepository<MeetingDTO>, IDisposable
{
    Task<MeetingDTO> GetByName(string eventName);
}