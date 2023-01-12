using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;

namespace PerficientCalendar.Business;
public interface IOperationInvitation
{
    public Task<Response<Invitation>> AddInvitation(Invitation invitation);
    public Task<Response<Invitation>> UpdateInvitation(Invitation invitation);
    public Task<Response<Invitation>> GetByID(Guid idInvitation);
    public Task<Response<Invitation>> GetByIDDeveloper(Guid idDeveloper);
    public Task<Response<Invitation>> GetByIDMeeting(Guid idMeeting);
    public Task<Response<List<Invitation>>> GetAll();
    public Task<Response<Invitation>> Delete(Guid idInvitation);
}
