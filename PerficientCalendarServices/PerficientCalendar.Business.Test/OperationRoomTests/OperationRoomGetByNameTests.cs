using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationRoomGetByNameTests
{
    private readonly Mock<ILogger<IOperationRoom>> LoggerMock;
    private readonly Mock<IRoomRepository> RoomRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationRoom Operations;

    public OperationRoomGetByNameTests()
    {
        LoggerMock = new Mock<ILogger<IOperationRoom>>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        RoomRepositoryMock = new Mock<IRoomRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationRoom(RoomRepositoryMock.Object, LoggerMock.Object,
                                             OfficeRepositoryMock.Object, MapperMock.Object);
    }

    [Fact]
    public async Task GetByName200TestAsync()
    {
        RoomRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(new RoomDTO());
        var response = await Operations.GetByName(string.Empty);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetByName404TestAsync()
    {
        RoomRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).Returns(Task.FromResult((RoomDTO)null));
        var response = await Operations.GetByName(string.Empty);
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetByName500TestAsync()
    {
        RoomRepositoryMock.Setup(x => x.GetByName(It.IsAny<string>())).Throws(new IOException());
        var response = await Operations.GetByName(string.Empty);
        Assert.Equal(500, response.StatusCode);
    }
}