using Microsoft.AspNetCore.Mvc;

namespace JobPracticeEnitity.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
