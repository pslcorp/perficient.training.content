using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationRoomUpdateRoomTests
{
    private readonly Mock<ILogger<IOperationRoom>> LoggerMock;
    private readonly Mock<IRoomRepository> RoomRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationRoom Operations;

    public OperationRoomUpdateRoomTests()
    {
        LoggerMock = new Mock<ILogger<IOperationRoom>>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        RoomRepositoryMock = new Mock<IRoomRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationRoom(RoomRepositoryMock.Object, LoggerMock.Object,
                                             OfficeRepositoryMock.Object, MapperMock.Object);
    }

    [Fact]
    public async Task Update200TestAsync()
    {
        RoomRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new RoomDTO());
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new OfficeDTO());
        RoomRepositoryMock.Setup(x => x.Upsert(It.IsAny<RoomDTO>())).ReturnsAsync(new RoomDTO());
        var response = await Operations.UpdateRoom(new Room());
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Update404OfficeTestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((OfficeDTO)null));
        var response = await Operations.UpdateRoom(new Room());
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Update404RoomTestAsync()
    {
        RoomRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((RoomDTO)null));
        var response = await Operations.UpdateRoom(new Room());
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Update500TestAsync()
    {
        RoomRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new IOException());
        var response = await Operations.UpdateRoom(new Room());
        Assert.Equal(500, response.StatusCode);
    }
}