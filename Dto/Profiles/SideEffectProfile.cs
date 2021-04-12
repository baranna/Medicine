using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Medicine.Entity;

namespace Medicine.Dto.Profiles
{
    public class SideEffectProfile : Profile
    {
        public SideEffectProfile()
        {
            CreateMap<SideEffect, SideEffectDto>()
                .ForMember(d => d.ActiveIngredientCount, opt => opt.Ignore());
            CreateMap<SideEffect, SideEffectDetailsDto>()
                .ForMember(d => d.Products, opt => opt.Ignore());
        }
    }
}
