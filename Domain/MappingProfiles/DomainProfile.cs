using AutoMapper;
using Domain.DTOs.External;
using Domain.DTOs.Interanal;
using Domain.Entity.Auth;
using Domain.Entity.Core;

namespace Domain.MappingProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Application, ApplicationDto>().ReverseMap();
            CreateMap<Application, IntApplicationDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, IntUserDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, IntCustomerDto>().ReverseMap();
            CreateMap<CustomerApplication, CustomerApplicationDto>().ReverseMap();
            CreateMap<UserCustomer, UserCustomerDto>().ReverseMap();
        }
    }
}