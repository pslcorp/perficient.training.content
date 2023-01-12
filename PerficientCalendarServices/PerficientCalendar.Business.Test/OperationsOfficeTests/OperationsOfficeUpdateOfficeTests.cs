using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Core.Repositories;
using PerficientCalendar.Model;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationsOfficeUpdateOfficeTests
{
    private readonly Mock<ILogger<IOperationsOffice>> LoggerMock;
    private readonly Mock<IWeatherStackService> ServiceMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationsOffice Operations;

    public OperationsOfficeUpdateOfficeTests()
    {
        LoggerMock = new Mock<ILogger<IOperationsOffice>>();
        ServiceMock = new Mock<IWeatherStackService>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationsOffice(ServiceMock.Object, LoggerMock.Object, OfficeRepositoryMock.Object,
                                             MapperMock.Object);
    }

    [Fact]
    public async Task Update200TestAsync()
    {
        var weatherStack = new WeatherStack
        {
            Current = new Current()
            {
                CloudCover = 1,
                FeelsLike = 1,
                Humidity = 2,
                ObservationTime = "Time",
                Precipitation = 3,
                Pressure = 1,
                Temperature = 2,
                UVIndex = 4,
                Visibility = 1,
                WeatherCode = 2,
                WeatherDescriptions = new List<string>(),
                WeatherIcons = new List<string>(),
                WindDegree = 1,
                WinDirection = "",
                WindSpeed = 1
            },
            Location = new Location()
            {
                Country = "",
                Latitude = "24",
                LocalTime = "",
                LocalTimeEpoch = 20,
                Longitude = "251",
                Name = "Madrid",
                Region = "",
                TimeZoneId = "",
                UTCOffSet = "3.0"
            },
            Request = new Request()
            {
                Language = "EN",
                Query = "",
                Type = "",
                Unit = ""
            }
        };

        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new OfficeDTO()
        {
            City = "Madrid"
        });
        ServiceMock.Setup(x => x.GetInfoCity(It.IsAny<string>())).ReturnsAsync(weatherStack);
        var response = await Operations.UpdateOffice(new Office()
        {
            City = "Madrid"
        });
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Update404TestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((OfficeDTO)null));
        var response = await Operations.UpdateOffice(new Office());
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Update500TestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new IOException());
        var response = await Operations.UpdateOffice(new Office());
        Assert.Equal(500, response.StatusCode);
    }
}