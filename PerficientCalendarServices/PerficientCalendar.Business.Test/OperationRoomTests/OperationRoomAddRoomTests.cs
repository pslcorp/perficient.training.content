using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationRoomAddRoomTests
{
    private readonly Mock<ILogger<IOperationRoom>> LoggerMock;
    private readonly Mock<IRoomRepository> RoomRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationRoom Operations;

    public OperationRoomAddRoomTests()
    {
        LoggerMock = new Mock<ILogger<IOperationRoom>>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        RoomRepositoryMock = new Mock<IRoomRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationRoom(RoomRepositoryMock.Object, LoggerMock.Object,
                                             OfficeRepositoryMock.Object, MapperMock.Object);
    }

    [Fact]
    public async Task Add200TestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new OfficeDTO());
        RoomRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new RoomDTO());
        RoomRepositoryMock.Setup(x => x.Add(It.IsAny<RoomDTO>())).ReturnsAsync(true);
        var response = await Operations.AddRoom(new Room());
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Add400TestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new OfficeDTO());
        RoomRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new RoomDTO());
        RoomRepositoryMock.Setup(x => x.Add(It.IsAny<RoomDTO>())).ReturnsAsync(false);
        var response = await Operations.AddRoom(new Room());
        Assert.Equal(400, response.StatusCode);
    }

    [Fact]
    public async Task Add404TestAsync()
    {
        var developer = new Developer();
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((OfficeDTO)null));
        var response = await Operations.AddRoom(new Room());
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Add500TestAsync()
    {
        var developer = new Developer();
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new IOException());
        var response = await Operations.AddRoom(new Room());
        Assert.Equal(500, response.StatusCode);
    }
}