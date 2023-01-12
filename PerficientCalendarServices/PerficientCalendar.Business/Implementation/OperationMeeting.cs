using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business;

public class OperationMeeting : IOperationMeeting
{
    private readonly ILogger<IOperationMeeting> Logger;
    private readonly IMeetingRepository MeetingRepository;
    private readonly IOfficeRepository OfficeRepository;
    private readonly ITypeEventRepository TypeEventRepository;
    private readonly IMapper Mapper;
    public OperationMeeting(IMeetingRepository meetingRepository, IMapper mapper, ILogger<IOperationMeeting> logger,
                            IOfficeRepository officeRepository, ITypeEventRepository typeEventRepository)
    {
        MeetingRepository = meetingRepository;
        Mapper = mapper;
        OfficeRepository = officeRepository;
        TypeEventRepository = typeEventRepository;
        Logger = logger;
    }

    public async Task<Response<Meeting>> Delete(Guid idMeeting)
    {
        try
        {
            var response = new Response<Meeting>();
            var meeting = await MeetingRepository.GetById(idMeeting);
            if (meeting != null)
            {
                await MeetingRepository.Delete(meeting);
                response.StatusCode = 200;
                response.StatusDescripton = "Meeting Was Deleted Sucessfully";
                response.ResponseObject = Mapper.Map<Meeting>(meeting);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Meeting Not Found ID Meeting: " + idMeeting.ToString();
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the delete process", exception);
            var response = new Response<Meeting>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the delete process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<List<Meeting>>> GetAll()
    {
        try
        {
            var response = new Response<List<Meeting>>();
            var listMeeting = await MeetingRepository.All();
            if (listMeeting.Any())
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<List<MeetingDTO>, List<Meeting>>(listMeeting.ToList());
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "There Aren't Meetings";
                response.ResponseObject = Mapper.Map<List<MeetingDTO>, List<Meeting>>(listMeeting.ToList());
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the get all process", exception);
            var response = new Response<List<Meeting>>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get all process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Meeting>> GetByID(Guid idMeeting)
    {
        try
        {
            var response = new Response<Meeting>();
            var meeting = await MeetingRepository.GetById(idMeeting);
            if (meeting != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<Meeting>(meeting);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Meeting Not Found ID Meeting: " + idMeeting.ToString();
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the  get by id process", exception);
            var response = new Response<Meeting>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get by id process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Meeting>> GetByName(string name)
    {
        try
        {
            var response = new Response<Meeting>();
            var meeting = await MeetingRepository.GetByName(name);
            if (meeting != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<Meeting>(meeting);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Meeting Not Found Name: " + name;
            }

            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the get by name process", exception);
            var response = new Response<Meeting>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get by name process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Meeting>> AddMeeting(Meeting meeting)
    {
        try
        {
            var response = new Response<Meeting>();
            var office = await OfficeRepository.GetById(meeting.IdOffice);
            var eventType = await TypeEventRepository.GetById(meeting.IdMeeting);
            if (office != null && eventType != null)
            {
                var result = await MeetingRepository.Add(Mapper.Map<MeetingDTO>(meeting));
                if (result)
                {
                    response.StatusCode = 200;
                    response.StatusDescripton = "Office Was Added Sucessfully";
                    response.ResponseObject = meeting;
                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusDescripton = "An Error Occurred In The Saved Process";
                    response.ResponseObject = meeting;
                }
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = office == null ? "Office Not Found " : "";
                response.StatusDescripton = response.StatusDescripton + eventType == null ? " Event Type Not Found " : "";
                response.ResponseObject = Mapper.Map<Meeting>(meeting);
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the add process", exception);
            var response = new Response<Meeting>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the add process, please contact the system administrator for more information."
            };
            return response;
        }
    }
    public async Task<Response<Meeting>> UpdateMeeting(Meeting meeting)
    {
        try
        {
            var response = new Response<Meeting>();
            var office = await OfficeRepository.GetById(meeting.IdOffice);
            var eventType = await TypeEventRepository.GetById(meeting.IdMeeting);
            if (office != null && eventType != null)
            {
                var MeetingResult = await MeetingRepository.GetById(meeting.IdMeeting);

                if (MeetingResult != null)
                {
                    var result = await MeetingRepository.Upsert(Mapper.Map<MeetingDTO>(meeting));
                    response.StatusCode = 200;
                    response.StatusDescripton = "Office Was Updated Sucessfully";
                    response.ResponseObject = meeting;
                }
                else
                {
                    response.StatusCode = 404;
                    response.StatusDescripton = "Meeting Not Found";
                    response.ResponseObject = meeting;
                }
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = office == null ? "Office Not Found " : "";
                response.StatusDescripton = response.StatusDescripton + eventType == null ? " Event Type Not Found " : "";
                response.ResponseObject = Mapper.Map<Meeting>(meeting);
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the update process", exception);
            var response = new Response<Meeting>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the update process, please contact the system administrator for more information."
            };
            return response;
        }
    }
}