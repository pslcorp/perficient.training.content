using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationDeveloperDeleteTests
{
    private readonly Mock<ILogger<IOperationDeveloper>> LoggerMock;
    private readonly Mock<IDeveloperRepository> DeveloperRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationDeveloper Operations;

    public OperationDeveloperDeleteTests()
    {
        LoggerMock = new Mock<ILogger<IOperationDeveloper>>();
        DeveloperRepositoryMock = new Mock<IDeveloperRepository>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationDeveloper(DeveloperRepositoryMock.Object, LoggerMock.Object,
                                            MapperMock.Object, OfficeRepositoryMock.Object);
    }

    [Fact]
    public async Task Delete200TestAsync()
    {
        var developer = new DeveloperDTO();
        var guid = new Guid();
        DeveloperRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(developer);
        DeveloperRepositoryMock.Setup(x => x.Delete(It.IsAny<DeveloperDTO>())).ReturnsAsync(true);
        var response = await Operations.Delete(guid);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Delete404TestAsync()
    {
        var guid = new Guid();
        DeveloperRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((DeveloperDTO)null));
        DeveloperRepositoryMock.Setup(x => x.Delete(It.IsAny<DeveloperDTO>())).ReturnsAsync(true);
        var response = await Operations.Delete(guid);
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Delete500TestAsync()
    {
        var developer = new DeveloperDTO();
        var guid = new Guid();
        DeveloperRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(developer);
        DeveloperRepositoryMock.Setup(x => x.Delete(It.IsAny<DeveloperDTO>())).Throws(new IOException());
        var response = await Operations.Delete(guid);
        Assert.Equal(500, response.StatusCode);
    }
}