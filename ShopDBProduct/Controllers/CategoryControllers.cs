using Microsoft.AspNetCore.Mvc;

namespace ShopDBProduct.Controllers
{
    public class CategoryControllers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
