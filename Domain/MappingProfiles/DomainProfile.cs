using AutoMapper;
using Domain.DTOs.External;
using Domain.Entity.Auth;
using Domain.Entity.Core;

namespace Domain.MappingProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles))
                .ForMember(dest => dest.UserCustomerApplications, opt => opt.MapFrom(src => src.UserCustomerApplications))
                .ReverseMap();

            CreateMap<Customer, CustomerDto>()
             .ForMember(dest => dest.UserCustomerApplications, opt => opt.MapFrom(src => src.UserCustomerApplications))
             .ReverseMap();

            CreateMap<UserCustomerApplication, UserCustomerApplicationDto>()
                .ForMember(dest => dest.ApplicationId, opt => opt.MapFrom(src => src.Application.Id))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))

                 .ForMember(dest => dest.Application, opt => opt.MapFrom(src => src.Application))
                 .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                 .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))

                .ReverseMap();

            CreateMap<UserRole, UserRoleDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles))
                .ReverseMap();

            CreateMap<Application, ApplicationDto>()
                .ForMember(dest => dest.UserCustomerApplications, opt => opt.MapFrom(src => src.UserCustomerApplications))
                .ReverseMap();
        }
    }
}