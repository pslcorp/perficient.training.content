using PerficientCalendar.Data.Entities;
using PerficientCalendar.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace PerficientCalendar.Core.Repositories;

public class InvitationRepository : GenericRepository<InvitationDTO>, IInvitationRepository
{

    private readonly AplicationDBContext Context;
    public InvitationRepository(AplicationDBContext context) : base(context)
    {
        Context = context;
    }

    public override async Task<bool> Add(InvitationDTO entity)
    {
        await Dbset.AddAsync(entity);
        await Context.SaveChangesAsync();
        return true;
    }
    public override async Task<bool> Delete(InvitationDTO entity)
    {
        Dbset.Remove(entity);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<InvitationDTO> GetByIDDeveloper(Guid idDeveloper)
    {
        return await Dbset.Where(o => o.IdDeveloper == idDeveloper).FirstOrDefaultAsync();
    }

    public async Task<InvitationDTO> GetByIDMeeting(Guid idMeeting)
    {
        return await Dbset.Where(o => o.IdMeeting == idMeeting).FirstOrDefaultAsync();
    }

    public async Task<DeveloperDTO> GetDeveloperDetails(Guid idDeveloper)
    {
        var result = await Context.Developers.Join(Context.Offices,
        a => a.IdOffice,
        b => b.IdOffice,
        (a, b) => new
        {
            a.IdDeveloper,
            a.Name,
            a.CurrentLocation,
            a.Email,
            b.City,
        }).Where(o => o.IdDeveloper == idDeveloper).FirstOrDefaultAsync();

        var developer = new DeveloperDTO()
        {
            IdDeveloper = result.IdDeveloper,
            Name = result.Name,
            CurrentLocation = result.CurrentLocation,
            Email = result.Email,
            Office = new OfficeDTO()
            {
                City = result.City
            }
        };
        return developer;
    }

    public override async Task<IEnumerable<InvitationDTO>> All()
    {
        return await Dbset.ToListAsync();
    }

    public override async Task<InvitationDTO> Upsert(InvitationDTO entity)
    {
        var result = await Dbset.Where(o => o.IdInvitation == entity.IdInvitation).FirstOrDefaultAsync();

        if (result == null)
        {
            entity.IdInvitation = new Guid();
            await Add(entity);
            return entity;
        }
        result.LocalStartTime = entity.LocalStartTime;
        result.LocalEndTime = entity.LocalEndTime;

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
