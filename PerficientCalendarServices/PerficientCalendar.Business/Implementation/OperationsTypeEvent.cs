using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business;

public class OperationsTypeEvent : IOperationsTypeEvent
{
    private readonly ILogger<IOperationsTypeEvent> Logger;
    private readonly ITypeEventRepository TypeEventRepository;
    private readonly IMapper Mapper;
    public OperationsTypeEvent(ITypeEventRepository typeEventRepository, IMapper mapper, ILogger<IOperationsTypeEvent> logger)
    {
        TypeEventRepository = typeEventRepository;
        Mapper = mapper;
        Logger = logger;
    }

    public async Task<Response<TypeEvent>> Delete(int idTypeEvent)
    {
        try
        {
            var response = new Response<TypeEvent>();
            var eventType = await TypeEventRepository.GetById(idTypeEvent);
            if (eventType != null)
            {
                await TypeEventRepository.Delete(eventType);
                response.StatusCode = 200;
                response.StatusDescripton = "Event Types Was Deleted Sucessfully";
                response.ResponseObject = Mapper.Map<TypeEvent>(eventType);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Event Types Not Found ID Event Type: " + idTypeEvent.ToString();
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the delete process", exception);
            var response = new Response<TypeEvent>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the delete process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<List<TypeEvent>>> GetAll()
    {
        try
        {
            var response = new Response<List<TypeEvent>>();
            var listEventTypes = await TypeEventRepository.All();
            if (listEventTypes.Any())
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<List<TypeEventDTO>, List<TypeEvent>>(listEventTypes.ToList());
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "There Aren't Event Types";
                response.ResponseObject = Mapper.Map<List<TypeEventDTO>, List<TypeEvent>>(listEventTypes.ToList());
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the  get all process", exception);
            var response = new Response<List<TypeEvent>>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get all process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<TypeEvent>> GetByID(int idTypeEvent)
    {
        try
        {
            var response = new Response<TypeEvent>();
            var eventType = await TypeEventRepository.GetById(idTypeEvent);
            if (eventType != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<TypeEvent>(eventType);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Event Type Not Found ID Event Type: " + idTypeEvent.ToString();
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the get by id process", exception);
            var response = new Response<TypeEvent>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get by id process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<TypeEvent>> GetByName(string name)
    {
        try
        {
            var response = new Response<TypeEvent>();
            var eventType = await TypeEventRepository.GetByName(name);
            if (eventType != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<TypeEvent>(eventType);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Event Type Not Found Name: " + name;
            }

            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the get by name process", exception);
            var response = new Response<TypeEvent>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get by name process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<TypeEvent>> AddTypeEvent(TypeEvent typeEvent)
    {
        try
        {
            var response = new Response<TypeEvent>();
            var result = await TypeEventRepository.Add(Mapper.Map<TypeEventDTO>(typeEvent));
            if (result)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "Event Type Was Added Sucessfully";
                response.ResponseObject = typeEvent;
            }
            else
            {
                response.StatusCode = 400;
                response.StatusDescripton = "An Error Occurred In The Saved Process";
                response.ResponseObject = typeEvent;
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the add process", exception);
            var response = new Response<TypeEvent>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the add process, please contact the system administrator for more information."
            };
            return response;
        }
    }
    public async Task<Response<TypeEvent>> UpdateTypeEvent(TypeEvent typeEvent)
    {
        try
        {
            var response = new Response<TypeEvent>();
            var eventType = await TypeEventRepository.GetById(typeEvent.IdTypeEvent);
            if (eventType != null)
            {
                var result = await TypeEventRepository.Upsert(Mapper.Map<TypeEventDTO>(typeEvent));
                response.StatusCode = 200;
                response.StatusDescripton = "Event Type Was Updated Sucessfully";
                response.ResponseObject = Mapper.Map<TypeEvent>(typeEvent);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Event Type Not Found";
                response.ResponseObject = Mapper.Map<TypeEvent>(typeEvent);
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the update process", exception);
            var response = new Response<TypeEvent>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the update process, please contact the system administrator for more information."
            };
            return response;
        }
    }
}