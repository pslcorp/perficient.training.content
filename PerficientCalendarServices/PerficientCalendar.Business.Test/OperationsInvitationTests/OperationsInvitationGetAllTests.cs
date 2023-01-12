using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationsInvitationGetAllTests
{
    private readonly Mock<ILogger<IOperationInvitation>> LoggerMock;
    private readonly Mock<IWeatherStackService> ServiceMock;
    private readonly Mock<IInvitationRepository> InvitationRepositoryMock;
    private readonly Mock<IMeetingRepository> MeetingRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationInvitation Operations;

    public OperationsInvitationGetAllTests()
    {
        LoggerMock = new Mock<ILogger<IOperationInvitation>>();
        ServiceMock = new Mock<IWeatherStackService>();
        InvitationRepositoryMock = new Mock<IInvitationRepository>();
        MeetingRepositoryMock = new Mock<IMeetingRepository>();
        MapperMock = new Mock<IMapper>();
        Operations = new OperationInvitation(ServiceMock.Object, MapperMock.Object, MeetingRepositoryMock.Object,
                                             InvitationRepositoryMock.Object, LoggerMock.Object);
    }

    [Fact]
    public async Task GetAll00TestAsync()
    {
        var invitation = new List<InvitationDTO>()
        {
            new InvitationDTO()
        };
        InvitationRepositoryMock.Setup(x => x.All()).ReturnsAsync(invitation);
        var response = await Operations.GetAll();
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task GetAll404TestAsync()
    {
        var invitation = new List<InvitationDTO>();
        InvitationRepositoryMock.Setup(x => x.All()).ReturnsAsync(invitation);
        var response = await Operations.GetAll();
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task GetAll500TestAsync()
    {
        InvitationRepositoryMock.Setup(x => x.All()).Throws(new IOException());
        var response = await Operations.GetAll();
        Assert.Equal(500, response.StatusCode);
    }
}