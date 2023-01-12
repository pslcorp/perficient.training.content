using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationsTypeEventDeleteTests
{
    private readonly Mock<ILogger<IOperationsTypeEvent>> LoggerMock;
    private readonly Mock<ITypeEventRepository> TypeEventRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationsTypeEvent Operations;

    public OperationsTypeEventDeleteTests()
    {
        LoggerMock = new Mock<ILogger<IOperationsTypeEvent>>();
        TypeEventRepositoryMock = new Mock<ITypeEventRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationsTypeEvent(TypeEventRepositoryMock.Object, MapperMock.Object,
                                            LoggerMock.Object);
    }

    [Fact]
    public async Task Delete200TestAsync()
    {
        var typeEvent = new TypeEventDTO()
        {
            IdTypeEvent = 5
        };
        TypeEventRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(typeEvent);
        TypeEventRepositoryMock.Setup(x => x.Delete(It.IsAny<TypeEventDTO>())).ReturnsAsync(true);
        var response = await Operations.Delete(1);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Delete404TestAsync()
    {
        TypeEventRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult((TypeEventDTO)null));
        var response = await Operations.Delete(1);
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Delete500TestAsync()
    {
        TypeEventRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Throws(new IOException());
        var response = await Operations.Delete(1);
        Assert.Equal(500, response.StatusCode);
    }
}