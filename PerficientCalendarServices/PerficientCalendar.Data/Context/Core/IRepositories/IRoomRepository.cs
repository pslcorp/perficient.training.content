using PerficientCalendar.Data.Entities;

namespace PerficientCalendar.Core.Repositories;

public interface IRoomRepository : IGenericRepository<RoomDTO>, IDisposable
{
    Task<RoomDTO> GetByName(string name);
}