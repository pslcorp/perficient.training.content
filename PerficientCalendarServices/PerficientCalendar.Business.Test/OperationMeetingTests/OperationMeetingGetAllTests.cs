using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationMeetingGetAllTests
{
    private readonly Mock<ILogger<IOperationMeeting>> LoggerMock;
    private readonly Mock<IMeetingRepository> MeetingRepositoryMock;
    private readonly Mock<IOfficeRepository> OfficeRepositoryMock;
    private readonly Mock<ITypeEventRepository> TypeEventRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationMeeting Operations;

    public OperationMeetingGetAllTests()
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
    public async Task GetAll00TestAsync()
    {
        var meeting = new List<MeetingDTO>()
        {
            new MeetingDTO()
        };
        MeetingRepositoryMock.Setup(x => x.All()).ReturnsAsync(meeting);
        var response = await Operations.GetAll();
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetAll404TestAsync()
    {
        var meeting = new List<MeetingDTO>();
        MeetingRepositoryMock.Setup(x => x.All()).ReturnsAsync(meeting);
        var response = await Operations.GetAll();
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetAll500TestAsync()
    {
        MeetingRepositoryMock.Setup(x => x.All()).Throws(new IOException());
        var response = await Operations.GetAll();
        Assert.Equal(500, response.StatusCode);
    }
}