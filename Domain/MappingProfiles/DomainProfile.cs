using AutoMapper;
using Data.Entity.Auth;
using Data.Entity.Core;
using Domain.DTOs;

namespace Domain.MappingProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Application, ApplicationDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
