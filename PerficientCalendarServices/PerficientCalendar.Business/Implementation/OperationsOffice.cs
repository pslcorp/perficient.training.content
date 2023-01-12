using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Model;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business;

public class OperationsOffice : IOperationsOffice
{
    private readonly ILogger<IOperationsOffice> Logger;
    private readonly IWeatherStackService Service;
    private readonly IOfficeRepository OfficeRepository;
    private readonly IMapper Mapper;
    public OperationsOffice(IWeatherStackService service, ILogger<IOperationsOffice> logger,
                            IOfficeRepository officeRepository, IMapper mapper)
    {
        Service = service;
        OfficeRepository = officeRepository;
        Mapper = mapper;
        Logger = logger;
    }

    public async Task<Response<Office>> Delete(Guid idOffice)
    {
        try
        {
            var response = new Response<Office>();
            var office = await OfficeRepository.GetById(idOffice);
            if (office != null)
            {
                await OfficeRepository.Delete(office);
                response.StatusCode = 200;
                response.StatusDescripton = "Office Was Deleted Sucessfully";
                response.ResponseObject = Mapper.Map<Office>(office);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Office Not Found ID Developer" + idOffice.ToString();
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the delete process", exception);
            var response = new Response<Office>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the delete process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<List<Office>>> GetAll()
    {
        try
        {
            var response = new Response<List<Office>>();
            var listDevelopers = await OfficeRepository.All();
            if (listDevelopers.Any())
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<List<OfficeDTO>, List<Office>>(listDevelopers.ToList());
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "There Aren't Developers";
                response.ResponseObject = Mapper.Map<List<OfficeDTO>, List<Office>>(listDevelopers.ToList());
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the get all process", exception);
            var response = new Response<List<Office>>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get all process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Office>> GetByID(Guid idOffice)
    {
        try
        {
            var response = new Response<Office>();
            var office = await OfficeRepository.GetById(idOffice);
            if (office != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<Office>(office);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Invitation Not Found ID Invitation: " + idOffice.ToString();
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the get by id process", exception);
            var response = new Response<Office>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get by id process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Office>> GetByName(string name)
    {
        try
        {
            var response = new Response<Office>();
            var office = await OfficeRepository.GetByName(name);
            if (office != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<Office>(office);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Invitation Not Found Name: " + name;
            }

            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the get by name process", exception);
            var response = new Response<Office>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the get by name process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Office>> AddOffice(Office office)
    {
        try
        {
            var response = new Response<Office>();
            var WeatherStackResponse = await Service.GetInfoCity(office.City);
            office.Latitude = WeatherStackResponse.Location.Latitude;
            office.Longitude = WeatherStackResponse.Location.Longitude;
            var result = await OfficeRepository.Add(Mapper.Map<OfficeDTO>(office));
            if (result)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "Office Was Added Sucessfully";
                response.ResponseObject = office;
            }
            else
            {
                response.StatusCode = 400;
                response.StatusDescripton = "An Error Occurred In The Saved Process";
                response.ResponseObject = office;
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the add process", exception);
            var response = new Response<Office>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the add process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Office>> UpdateOffice(Office office)
    {
        try
        {
            var response = new Response<Office>();
            var officeResult = await OfficeRepository.GetById(office.IdOffice);
            if (officeResult != null)
            {
                if (!officeResult.City.Equals(office.City, StringComparison.CurrentCultureIgnoreCase))
                {
                    var WeatherStackResponse = await Service.GetInfoCity(office.City);
                    office.Latitude = WeatherStackResponse.Location.Latitude;
                    office.Longitude = WeatherStackResponse.Location.Longitude;
                }
                var result = await OfficeRepository.Upsert(Mapper.Map<OfficeDTO>(office));
                response.StatusCode = 200;
                response.StatusDescripton = "Office Was Updated Sucessfully";
                response.ResponseObject = Mapper.Map<Office>(office);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Office Not Found";
                response.ResponseObject = Mapper.Map<Office>(office);
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the update process", exception);
            var response = new Response<Office>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the update process, please contact the system administrator for more information."
            };
            return response;
        }
    }
}