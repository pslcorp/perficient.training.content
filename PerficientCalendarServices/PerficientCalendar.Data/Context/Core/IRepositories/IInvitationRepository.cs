using PerficientCalendar.Data.Entities;

namespace PerficientCalendar.Core.Repositories;

public interface IInvitationRepository : IGenericRepository<InvitationDTO>, IDisposable
{
    Task<InvitationDTO> GetByIDDeveloper(Guid idDeveloper);
    Task<InvitationDTO> GetByIDMeeting(Guid idMeeting);
    Task<DeveloperDTO> GetDeveloperDetails(Guid idDeveloper);
}