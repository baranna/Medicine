using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Medicine.Entity;

namespace Medicine.Dto
{
    public class ProductSideEffectProfile : Profile
    {
        public ProductSideEffectProfile()
        {
            CreateMap<SideEffectFrequency, ProductSideEffectDto>();
        }
    }
}
