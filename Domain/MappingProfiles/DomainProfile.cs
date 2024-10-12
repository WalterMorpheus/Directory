using AutoMapper;
using Domain.Entity.Auth;
using Shared.DTOs;

namespace Domain.MappingProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
           CreateMap<User,UserDto>();
        }
    }
}
