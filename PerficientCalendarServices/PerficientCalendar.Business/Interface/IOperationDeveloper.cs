using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;

namespace PerficientCalendar.Business;
public interface IOperationDeveloper
{
    public Task<Response<Developer>> AddDeveloper(Developer invitation);
    public Task<Response<Developer>> UpdateDeveloper(Developer invitation);
    public Task<Response<Developer>> GetByID(Guid idDeveloper);
    public Task<Response<Developer>> GetByName(string name);
    public Task<Response<List<Developer>>> GetByIdentifier(string identifier);
    public Task<Response<List<Developer>>> GetAll();
    public Task<Response<Developer>> Delete(Guid idDeveloper);
}
