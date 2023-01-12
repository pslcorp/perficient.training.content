namespace PerficientCalendar.Model;

public class Response<T> : IResponse<T>
{
    public int StatusCode { get; set; }
    public string StatusDescripton { get; set; } = null!;
    public T ResponseObject { get; set; }
}
