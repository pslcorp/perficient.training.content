using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationDeveloperGetByIDTests
{
    private readonly Mock<ILogger<IOperationDeveloper>> LoggerMock;
    private readonly Mock<IDeveloperRepository> DeveloperRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationDeveloper Operations;

    public OperationDeveloperGetByIDTests()
    {
        LoggerMock = new Mock<ILogger<IOperationDeveloper>>();
        DeveloperRepositoryMock = new Mock<IDeveloperRepository>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationDeveloper(DeveloperRepositoryMock.Object, LoggerMock.Object,
                                            MapperMock.Object, OfficeRepositoryMock.Object);
    }

    [Fact]
    public async Task GetByID200TestAsync()
    {
        var developer = new DeveloperDTO();
        var guid = new Guid();
        DeveloperRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(developer);
        var response = await Operations.GetByID(guid);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetByID404TestAsync()
    {
        var guid = new Guid();
        DeveloperRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((DeveloperDTO)null));
        var response = await Operations.GetByID(guid);
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetByID500TestAsync()
    {
        var guid = new Guid();
        DeveloperRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new IOException());
        var response = await Operations.GetByID(guid);
        Assert.Equal(500, response.StatusCode);
    }
}