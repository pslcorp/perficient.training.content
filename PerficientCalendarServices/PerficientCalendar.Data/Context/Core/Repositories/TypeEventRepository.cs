using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;
using PerficientCalendar.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace PerficientCalendar.Core.Repositories;

public class TypeEventRepository : GenericRepository<TypeEventDTO>, ITypeEventRepository
{
    private readonly AplicationDBContext Context;
    public TypeEventRepository(AplicationDBContext context) : base(context)
    {
        Context = context;
    }

    public override async Task<bool> Add(TypeEventDTO entity)
    {
        await Dbset.AddAsync(entity);
        await Context.SaveChangesAsync();
        return true;
    }
    public override async Task<bool> Delete(TypeEventDTO entity)
    {
        Dbset.Remove(entity);
        await Context.SaveChangesAsync();
        return true;
    }


    public async Task<TypeEventDTO> GetByName(string name)
    {
        return await Dbset.Where(o => o.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
    }

    public override async Task<IEnumerable<TypeEventDTO>> All()
    {
        return await Dbset.ToListAsync();
    }
    public async Task<TypeEventDTO> GetById(int id)
    {
        return await Dbset.FindAsync(id);
    }
    public override async Task<TypeEventDTO> Upsert(TypeEventDTO entity)
    {
        var result = await Dbset.Where(o => o.IdTypeEvent == entity.IdTypeEvent).FirstOrDefaultAsync();

        if (result == null)
        {
            await Add(entity);
            return entity;
        }

        result.Name = entity.Name;

        await Context.SaveChangesAsync();
        return result;
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }
}
