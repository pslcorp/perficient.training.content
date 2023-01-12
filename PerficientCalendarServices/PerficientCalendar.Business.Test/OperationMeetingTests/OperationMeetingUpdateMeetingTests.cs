using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationMeetingUpdateMeetingTests
{
    private readonly Mock<ILogger<IOperationMeeting>> LoggerMock;
    private readonly Mock<IMeetingRepository> MeetingRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<ITypeEventRepository> TypeEventRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationMeeting Operations;

    public OperationMeetingUpdateMeetingTests()
    {
        LoggerMock = new Mock<ILogger<IOperationMeeting>>();
        MeetingRepositoryMock = new Mock<IMeetingRepository>();
        OfficeRepositoryMock = new Mock<IOfficeRepository>();
        TypeEventRepositoryMock = new Mock<ITypeEventRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationMeeting(MeetingRepositoryMock.Object, MapperMock.Object, LoggerMock.Object,
                                             OfficeRepositoryMock.Object, TypeEventRepositoryMock.Object);
    }

    [Fact]
    public async Task Update200TestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new OfficeDTO());
        TypeEventRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new TypeEventDTO());
        MeetingRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new MeetingDTO());
        MeetingRepositoryMock.Setup(x => x.Upsert(It.IsAny<MeetingDTO>())).ReturnsAsync(new MeetingDTO());
        var response = await Operations.UpdateMeeting(new Meeting());
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Update404OfficeTestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new OfficeDTO());
        TypeEventRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new TypeEventDTO());
        MeetingRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((MeetingDTO)null));
        var response = await Operations.UpdateMeeting(new Meeting());
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Update404DeveloperTestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((OfficeDTO)null));
        TypeEventRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((TypeEventDTO)null));
        var response = await Operations.UpdateMeeting(new Meeting());
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Update500TestAsync()
    {
        OfficeRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new IOException());
        var response = await Operations.UpdateMeeting(new Meeting());
        Assert.Equal(500, response.StatusCode);
    }
}