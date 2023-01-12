using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationDeveloperGetAllTests
{
    private readonly Mock<ILogger<IOperationDeveloper>> LoggerMock;
    private readonly Mock<IDeveloperRepository> DeveloperRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationDeveloper Operations;

    public OperationDeveloperGetAllTests()
    {
        LoggerMock = new Mock<ILogger<IOperationDeveloper>>();
        DeveloperRepositoryMock = new Mock<IDeveloperRepository>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationDeveloper(DeveloperRepositoryMock.Object, LoggerMock.Object,
                                            MapperMock.Object, OfficeRepositoryMock.Object);
    }

    [Fact]
    public async Task GetAll200TestAsync()
    {
        var developer = new List<DeveloperDTO>
        {
            new DeveloperDTO()
        };
        DeveloperRepositoryMock.Setup(x => x.All()).ReturnsAsync(developer);
        var response = await Operations.GetAll();
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetAll404TestAsync()
    {
        var developer = new List<DeveloperDTO>();
        DeveloperRepositoryMock.Setup(x => x.All()).ReturnsAsync(developer);
        var response = await Operations.GetAll();
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetAll500TestAsync()
    {
        DeveloperRepositoryMock.Setup(x => x.All()).Throws(new IOException());
        var response = await Operations.GetAll();
        Assert.Equal(500, response.StatusCode);
    }
}