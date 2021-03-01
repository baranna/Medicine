using Medicine.Dto;
using Medicine.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Services
{
    public class ProductService : IProductService
    {
        public Task<PageResponse<ProductDto>> ListProductsAsync(FilterProductDto filter, PageRequest pageRequest)
        {
            throw new NotImplementedException();
        }
    }
}
