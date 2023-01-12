using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationMeetingGetByIDTests
{
    private readonly Mock<ILogger<IOperationMeeting>> LoggerMock;
    private readonly Mock<IMeetingRepository> MeetingRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<ITypeEventRepository> TypeEventRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationMeeting Operations;

    public OperationMeetingGetByIDTests()
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
    public async Task GetByID200TestAsync()
    {
        MeetingRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new MeetingDTO());
        var response = await Operations.GetByID(new Guid());
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetByID404TestAsync()
    {
        MeetingRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((MeetingDTO)null));
        var response = await Operations.GetByID(new Guid());
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetByID500TestAsync()
    {
        MeetingRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new IOException());
        var response = await Operations.GetByID(new Guid());
        Assert.Equal(500, response.StatusCode);
    }
}