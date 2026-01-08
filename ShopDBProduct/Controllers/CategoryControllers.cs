using Microsoft.AspNetCore.Mvc;
using ShopDBProduct.Controllers.Base;
using ShopDBProduct.DTOs.Categories;
using ShopDBProduct.Services.Interfaces;

namespace ShopDBProduct.Controllers
{
   
    [Route("api/v1/categories")]
    public class CategoryControllers : BaseApiController
    {
        private readonly ILogger<CategoryControllers> _logger;
        private readonly ICategoryService _service;
        public CategoryControllers(ILogger<CategoryControllers> logger, ICategoryService service)
        {
            _logger = logger;
            _service = service;
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
            try
            {
                var category = await _service.GetDetailByIdAsync(id);
                return Ok(category);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { message = "Đã xảy ra lỗi từ hệ thống" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var category = await _service.CreateAsync(dto);
            return Ok(category);
        }

    }
}
