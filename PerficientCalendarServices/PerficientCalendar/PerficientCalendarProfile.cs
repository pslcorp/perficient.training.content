using AutoMapper;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Model;

namespace PerficientCalendar;

public class PerficientCalendarProfile : Profile
{
    public PerficientCalendarProfile()
    {
        CreateMap<OfficeDTO, Office>().ReverseMap();
        CreateMap<TypeEventDTO, TypeEvent>().ReverseMap();
        CreateMap<RoomDTO, Room>().ReverseMap();
        CreateMap<DeveloperDTO, Developer>().ReverseMap();
        CreateMap<MeetingDTO, Meeting>().ReverseMap();
        CreateMap<InvitationDTO, Invitation>().ReverseMap();
    }
}