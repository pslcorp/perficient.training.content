using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;
using PerficientCalendar.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace PerficientCalendar.Core.Repositories;

public class MeetingRepository : GenericRepository<MeetingDTO>, IMeetingRepository
{

    private readonly AplicationDBContext Context;
    public MeetingRepository(AplicationDBContext context) : base(context)
    {
        Context = context;
    }

    public override async Task<bool> Add(MeetingDTO entity)
    {
        await Dbset.AddAsync(entity);
        await Context.SaveChangesAsync();
        return true;
    }
    public override async Task<bool> Delete(MeetingDTO entity)
    {
        Dbset.Remove(entity);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<MeetingDTO> GetByName(string eventName)
    {
        return await Dbset.Where(o => o.EventName.ToLower() == eventName.ToLower()).FirstOrDefaultAsync();
    }

    public override async Task<IEnumerable<MeetingDTO>> All()
    {
        return await Dbset.ToListAsync();
    }

    public override async Task<MeetingDTO> Upsert(MeetingDTO entity)
    {
        var result = await Dbset.Where(o => o.IdMeeting == entity.IdMeeting).FirstOrDefaultAsync();

        if (result == null)
        {
            entity.IdOffice = new Guid();
            await Add(entity);
            return entity;
        }

        result.EventName = entity.EventName;
        result.Description = entity.Description;
        result.StartHour = entity.StartHour;
        result.EndHour = entity.EndHour;
        result.IdTypeEvent = entity.IdTypeEvent;
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
