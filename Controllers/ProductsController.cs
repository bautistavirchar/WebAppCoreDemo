using Microsoft.AspNetCore.Mvc;
using WebAppCoreDemo.Models.ProductModels;

namespace WebAppCoreDemo
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ProductModels productModels)
        {
            if(!ModelState.IsValid)
            {
                foreach(var err in ModelState.Values){
                    foreach(var error in err.Errors){
                        ModelState.AddModelError(string.Empty, error.ErrorMessage);
                    }
                }
                return RedirectToAction(nameof(Index), productModels);
            }

            //save code..
            return Json(new{
                name = productModels.Name,
                statusId = productModels.Status
            });
            // return RedirectToAction(nameof(Index));
        }
    }
}