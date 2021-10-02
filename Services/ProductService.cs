using Medicine.Dto;
using Medicine.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medicine.Entity;
using Medicine.Extensions;
using Microsoft.EntityFrameworkCore;

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

        public async Task<SideEffectDetailsDto> ListProductsForSideEffectAsync(int sideEffectId, PageRequest pageRequest)
        {
            var sideEffect = await _dbContext
                .SideEffects
                .SingleAsync(se => se.Id == sideEffectId);

            var result = new SideEffectDetailsDto
            {
                Id = sideEffectId,
                Name = sideEffect.Name
            };

            var activeIngredientIds = await _dbContext
                .SideEffectFrequencies
                .Where(se => se.SideEffect.Id == sideEffectId)
                .Select(se => se.ActiveIngredient.Id)
                .ToListAsync();

            result.Products = await _dbContext
                .ProductActiveIngredients
                .Where(pai => activeIngredientIds.Contains(pai.ActiveIngredientId))
                .Select(pai => pai.Product)
                .OrderBy(p => p.Name)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToPagedListAsync(pageRequest);

            return result;
        }

        public async Task<PageResponse<ProductDto>> ListProductsAsync(FilterProductDto filter, PageRequest pageRequest)
        {
            return await _dbContext
                .Products
                .Where(!string.IsNullOrEmpty(filter.Name), p => p.Name.ToLower().Contains(filter.Name.ToLower()))
                .Where(!string.IsNullOrEmpty(filter.ActiveIngredient), p => p.ActiveIngredient.ToLower().Contains(filter.ActiveIngredient.ToLower()))
                .OrderBy(p => p.Name)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToPagedListAsync(pageRequest);
        }

        public async Task<List<ProductSideEffectDto>> ListSideEffectsAsync(int productId)
        {
            var product = await _dbContext
                .Products
                .SingleAsync(p => p.Id == productId);

            return await _dbContext
                .SideEffectFrequencies
                .Where(se => product.ActiveIngredient.Contains(se.ActiveIngredient.Name))
                .ProjectTo<ProductSideEffectDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PageResponse<SideEffectDto>> ListSideEffectsAsync(FilterSideEffectDto filter, PageRequest pageRequest)
        {
            var effects = await _dbContext
                .SideEffects
                .Where(!string.IsNullOrEmpty(filter.Name), p => p.Name.ToLower().Contains(filter.Name.ToLower()))
                .OrderBy(p => p.Name)
                .ProjectTo<SideEffectDto>(_mapper.ConfigurationProvider)
                .ToPagedListAsync(pageRequest);

            foreach (var effect in effects.Result)
            {
                effect.ActiveIngredientCount = await _dbContext
                    .SideEffectFrequencies
                    .Where(se => se.SideEffect.Id == effect.Id)
                    .CountAsync();
            }


            return effects;
        }
    }
}
