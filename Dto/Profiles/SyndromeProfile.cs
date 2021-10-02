using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Medicine.Dto.Disease;
using Medicine.Entity;

namespace Medicine.Dto.Profiles
{
    public class SyndromeProfile : Profile
    {
        public SyndromeProfile()
        {
            CreateMap<Syndrome, SyndromeDto>();
        }
    }
}
