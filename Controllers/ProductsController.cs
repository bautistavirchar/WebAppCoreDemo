using Microsoft.AspNetCore.Mvc;

namespace WebAppCoreDemo
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}