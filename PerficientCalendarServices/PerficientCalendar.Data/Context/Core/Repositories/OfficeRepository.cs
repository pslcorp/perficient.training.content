using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;
using PerficientCalendar.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace PerficientCalendar.Core.Repositories;

public class OfficeRepository : GenericRepository<OfficeDTO>, IOfficeRepository
{

    private readonly AplicationDBContext Context;
    public OfficeRepository(AplicationDBContext context) : base(context)
    {
        Context = context;
    }

    public override async Task<bool> Add(OfficeDTO entity)
    {
        await Dbset.AddAsync(entity);
        await Context.SaveChangesAsync();
        return true;
    }
    public override async Task<bool> Delete(OfficeDTO entity)
    {
        Dbset.Remove(entity);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<OfficeDTO> GetByName(string name)
    {
        return await Dbset.Where(o => o.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
    }

    public override async Task<IEnumerable<OfficeDTO>> All()
    {
        return await Dbset.ToListAsync();
    }

    public override async Task<OfficeDTO> Upsert(OfficeDTO entity)
    {
        var result = await Dbset.Where(o => o.IdOffice == entity.IdOffice).FirstOrDefaultAsync();

        if (result == null)
        {
            entity.IdOffice = new Guid();
            await Add(entity);
            return entity;
        }

        result.Name = entity.Name;
        result.City = entity.City;
        result.Address = entity.Address;
        result.Phone = entity.Phone;
        result.Latitude = entity.Latitude;
        result.Longitude = entity.Longitude;
        result.Country = entity.Country;

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
