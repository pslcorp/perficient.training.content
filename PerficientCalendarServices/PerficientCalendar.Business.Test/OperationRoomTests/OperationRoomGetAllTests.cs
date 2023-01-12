using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationRoomGetAllTests
{
    private readonly Mock<ILogger<IOperationRoom>> LoggerMock;
    private readonly Mock<IRoomRepository> RoomRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationRoom Operations;

    public OperationRoomGetAllTests()
    {
        LoggerMock = new Mock<ILogger<IOperationRoom>>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        RoomRepositoryMock = new Mock<IRoomRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationRoom(RoomRepositoryMock.Object, LoggerMock.Object,
                                             OfficeRepositoryMock.Object, MapperMock.Object);
    }

    [Fact]
    public async Task GetAll00TestAsync()
    {
        var room = new List<RoomDTO>()
        {
            new RoomDTO()
        };
        RoomRepositoryMock.Setup(x => x.All()).ReturnsAsync(room);
        var response = await Operations.GetAll();
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetAll404TestAsync()
    {
        var room = new List<RoomDTO>();
        RoomRepositoryMock.Setup(x => x.All()).ReturnsAsync(room);
        var response = await Operations.GetAll();
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetAll500TestAsync()
    {
        RoomRepositoryMock.Setup(x => x.All()).Throws(new IOException());
        var response = await Operations.GetAll();
        Assert.Equal(500, response.StatusCode);
    }
}