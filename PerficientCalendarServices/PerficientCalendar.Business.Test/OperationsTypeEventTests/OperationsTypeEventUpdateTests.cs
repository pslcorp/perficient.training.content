using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;
using PerficientCalendar.Model;

namespace PerficientCalendar.Business.Test;

public class OperationsTypeEventUpdateTests
{
    private readonly Mock<ILogger<IOperationsTypeEvent>> LoggerMock;
    private readonly Mock<ITypeEventRepository> TypeEventRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationsTypeEvent Operations;

    public OperationsTypeEventUpdateTests()
    {
        LoggerMock = new Mock<ILogger<IOperationsTypeEvent>>();
        TypeEventRepositoryMock = new Mock<ITypeEventRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationsTypeEvent(TypeEventRepositoryMock.Object, MapperMock.Object,
                                            LoggerMock.Object);
    }

    [Fact]
    public async Task Update200TestAsync()
    {
        var typeEvent = new TypeEventDTO()
        {
            IdTypeEvent = 5
        };
        TypeEventRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(typeEvent);
        TypeEventRepositoryMock.Setup(x => x.Upsert(It.IsAny<TypeEventDTO>())).ReturnsAsync(typeEvent);
        var response = await Operations.UpdateTypeEvent(new TypeEvent());
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Update404TestAsync()
    {
        TypeEventRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult((TypeEventDTO)null));
        var response = await Operations.UpdateTypeEvent(new TypeEvent());
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Update500TestAsync()
    {
        TypeEventRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Throws(new IOException());
        var response = await Operations.UpdateTypeEvent(new TypeEvent());
        Assert.Equal(500, response.StatusCode);
    }
}