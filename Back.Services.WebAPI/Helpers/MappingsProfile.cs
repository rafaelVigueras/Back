using AutoMapper;
using Back.Application.DTO;
using Back.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Services.WebAPI.Helpers
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<SystemUser, SystemUserDTO>().ReverseMap();
        }
    }
}
