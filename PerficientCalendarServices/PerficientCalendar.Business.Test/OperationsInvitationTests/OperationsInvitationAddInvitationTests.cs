using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Model;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationsInvitationAddInvitationTests
{
    private readonly Mock<ILogger<IOperationInvitation>> LoggerMock;
    private readonly Mock<IWeatherStackService> ServiceMock;
    private readonly Mock<IInvitationRepository> InvitationRepositoryMock;
    private readonly Mock<IMeetingRepository> MeetingRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationInvitation Operations;
    public OperationsInvitationAddInvitationTests()
    {
        LoggerMock = new Mock<ILogger<IOperationInvitation>>();
        ServiceMock = new Mock<IWeatherStackService>();
        InvitationRepositoryMock = new Mock<IInvitationRepository>();
        MeetingRepositoryMock = new Mock<IMeetingRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationInvitation(ServiceMock.Object, MapperMock.Object, MeetingRepositoryMock.Object,
                                             InvitationRepositoryMock.Object, LoggerMock.Object);
    }

    [Fact]
    public async Task Add200TestAsync()
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
                Name = "",
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

        InvitationRepositoryMock.Setup(x => x.GetDeveloperDetails(It.IsAny<Guid>())).ReturnsAsync(new DeveloperDTO()
        {
            Office = new OfficeDTO()
        });
        MeetingRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new MeetingDTO());
        ServiceMock.Setup(x => x.GetInfoCity(It.IsAny<string>())).ReturnsAsync(weatherStack);
        InvitationRepositoryMock.Setup(x => x.Add(It.IsAny<InvitationDTO>())).ReturnsAsync(true);
        var response = await Operations.AddInvitation(new Invitation());
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Add400TestAsync()
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
                Name = "",
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

        InvitationRepositoryMock.Setup(x => x.GetDeveloperDetails(It.IsAny<Guid>())).ReturnsAsync(new DeveloperDTO()
        {
            Office = new OfficeDTO()
        });
        MeetingRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new MeetingDTO());
        ServiceMock.Setup(x => x.GetInfoCity(It.IsAny<string>())).ReturnsAsync(weatherStack);
        InvitationRepositoryMock.Setup(x => x.Add(It.IsAny<InvitationDTO>())).ReturnsAsync(false);
        var response = await Operations.AddInvitation(new Invitation());
        Assert.Equal(400, response.StatusCode);
    }

    [Fact]
    public async Task Add404TestAsync()
    {
        MeetingRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((MeetingDTO)null));
        InvitationRepositoryMock.Setup(x => x.GetDeveloperDetails(It.IsAny<Guid>())).Returns(Task.FromResult((DeveloperDTO)null));
        var response = await Operations.AddInvitation(new Invitation());
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Add500TestAsync()
    {
        MeetingRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new IOException());
        var response = await Operations.AddInvitation(new Invitation());
        Assert.Equal(500, response.StatusCode);
    }
}