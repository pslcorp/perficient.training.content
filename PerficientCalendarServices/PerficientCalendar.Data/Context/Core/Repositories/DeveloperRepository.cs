using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;
using PerficientCalendar.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace PerficientCalendar.Core.Repositories;

public class DeveloperRepository : GenericRepository<DeveloperDTO>, IDeveloperRepository
{
    private readonly AplicationDBContext Context;
    public DeveloperRepository(AplicationDBContext context) : base(context)
    {
        Context = context;
    }

    public override async Task<bool> Add(DeveloperDTO entity)
    {
        await Dbset.AddAsync(entity);
        await Context.SaveChangesAsync();
        return true;
    }
    public override async Task<bool> Delete(DeveloperDTO entity)
    {
        Dbset.Remove(entity);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<DeveloperDTO> GetByName(string name)
    {
        return await Dbset.Where(o => o.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<DeveloperDTO>> GetByIdentifier(string identifier)
    {
        return await Dbset.Where(o => o.Email.ToLower().Contains(identifier.ToLower())).ToListAsync();
    }

    public override async Task<IEnumerable<DeveloperDTO>> All()
    {
        return await Dbset.ToListAsync();
    }

    public override async Task<DeveloperDTO> Upsert(DeveloperDTO entity)
    {
        var result = await Dbset.Where(o => o.IdDeveloper == entity.IdDeveloper).FirstOrDefaultAsync();

        if (result == null)
        {
            entity.IdOffice = new Guid();
            await Add(entity);
            return entity;
        }

        result.Name = entity.Name;
        result.CurrentLocation = entity.CurrentLocation;
        result.Email = entity.Email;
        result.IdOffice = entity.IdOffice;
        result.Mobile = entity.Mobile;

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
