using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Medicine.Entity;

namespace Medicine.Dto.Profiles
{
    public class DiseaseProfile : Profile
    {
        public DiseaseProfile()
        {
            CreateMap<Entity.Disease, DiseaseDto>();
            CreateMap<Entity.Disease, DiseaseDetailsDto>()
                .ForMember(d => d.Precautions, opt => opt.Ignore());
        }
    }
}
