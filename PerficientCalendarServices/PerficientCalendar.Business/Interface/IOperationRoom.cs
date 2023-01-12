using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;

namespace PerficientCalendar.Business;
public interface IOperationRoom
{
    public Task<Response<Room>> AddRoom(Room typeEvent);
    public Task<Response<Room>> UpdateRoom(Room typeEvent);
    public Task<Response<Room>> GetByID(Guid idRoom);
    public Task<Response<Room>> GetByName(string name);
    public Task<Response<List<Room>>> GetAll();
    public Task<Response<Room>> Delete(Guid idRoom);
}
