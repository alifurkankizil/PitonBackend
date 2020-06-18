using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Api.Models.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Work
            CreateMap<WorkDTO, Work>();
            CreateMap<Work, WorkDTO>();
        }
    }
}
