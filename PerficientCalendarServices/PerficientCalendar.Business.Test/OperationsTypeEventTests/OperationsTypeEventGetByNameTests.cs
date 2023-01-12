using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationsTypeEventGetByNameTests
{
    private readonly Mock<ILogger<IOperationsTypeEvent>> LoggerMock;
    private readonly Mock<ITypeEventRepository> TypeEventRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationsTypeEvent Operations;

    public OperationsTypeEventGetByNameTests()
    {
        LoggerMock = new Mock<ILogger<IOperationsTypeEvent>>();
        TypeEventRepositoryMock = new Mock<ITypeEventRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationsTypeEvent(TypeEventRepositoryMock.Object, MapperMock.Object,
                                            LoggerMock.Object);
    }

    [Fact]
    public async Task GetByName200TestAsync()
    {
        var typeEvent = new TypeEventDTO()
        {
            IdTypeEvent = 5
        };
        TypeEventRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(typeEvent);
        var response = await Operations.GetByName(string.Empty);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetByName404TestAsync()
    {
        TypeEventRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).Returns(Task.FromResult((TypeEventDTO)null));
        var response = await Operations.GetByName(string.Empty);
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetByName500TestAsync()
    {
        var typeEvent = new TypeEventDTO();
        TypeEventRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).Throws(new IOException());
        var response = await Operations.GetByName(string.Empty);
        Assert.Equal(500, response.StatusCode);
    }
}