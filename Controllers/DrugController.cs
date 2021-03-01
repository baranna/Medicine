using Microsoft.AspNetCore.Http;
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
    public class DrugController : ControllerBase
    {
        private readonly IProductService _productService;

        public DrugController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public Task<PageResponse<ProductDto>> ListProducts([FromQuery] FilterProductDto filter, [FromQuery] PageRequest pageRequest)
            => _productService.ListProductsAsync(filter, pageRequest);
    }
}
