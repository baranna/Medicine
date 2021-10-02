using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Medicine.Entity;

namespace Medicine.Dto.Profiles
{
    public class SymptomProfile : Profile
    {
        public SymptomProfile()
        {
            CreateMap<Symptom, SymptomDto>();
        }
    }
}
