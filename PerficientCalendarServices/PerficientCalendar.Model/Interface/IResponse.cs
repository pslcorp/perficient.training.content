
namespace PerficientCalendar.Model;

public interface IResponse<T>
{
    public int StatusCode { get; set; }
    public string StatusDescripton { get; set; }
    public T ResponseObject { get; set; }

}
