using AutoMapper;
using Domain.Entity.Auth;
using Domain.Entity.Miscellaneous;
using Shared.DTOs;

namespace Domain.MappingProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<ExceptionLog, ExceptionLogDto>().ReverseMap();
        }
    }
}
