using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business;

public class OperationRoom : IOperationRoom
{
    private readonly ILogger<IOperationRoom> Logger;
    private readonly IRoomRepository RoomRepository;
    private readonly IOfficeRepository OfficeRepository;
    private readonly IMapper Mapper;
    public OperationRoom(IRoomRepository roomRepository, ILogger<IOperationRoom> logger,
                         IOfficeRepository officeRepository, IMapper mapper)
    {
        RoomRepository = roomRepository;
        OfficeRepository = officeRepository;
        Mapper = mapper;
        Logger = logger;
    }

    public async Task<Response<Room>> Delete(Guid idRoom)
    {
        try
        {
            var response = new Response<Room>();
            var room = await RoomRepository.GetById(idRoom);
            if (room != null)
            {
                await RoomRepository.Delete(room);
                response.StatusCode = 200;
                response.StatusDescripton = "Room Was Deleted Sucessfully";
                response.ResponseObject = Mapper.Map<Room>(room);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Room Not Found ID Room: " + idRoom.ToString();
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the delete process", exception);
            var response = new Response<Room>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the delete process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<List<Room>>> GetAll()
    {
        try
        {
            var response = new Response<List<Room>>();
            var listRooms = await RoomRepository.All();
            if (listRooms.Any())
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<List<RoomDTO>, List<Room>>(listRooms.ToList());
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "There Aren't Rooms";
                response.ResponseObject = Mapper.Map<List<RoomDTO>, List<Room>>(listRooms.ToList());
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the get all process", exception);
            var response = new Response<List<Room>>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get all process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Room>> GetByID(Guid idRoom)
    {
        try
        {
            var response = new Response<Room>();
            var room = await RoomRepository.GetById(idRoom);
            if (room != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<Room>(room);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Room Not Found ID Room: " + idRoom.ToString();
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the get by id process", exception);
            var response = new Response<Room>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get by id process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Room>> GetByName(string name)
    {
        try
        {
            var response = new Response<Room>();
            var room = await RoomRepository.GetByName(name);
            if (room != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<Room>(room);
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
            var response = new Response<Room>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get by name process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Room>> AddRoom(Room room)
    {
        try
        {
            var response = new Response<Room>();
            var office = await OfficeRepository.GetById(room.IdOffice);
            if (office != null)
            {
                var result = await RoomRepository.Add(Mapper.Map<RoomDTO>(room));
                if (result)
                {
                    response.StatusCode = 200;
                    response.StatusDescripton = "Room Was Added Sucessfully";
                    response.ResponseObject = room;
                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusDescripton = "An Error Occurred In The Saved Process";
                    response.ResponseObject = room;
                }
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Office Not Found";
                response.ResponseObject = Mapper.Map<Room>(room);
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the add process", exception);
            var response = new Response<Room>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the add process, please contact the system administrator for more information."
            };
            return response;
        }
    }
    public async Task<Response<Room>> UpdateRoom(Room room)
    {
        try
        {
            var response = new Response<Room>();
            var roomResult = await RoomRepository.GetById(room.IdRoom);
            if (roomResult != null)
            {
                var office = await OfficeRepository.GetById(room.IdOffice);
                if (office != null)
                {
                    var result = await RoomRepository.Upsert(Mapper.Map<RoomDTO>(roomResult));
                    response.StatusCode = 200;
                    response.StatusDescripton = "Room Was Updated Sucessfully";
                    response.ResponseObject = Mapper.Map<Room>(result);
                }
                else
                {
                    response.StatusCode = 404;
                    response.StatusDescripton = "Room Not Found";
                    response.ResponseObject = Mapper.Map<Room>(room);
                }
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Office Not Found";
                response.ResponseObject = Mapper.Map<Room>(room);
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the update process", exception);
            var response = new Response<Room>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the update process, please contact the system administrator for more information."
            };
            return response;
        }
    }
}