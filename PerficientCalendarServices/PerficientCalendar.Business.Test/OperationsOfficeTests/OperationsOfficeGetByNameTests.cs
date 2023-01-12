using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationsOfficeGetByNameTests
{
    private readonly Mock<ILogger<IOperationsOffice>> LoggerMock;
    private readonly Mock<IWeatherStackService> ServiceMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationsOffice Operations;

    public OperationsOfficeGetByNameTests()
    {
        LoggerMock = new Mock<ILogger<IOperationsOffice>>();
        ServiceMock = new Mock<IWeatherStackService>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationsOffice(ServiceMock.Object, LoggerMock.Object, OfficeRepositoryMock.Object,
                                             MapperMock.Object);
    }

    [Fact]
    public async Task GetByName200TestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(new OfficeDTO());
        var response = await Operations.GetByName(string.Empty);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetByName404TestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).Returns(Task.FromResult((OfficeDTO)null));
        var response = await Operations.GetByName(string.Empty);
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetByName500TestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).Throws(new IOException());
        var response = await Operations.GetByName(string.Empty);
        Assert.Equal(500, response.StatusCode);
    }
}