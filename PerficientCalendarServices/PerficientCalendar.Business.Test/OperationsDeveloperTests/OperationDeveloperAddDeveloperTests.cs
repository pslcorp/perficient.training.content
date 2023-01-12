using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using PerficientCalendar.Model;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationDeveloperAddDeveloperTests
{
    private readonly Mock<ILogger<IOperationDeveloper>> LoggerMock;
    private readonly Mock<IDeveloperRepository> DeveloperRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationDeveloper Operations;

    public OperationDeveloperAddDeveloperTests()
    {
        LoggerMock = new Mock<ILogger<IOperationDeveloper>>();
        DeveloperRepositoryMock = new Mock<IDeveloperRepository>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationDeveloper(DeveloperRepositoryMock.Object, LoggerMock.Object,
                                            MapperMock.Object, OfficeRepositoryMock.Object);
    }

    [Fact]
    public async Task Add200TestAsync()
    {
        var office = new OfficeDTO();
        var developer = new Developer();
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(office);
        DeveloperRepositoryMock.Setup(x => x.Add(It.IsAny<DeveloperDTO>())).ReturnsAsync(true);
        var response = await Operations.AddDeveloper(developer);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Add400TestAsync()
    {
        var office = new OfficeDTO();
        var developer = new Developer();
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(office);
        DeveloperRepositoryMock.Setup(x => x.Add(It.IsAny<DeveloperDTO>())).ReturnsAsync(false);
        var response = await Operations.AddDeveloper(developer);
        Assert.Equal(400, response.StatusCode);
    }

    [Fact]
    public async Task Add404TestAsync()
    {
        var developer = new Developer();
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((OfficeDTO)null));
        var response = await Operations.AddDeveloper(developer);
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Add500TestAsync()
    {
        var developer = new Developer();
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new IOException());
        var response = await Operations.AddDeveloper(developer);
        Assert.Equal(500, response.StatusCode);
    }
}