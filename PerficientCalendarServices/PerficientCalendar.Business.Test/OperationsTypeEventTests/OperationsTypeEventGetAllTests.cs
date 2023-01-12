using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationsTypeEventGetAllTests
{
    private readonly Mock<ILogger<IOperationsTypeEvent>> LoggerMock;
    private readonly Mock<ITypeEventRepository> TypeEventRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationsTypeEvent Operations;

    public OperationsTypeEventGetAllTests()
    {
        LoggerMock = new Mock<ILogger<IOperationsTypeEvent>>();
        TypeEventRepositoryMock = new Mock<ITypeEventRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationsTypeEvent(TypeEventRepositoryMock.Object, MapperMock.Object,
                                            LoggerMock.Object);
    }

    [Fact]
    public async Task GetAll200TestAsync()
    {
        var typeEvent = new List<TypeEventDTO>()
        {
            new TypeEventDTO()
        };
        TypeEventRepositoryMock.Setup(x => x.All()).ReturnsAsync(typeEvent);
        var response = await Operations.GetAll();
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetAll04TestAsync()
    {
        var typeEvent = new List<TypeEventDTO>();
        TypeEventRepositoryMock.Setup(x => x.All()).ReturnsAsync(typeEvent);
        var response = await Operations.GetAll();
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetAll500TestAsync()
    {
        TypeEventRepositoryMock.Setup(x => x.All()).Throws(new IOException());
        var response = await Operations.GetAll();
        Assert.Equal(500, response.StatusCode);
    }
}