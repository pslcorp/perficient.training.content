using PerficientCalendar.Data.Entities;

namespace PerficientCalendar.Core.Repositories;

public interface ITypeEventRepository : IGenericRepository<TypeEventDTO>, IDisposable
{
    Task<TypeEventDTO> GetByName(string name);
    Task<TypeEventDTO> GetById(int id);
}