using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationDeveloperGetByIdentifierTests
{
    private readonly Mock<ILogger<IOperationDeveloper>> LoggerMock;
    private readonly Mock<IDeveloperRepository> DeveloperRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationDeveloper Operations;

    public OperationDeveloperGetByIdentifierTests()
    {
        LoggerMock = new Mock<ILogger<IOperationDeveloper>>();
        DeveloperRepositoryMock = new Mock<IDeveloperRepository>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationDeveloper(DeveloperRepositoryMock.Object, LoggerMock.Object,
                                            MapperMock.Object, OfficeRepositoryMock.Object);
    }

    [Fact]
    public async Task GetByIdentifier200TestAsync()
    {
        var developer = new List<DeveloperDTO>
        {
            new DeveloperDTO()
        };
        DeveloperRepositoryMock.Setup(x => x.GetByIdentifier(It.IsAny<string>())).ReturnsAsync(developer);
        var response = await Operations.GetByIdentifier(string.Empty);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetByIdentifier404TestAsync()
    {
        var developer = new List<DeveloperDTO>();
        DeveloperRepositoryMock.Setup(x => x.GetByIdentifier(It.IsAny<string>())).ReturnsAsync(developer);
        var response = await Operations.GetByIdentifier(string.Empty);
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetByIdentifier500TestAsync()
    {
        var developer = new List<DeveloperDTO>
        {
            new DeveloperDTO()
        };
        DeveloperRepositoryMock.Setup(x => x.GetByIdentifier(It.IsAny<string>())).Throws(new IOException());
        var response = await Operations.GetByIdentifier(string.Empty);
        Assert.Equal(500, response.StatusCode);
    }
}