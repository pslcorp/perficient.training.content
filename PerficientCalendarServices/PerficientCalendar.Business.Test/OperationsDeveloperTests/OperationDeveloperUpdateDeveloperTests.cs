using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using PerficientCalendar.Model;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationDeveloperUpdateDeveloperTests
{
    private readonly Mock<ILogger<IOperationDeveloper>> LoggerMock;
    private readonly Mock<IDeveloperRepository> DeveloperRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationDeveloper Operations;

    public OperationDeveloperUpdateDeveloperTests()
    {
        LoggerMock = new Mock<ILogger<IOperationDeveloper>>();
        DeveloperRepositoryMock = new Mock<IDeveloperRepository>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationDeveloper(DeveloperRepositoryMock.Object, LoggerMock.Object,
                                            MapperMock.Object, OfficeRepositoryMock.Object);
    }

    [Fact]
    public async Task Update200TestAsync()
    {
        var office = new OfficeDTO();
        var developer = new Developer();
        var developerResult = new DeveloperDTO();
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(office);
        DeveloperRepositoryMock.Setup(x => x.Upsert(It.IsAny<DeveloperDTO>())).ReturnsAsync(developerResult);
        DeveloperRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(developerResult);
        var response = await Operations.UpdateDeveloper(developer);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Update404OfficeTestAsync()
    {
        var office = new OfficeDTO();
        var developer = new Developer();
        var developerResult = new DeveloperDTO();
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((OfficeDTO)null));
        DeveloperRepositoryMock.Setup(x => x.Upsert(It.IsAny<DeveloperDTO>())).ReturnsAsync(developerResult);
        DeveloperRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(developerResult);
        var response = await Operations.UpdateDeveloper(developer);
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Update404DeveloperTestAsync()
    {
        var developer = new Developer();
        var developerResult = new DeveloperDTO();
        DeveloperRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((DeveloperDTO)null));
        var response = await Operations.UpdateDeveloper(developer);
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Update500TestAsync()
    {
        var developer = new Developer();
        var developerResult = new DeveloperDTO();
        DeveloperRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new IOException());
        var response = await Operations.UpdateDeveloper(developer);
        Assert.Equal(500, response.StatusCode);
    }
}