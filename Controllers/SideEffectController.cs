using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medicine.Dto;
using Medicine.Paging;
using Medicine.Services;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SideEffectController : ControllerBase
    {
        private readonly IProductService _productService;

        public SideEffectController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public Task<PageResponse<SideEffectDto>> ListSideEffects([FromQuery] FilterSideEffectDto filter, [FromQuery] PageRequest pageRequest)
            => _productService.ListSideEffectsAsync(filter, pageRequest);

        [HttpGet("product/{productId}")]
        public Task<List<ProductSideEffectDto>> ListSideEffectsForProduct(int productId)
            => _productService.ListSideEffectsAsync(productId);

        [HttpGet("{sideEffectId}")]
        public Task<SideEffectDetailsDto> ListProductsForSideEffect(int sideEffectId, [FromQuery] PageRequest pageRequest)
            => _productService.ListProductsForSideEffectAsync(sideEffectId, pageRequest);
    }
}