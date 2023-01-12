using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;

namespace PerficientCalendar.Business;
public interface IOperationsTypeEvent
{
    public Task<Response<TypeEvent>> AddTypeEvent(TypeEvent typeEvent);
    public Task<Response<TypeEvent>> UpdateTypeEvent(TypeEvent typeEvent);
    public Task<Response<TypeEvent>> GetByID(int idTypeEvent);
    public Task<Response<TypeEvent>> GetByName(string name);
    public Task<Response<List<TypeEvent>>> GetAll();
    public Task<Response<TypeEvent>> Delete(int idTypeEvent);
}
