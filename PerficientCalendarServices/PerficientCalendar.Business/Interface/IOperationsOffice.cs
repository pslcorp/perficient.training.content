using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;

namespace PerficientCalendar.Business;
public interface IOperationsOffice
{
    public Task<Response<Office>> AddOffice(Office office);
    public Task<Response<Office>> UpdateOffice(Office office);
    public Task<Response<Office>> GetByID(Guid idOffice);
    public Task<Response<Office>> GetByName(string name);
    public Task<Response<List<Office>>> GetAll();
    public Task<Response<Office>> Delete(Guid idOffice);
}
