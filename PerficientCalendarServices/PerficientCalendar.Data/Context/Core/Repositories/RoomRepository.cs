using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;
using PerficientCalendar.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace PerficientCalendar.Core.Repositories;

public class RoomRepository : GenericRepository<RoomDTO>, IRoomRepository
{
    private readonly AplicationDBContext Context;
    public RoomRepository(AplicationDBContext context) : base(context)
    {
        Context = context;
    }

    public override async Task<bool> Add(RoomDTO entity)
    {
        await Dbset.AddAsync(entity);
        await Context.SaveChangesAsync();
        return true;
    }
    public override async Task<bool> Delete(RoomDTO entity)
    {
        Dbset.Remove(entity);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<RoomDTO> GetByName(string name)
    {
        return await Dbset.Where(o => o.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
    }

    public override async Task<IEnumerable<RoomDTO>> All()
    {
        return await Dbset.ToListAsync();
    }

    public override async Task<RoomDTO> Upsert(RoomDTO entity)
    {
        var result = await Dbset.Where(o => o.IdRoom == entity.IdRoom).FirstOrDefaultAsync();

        if (result == null)
        {
            entity.IdOffice = new Guid();
            await Add(entity);
            return entity;
        }

        result.Name = entity.Name;
        result.Capacity = entity.Capacity;
        result.IdOffice = entity.IdOffice;

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
