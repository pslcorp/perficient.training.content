using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;
using PerficientCalendar.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace PerficientCalendar.Business;

public class OperationDeveloper : IOperationDeveloper
{
    private readonly ILogger<IOperationDeveloper> Logger;
    private readonly IDeveloperRepository DeveloperRepository;
    private readonly IOfficeRepository OfficeRepository;
    private readonly IMapper Mapper;
    public OperationDeveloper(IDeveloperRepository developerRepository, ILogger<IOperationDeveloper> logger,
                              IMapper mapper, IOfficeRepository officeRepository)
    {
        DeveloperRepository = developerRepository;
        Mapper = mapper;
        OfficeRepository = officeRepository;
        Logger = logger;
    }

    public async Task<Response<Developer>> Delete(Guid idDeveloper)
    {
        try
        {
            var response = new Response<Developer>();
            var developer = await DeveloperRepository.GetById(idDeveloper);
            if (developer != null)
            {
                await DeveloperRepository.Delete(developer);
                response.StatusCode = 200;
                response.StatusDescripton = "Developer Was Deleted Sucessfully";
                response.ResponseObject = Mapper.Map<Developer>(developer);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Developer Not Found ID Developer" + idDeveloper.ToString();
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the delete process", exception);
            var response = new Response<Developer>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the delete process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<List<Developer>>> GetAll()
    {
        try
        {
            var response = new Response<List<Developer>>();
            var listDevelopers = await DeveloperRepository.All();
            if (listDevelopers.Any())
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<List<DeveloperDTO>, List<Developer>>(listDevelopers.ToList());
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "There Aren't Developers";
                response.ResponseObject = Mapper.Map<List<DeveloperDTO>, List<Developer>>(listDevelopers.ToList());
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the Get All process", exception);
            var response = new Response<List<Developer>>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the Get All process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Developer>> GetByID(Guid idDeveloper)
    {
        try
        {
            var response = new Response<Developer>();
            var developer = await DeveloperRepository.GetById(idDeveloper);
            if (developer != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<Developer>(developer);
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Invitation Not Found ID developer: " + idDeveloper.ToString();
            }

            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the Get By ID process", exception);
            var response = new Response<Developer>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the Get By ID process, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<List<Developer>>> GetByIdentifier(string identifier)
    {
        try
        {
            var response = new Response<List<Developer>>();

            var listDevelopers = await DeveloperRepository.GetByIdentifier(identifier);
            if (listDevelopers.Any())
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<List<DeveloperDTO>, List<Developer>>(listDevelopers.ToList());
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Invitation Not Found Identifier: " + identifier;
                response.ResponseObject = Mapper.Map<List<DeveloperDTO>, List<Developer>>(listDevelopers.ToList());
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the Get By Identifier process", exception);
            var response = new Response<List<Developer>>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the Get By Identifier, please contact the system administrator for more information."
            };
            return response;
        }
    }

    public async Task<Response<Developer>> GetByName(string name)
    {
        try
        {
            var response = new Response<Developer>();
            var developer = await DeveloperRepository.GetByName(name);
            if (developer != null)
            {
                response.StatusCode = 200;
                response.StatusDescripton = "The Query Was Executed Sucessfully";
                response.ResponseObject = Mapper.Map<Developer>(developer);
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
            Logger.LogError("An error occurred during the Get by Name process", exception);
            var response = new Response<Developer>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the Get by Name process, please contact the system administrator for more information."
            };
            return response;
        }
    }
    public async Task<Response<Developer>> AddDeveloper(Developer developer)
    {
        try
        {
            var response = new Response<Developer>();

            var office = await OfficeRepository.GetById(developer.IdOffice);
            if (office != null)
            {
                var result = await DeveloperRepository.Add(Mapper.Map<DeveloperDTO>(developer));
                if (result)
                {
                    response.StatusCode = 200;
                    response.StatusDescripton = "Office Was Added Sucessfully";
                    response.ResponseObject = Mapper.Map<Developer>(developer);
                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusDescripton = "An Error Occurred In The Saved Process";
                    response.ResponseObject = Mapper.Map<Developer>(developer);
                }
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Office Not Found ";
                response.ResponseObject = Mapper.Map<Developer>(developer);
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the Add process", exception);
            var response = new Response<Developer>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the Add process, please contact the system administrator for more information."
            };
            return response;
        }
    }
    public async Task<Response<Developer>> UpdateDeveloper(Developer developer)
    {
        try
        {
            var response = new Response<Developer>();
            var developerResult = await DeveloperRepository.GetById(developer.IdDeveloper);
            if (developerResult != null)
            {
                var office = await OfficeRepository.GetById(developer.IdOffice);
                if (office != null)
                {
                    var result = await DeveloperRepository.Upsert(Mapper.Map<DeveloperDTO>(developer));
                    response.StatusCode = 200;
                    response.StatusDescripton = "Developer Was Updated Sucessfully";
                    response.ResponseObject = Mapper.Map<Developer>(result);
                }
                else
                {
                    response.StatusCode = 404;
                    response.StatusDescripton = "Office Not Found";
                    response.ResponseObject = Mapper.Map<Developer>(developer);
                }
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescripton = "Developer Not Found";
                response.ResponseObject = Mapper.Map<Developer>(developer);
            }
            return response;
        }
        catch (Exception exception)
        {
            Logger.LogError("An error occurred during the Update process", exception);
            var response = new Response<Developer>
            {
                StatusCode = 500,
                StatusDescripton = "An error occurred during the Update process, please contact the system administrator for more information."
            };
            return response;
        }
    }
}