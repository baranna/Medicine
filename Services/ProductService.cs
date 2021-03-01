using Medicine.Dto;
using Medicine.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medicine.Extensions;

namespace Medicine.Services
{
    public class ProductService : IProductService
    {
        private readonly MedicineDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(MedicineDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PageResponse<ProductDto>> ListProductsAsync(FilterProductDto filter, PageRequest pageRequest)
        {
            return await _dbContext
                .Products
                .Where(!string.IsNullOrEmpty(filter.Name), p => p.Name.ToLower().Contains(filter.Name.ToLower()))
                .Where(!string.IsNullOrEmpty(filter.ActiveIngredient), p => p.ActiveIngredient.ToLower().Contains(filter.ActiveIngredient.ToLower()))
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToPagedListAsync(pageRequest);
        }
    }
}
