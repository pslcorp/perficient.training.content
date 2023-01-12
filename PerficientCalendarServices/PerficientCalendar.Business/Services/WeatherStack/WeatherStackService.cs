using PerficientCalendar.Model;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
namespace PerficientCalendar.Business.Services;

public class WeatherStackService : IWeatherStackService
{
    private readonly HttpClient client = new HttpClient();
    private static IConfiguration Configuration;

    public WeatherStackService(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public async Task<WeatherStack> GetInfoCity(string city)
    {
        var response = await client.GetAsync(Configuration["WeatherStack:BaseUrl"] + "/current?access_key=" + Configuration["WeatherStack:ApiKey"] + "&query=" + city);
        var stringResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var data = JsonConvert.DeserializeObject<WeatherStack>(stringResponse);
        return data;
    }
}