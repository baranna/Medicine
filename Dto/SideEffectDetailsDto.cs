using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medicine.Paging;

namespace Medicine.Dto
{
    public class SideEffectDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PageResponse<ProductDto> Products { get; set; }
    }
}
