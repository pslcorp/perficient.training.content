using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;

namespace PerficientCalendar.Business;
public interface IOperationMeeting
{
    public Task<Response<Meeting>> AddMeeting(Meeting typeEvent);
    public Task<Response<Meeting>> UpdateMeeting(Meeting typeEvent);
    public Task<Response<Meeting>> GetByID(Guid idMeeting);
    public Task<Response<Meeting>> GetByName(string name);
    public Task<Response<List<Meeting>>> GetAll();
    public Task<Response<Meeting>> Delete(Guid idMeeting);
}
