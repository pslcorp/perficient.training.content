using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PerficientCalendar.Data.Contexts;
using PerficientCalendar.Core.Repositories;

namespace PerficientCalendar.Core.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected AplicationDBContext Context;
    internal DbSet<T> Dbset;
    public GenericRepository(AplicationDBContext context)
    {
        Context = context;
        Dbset = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> GetById(Guid id)
    {
        return await Dbset.FindAsync(id);
    }

    public virtual async Task<bool> Add(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<bool> Delete(T Entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> Upsert(T Entity)
    {
        throw new NotImplementedException();
    }

}