using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ShopDBProduct.Controllers.Base;
using ShopDBProduct.DTOs.Categories;
using ShopDBProduct.DTOs.Products;
using ShopDBProduct.Services.Interfaces;

namespace ShopDBProduct.Controllers
{

    [Route("api/v1/categories")]
    public class CategoryControllers : BaseApiController
    {
        private readonly ILogger<CategoryControllers> _logger;
        private readonly IValidator<CreateCategoryDto> _productValidator;
        private readonly ICategoryService _service;
        public CategoryControllers(ILogger<CategoryControllers> logger, ICategoryService service, IValidator<CreateCategoryDto> productValidator)
        {
            _logger = logger;
            _service = service;
            _productValidator = productValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {

            var category = await _service.GetDetailByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            var result = await _productValidator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var category = await _service.CreateAsync(dto);
            return Ok(category);
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> Create(int id, [FromBody] UpdateCategoryDto dto)
        {
            var category = await _service.UpdateByIdAsync(id, dto);
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _service.DeleteAsync(id);
            return Ok(res);
        }

    }
}
