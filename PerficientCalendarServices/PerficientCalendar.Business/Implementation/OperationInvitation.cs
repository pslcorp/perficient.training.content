using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Model;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business;

public class OperationInvitation : IOperationInvitation
{
    private readonly ILogger<IOperationInvitation> Logger;
    private readonly IWeatherStackService Service;
    private readonly IInvitationRepository InvitationRepository;
    private readonly IMeetingRepository MeetingRepository;
    private readonly IMapper Mapper;
    public OperationInvitation(IWeatherStackService service, IMapper mapper, IMeetingRepository meetingRepository,
                              IInvitationRepository invitationRepository, ILogger<IOperationInvitation> logger)
    {
        Service = service;
        Mapper = mapper;
        InvitationRepository = invitationRepository;
        MeetingRepository = meetingRepository;
        Logger = logger;
    }
    public async Task<Response<Invitation>> Delete(Guid idInvitation)
    {
        try
        {
            var response = new Response<Invitation>();
            var invitation = await InvitationRepository.GetById(idInvitation);
            if (invitation != null)
            {
                await InvitationRepository.Delete(invitation);
                response.StatusCode = 200;
                response.StatusDescripton = "Invitation Was Deleted Sucessfully";
                response.ResponseObject = Mapper.Map<Invitation>(invitation);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Invitation Not Found ID: " + idInvitation.ToString();
                response.ResponseObject = Mapper.Map<Invitation>(invitation);
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the delete process", exception);
            var response = new Response<Invitation>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the delete process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<List<Invitation>>> GetAll()
    {
        try
        {
            var response = new Response<List<Invitation>>();
            var listInvitations = await InvitationRepository.All();
            if (listInvitations.Any())
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<List<InvitationDTO>, List<Invitation>>(listInvitations.ToList());
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "There Aren't Invitations";
                response.ResponseObject = Mapper.Map<List<InvitationDTO>, List<Invitation>>(listInvitations.ToList());
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the delete process", exception);
            var response = new Response<List<Invitation>>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get all process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Invitation>> GetByID(Guid idInvitation)
    {
        try
        {
            var response = new Response<Invitation>();
            var invitation = await InvitationRepository.GetById(idInvitation);
            if (invitation != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<Invitation>(invitation);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Invitation Not Found ID Invitation: " + idInvitation.ToString();
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the get by id process", exception);
            var response = new Response<Invitation>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get by id process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Invitation>> GetByIDDeveloper(Guid idDeveloper)
    {
        try
        {
            var response = new Response<Invitation>();
            var invitation = await InvitationRepository.GetByIDDeveloper(idDeveloper);

            if (invitation != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<Invitation>(invitation);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Invitation Not Found ID Developer: " + idDeveloper.ToString();
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the get by id developer process", exception);
            var response = new Response<Invitation>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get by id developer process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Invitation>> GetByIDMeeting(Guid idMeeting)
    {
        try
        {
            var response = new Response<Invitation>();
            var invitation = await InvitationRepository.GetByIDMeeting(idMeeting);
            if (invitation != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<Invitation>(invitation);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Invitation Not Found ID Meeting: " + idMeeting.ToString();
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the get by id meeting process", exception);
            var response = new Response<Invitation>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get by id meeting process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Invitation>> AddInvitation(Invitation invitation)
    {
        try
        {
            var response = new Response<Invitation>();
            var developer = await InvitationRepository.GetDeveloperDetails(invitation.IdDeveloper);
            var meeting = await MeetingRepository.GetById(invitation.IdMeeting);
            if (developer != null && meeting != null)
            {
                var WeatherStackResponse = await Service.GetInfoCity(developer.Office.City);
                invitation.UtctimeZone = Convert.ToDouble(WeatherStackResponse.Location.UTCOffSet.Replace('.', ','));
                invitation.Status = "PENDING";
                invitation.LocalStartTime = developer.Office.City != developer.CurrentLocation ?
                                                       meeting.StartHour.AddHours(invitation.UtctimeZone) :
                                                       meeting.StartHour;
                invitation.LocalEndTime = developer.Office.City != developer.CurrentLocation ?
                                            meeting.EndHour.AddHours(invitation.UtctimeZone) :
                                            meeting.EndHour;

                var result = await InvitationRepository.Add(Mapper.Map<InvitationDTO>(invitation));
                if (result)
                {
                    response.StatusCode = 200;
                    response.StatusDescripton = "Invitation Was Added Sucessfully";
                    response.ResponseObject = Mapper.Map<Invitation>(invitation);
                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusDescripton = "An Error Occurred In The Saved Process";
                    response.ResponseObject = Mapper.Map<Invitation>(invitation);
                }
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = developer == null ? "Developer Not Found " : "";
                response.StatusDescripton = response.StatusDescripton + meeting == null ? " Meeting Not Found " : "";
                response.ResponseObject = Mapper.Map<Invitation>(invitation);
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the Add process", exception);
            var response = new Response<Invitation>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the Add process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Invitation>> UpdateInvitation(Invitation invitation)
    {
        try
        {
            var response = new Response<Invitation>();
            var result = await InvitationRepository.GetById(invitation.IdInvitation);
            if (result != null)
            {
                var developer = await InvitationRepository.GetDeveloperDetails(invitation.IdDeveloper);
                var meeting = await MeetingRepository.GetById(invitation.IdMeeting);
                if (developer != null && meeting != null)
                {
                    var WeatherStackResponse = await Service.GetInfoCity(developer.Office.City);
                    result.IdDeveloper = invitation.IdDeveloper;
                    result.IdMeeting = invitation.IdDeveloper;
                    result.Status = invitation.Status;
                    result.UtctimeZone = Convert.ToDouble(WeatherStackResponse.Location.UTCOffSet.Replace('.', ','));
                    await InvitationRepository.Upsert(result);
                    response.StatusCode = 200;
                    response.StatusDescripton = "Invitation Was Updated Sucessfully";
                    response.ResponseObject = Mapper.Map<Invitation>(invitation);
                }
                else
                {
                    response.StatusCode = 404;
                    response.StatusDescripton = developer == null ? "Developer Not Found " : "";
                    response.StatusDescripton = response.StatusDescripton + meeting == null ? " Meeting Not Found " : "";
                    response.ResponseObject = Mapper.Map<Invitation>(invitation);
                }
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Meeting Not Found";
                response.ResponseObject = Mapper.Map<Invitation>(invitation);
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the update process", exception);
            var response = new Response<Invitation>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the update process, please contact the system administrator for more information."
            };
            return response;
        }
    }
}