using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationsOfficeDeleteTests
{
    private readonly Mock<ILogger<IOperationsOffice>> LoggerMock;
    private readonly Mock<IWeatherStackService> ServiceMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationsOffice Operations;

    public OperationsOfficeDeleteTests()
    {
        LoggerMock = new Mock<ILogger<IOperationsOffice>>();
        ServiceMock = new Mock<IWeatherStackService>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationsOffice(ServiceMock.Object, LoggerMock.Object, OfficeRepositoryMock.Object,
                                             MapperMock.Object);
    }

    [Fact]
    public async Task Delete200TestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new OfficeDTO());
        OfficeRepositoryMock.Setup(x => x.Delete(It.IsAny<OfficeDTO>())).ReturnsAsync(true);
        var response = await Operations.Delete(new Guid());
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Delete404TestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((OfficeDTO)null));
        var response = await Operations.Delete(new Guid());
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Delete500TestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new IOException());
        var response = await Operations.Delete(new Guid());
        Assert.Equal(500, response.StatusCode);
    }
}