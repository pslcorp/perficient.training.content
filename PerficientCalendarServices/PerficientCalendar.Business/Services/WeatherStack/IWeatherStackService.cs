using PerficientCalendar.Model;

namespace PerficientCalendar.Business.Services;

public interface IWeatherStackService
{
    public Task<WeatherStack> GetInfoCity(string city);
}