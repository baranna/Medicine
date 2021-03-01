using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medicine.Dto;
using Medicine.Paging;

namespace Medicine.Services
{
    public interface IProductService
    {
        Task<PageResponse<ProductDto>> ListProductsAsync(FilterProductDto filter, PageRequest pageRequest);
    }
}
