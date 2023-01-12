using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationRoomGetByIDTests
{
    private readonly Mock<ILogger<IOperationRoom>> LoggerMock;
    private readonly Mock<IRoomRepository> RoomRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationRoom Operations;

    public OperationRoomGetByIDTests()
    {
        LoggerMock = new Mock<ILogger<IOperationRoom>>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        RoomRepositoryMock = new Mock<IRoomRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationRoom(RoomRepositoryMock.Object, LoggerMock.Object,
                                             OfficeRepositoryMock.Object, MapperMock.Object);
    }

    [Fact]
    public async Task GetByID200TestAsync()
    {
        RoomRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new RoomDTO());
        var response = await Operations.GetByID(new Guid());
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetByID404TestAsync()
    {
        RoomRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((RoomDTO)null));
        var response = await Operations.GetByID(new Guid());
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetByID500TestAsync()
    {
        RoomRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new IOException());
        var response = await Operations.GetByID(new Guid());
        Assert.Equal(500, response.StatusCode);
    }
}