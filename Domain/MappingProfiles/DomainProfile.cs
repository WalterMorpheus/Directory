using AutoMapper;
using Domain.Entity.Auth;
using Domain.Entity.Core;
using Domain.Entity.Miscellaneous;
using Shared.DTOs;

namespace Domain.MappingProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Application, ApplicationDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<ExceptionLog, ExceptionLogDto>().ReverseMap();
        }
    }
}
