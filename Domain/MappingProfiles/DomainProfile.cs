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
            //CreateMap<Application, ApplicationDto>().ReverseMap();
            CreateMap<Application, IntApplicationDto>().ReverseMap();
            CreateMap<User, IntUserDto>().ReverseMap();
            CreateMap<Customer, IntCustomerDto>().ReverseMap();

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles))
                .ForMember(dest => dest.UserCustomers, opt => opt.MapFrom(src => src.UserCustomers))
                .ReverseMap();

            CreateMap<Customer, CustomerDto>()
             .ForMember(dest => dest.UserCustomers, opt => opt.MapFrom(src => src.UserCustomers))
             .ForMember(dest => dest.CustomerApplications, opt => opt.MapFrom(src => src.CustomerApplications))
             .ReverseMap();

            CreateMap<UserCustomer, UserCustomerDto>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<UserRole, UserRoleDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<CustomerApplication, CustomerApplicationDto>()
               .ForMember(dest => dest.Application, opt => opt.MapFrom(src => src.Application))
               .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
               .ReverseMap();

            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles))
                .ReverseMap();

            CreateMap<Application, ApplicationDto>()
                .ForMember(dest => dest.CustomerApplications, opt => opt.MapFrom(src => src.CustomerApplications))
                .ReverseMap();
        }
    }
}