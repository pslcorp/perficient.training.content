using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using PerficientCalendar.Model;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationsTypeEventAddTests
{
    private readonly Mock<ILogger<IOperationsTypeEvent>> LoggerMock;
    private readonly Mock<ITypeEventRepository> TypeEventRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationsTypeEvent Operations;

    public OperationsTypeEventAddTests()
    {
        LoggerMock = new Mock<ILogger<IOperationsTypeEvent>>();
        TypeEventRepositoryMock = new Mock<ITypeEventRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationsTypeEvent(TypeEventRepositoryMock.Object, MapperMock.Object,
                                            LoggerMock.Object);
    }

    [Fact]
    public async Task Add200TestAsync()
    {
        TypeEventRepositoryMock.Setup(x => x.Add(It.IsAny<TypeEventDTO>())).ReturnsAsync(true);
        var response = await Operations.AddTypeEvent(new TypeEvent());
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Add400TestAsync()
    {
        TypeEventRepositoryMock.Setup(x => x.Add(It.IsAny<TypeEventDTO>())).ReturnsAsync(false);
        var response = await Operations.AddTypeEvent(new TypeEvent());
        Assert.Equal(400, response.StatusCode);
    }

    [Fact]
    public async Task Add500TestAsync()
    {
        TypeEventRepositoryMock.Setup(x => x.Add(It.IsAny<TypeEventDTO>())).Throws(new IOException());
        var response = await Operations.AddTypeEvent(new TypeEvent());
        Assert.Equal(500, response.StatusCode);
    }
}