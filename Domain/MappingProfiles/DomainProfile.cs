﻿using AutoMapper;
using Domain.Entity.Auth;
using Domain.Entity.Core;
using Shared.DTOs;

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
