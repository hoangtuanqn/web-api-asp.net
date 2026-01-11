using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ShopDBProduct.Controllers.Base;
using ShopDBProduct.DTOs.Products;
using ShopDBProduct.Services.Interfaces;
using ShopDBProduct.Validators.Products;

namespace ShopDBProduct.Controllers
{
    [Route("api/v1/products")]
    public class ProductControllers : BaseApiController
    {
        private readonly ILogger<ProductControllers> _logger;
        private readonly IProductService _service;
        private readonly IValidator<CreateProductDto> _productValidator;
        public ProductControllers(ILogger<ProductControllers> logger, IProductService service, IValidator<CreateProductDto> productValidator)
        {
            _logger = logger;
            _service = service;
            _productValidator = productValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetDetailByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var result = await _productValidator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var product = await _service.CreateAsync(dto);
            return Ok(product);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            var product = await _service.UpdateByIdAsync(id, dto);
            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }
    }
}
