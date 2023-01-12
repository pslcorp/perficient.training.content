namespace PerficientCalendar.Core.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> All();
    Task<T> GetById(Guid id);
    Task<bool> Add(T entity);
    Task<bool> Delete(T Entity);
    Task<T> Upsert(T Entity);
}