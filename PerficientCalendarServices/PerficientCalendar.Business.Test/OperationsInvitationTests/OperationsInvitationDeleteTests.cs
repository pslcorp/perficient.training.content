using Moq;
using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business.Test;

public class OperationsInvitationDeleteTests
{
    private readonly Mock<ILogger<IOperationInvitation>> LoggerMock;
    private readonly Mock<IWeatherStackService> ServiceMock;
    private readonly Mock<IInvitationRepository> InvitationRepositoryMock;
    private readonly Mock<IMeetingRepository> MeetingRepositoryMock;
    private readonly Mock<IMapper> MapperMock;
    private readonly OperationInvitation Operations;

    public OperationsInvitationDeleteTests()
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
    public async Task Delete200TestAsync()
    {
        var invitation = new InvitationDTO();
        InvitationRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(invitation);
        InvitationRepositoryMock.Setup(x => x.Delete(It.IsAny<InvitationDTO>())).ReturnsAsync(true);
        var response = await Operations.Delete(new Guid());
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task Delete404TestAsync()
    {
        InvitationRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((InvitationDTO)null));
        var response = await Operations.Delete(new Guid());
        Assert.Equal(404, response.StatusCode);
    }

    [Fact]
    public async Task Delete500TestAsync()
    {
        InvitationRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new IOException());
        var response = await Operations.Delete(new Guid());
        Assert.Equal(500, response.StatusCode);
    }
}