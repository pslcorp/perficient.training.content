using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationDeveloperGetByNameTests
{
    private readonly Mock<ILogger<IOperationDeveloper>> LoggerMock;
    private readonly Mock<IDeveloperRepository> DeveloperRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationDeveloper Operations;

    public OperationDeveloperGetByNameTests()
    {
        LoggerMock = new Mock<ILogger<IOperationDeveloper>>();
        DeveloperRepositoryMock = new Mock<IDeveloperRepository>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationDeveloper(DeveloperRepositoryMock.Object, LoggerMock.Object,
                                            MapperMock.Object, OfficeRepositoryMock.Object);
    }

    [Fact]
    public async Task GetByName200TestAsync()
    {
        var developer = new DeveloperDTO();
        DeveloperRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(developer);
        var response = await Operations.GetByName(string.Empty);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetByName404TestAsync()
    {
        DeveloperRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).Returns(Task.FromResult((DeveloperDTO)null));
        var response = await Operations.GetByName(string.Empty);
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetByName500TestAsync()
    {
        DeveloperRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).Throws(new IOException());
        var response = await Operations.GetByName(string.Empty);
        Assert.Equal(500, response.StatusCode);
    }
}