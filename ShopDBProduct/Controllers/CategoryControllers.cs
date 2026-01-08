using Microsoft.AspNetCore.Mvc;

namespace ShopDBProduct.Controllers
{
    public class CategoryControllers : Controller
    {
        public IActionResult Index()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }
    }
}
