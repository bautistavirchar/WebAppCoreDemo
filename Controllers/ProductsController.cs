using Microsoft.AspNetCore.Mvc;
using WebAppCoreDemo.Helpers;
using WebAppCoreDemo.Models.ProductModel;
using WebAppCoreDemo.Models.Repositories;

namespace WebAppCoreDemo
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetProducts()
        {
            var repo = new RepoProducts();
            var products = repo.GetProductModels();

            return Json(new{
                productResult = products
            });
        }

        public IActionResult ViewProducts()
        {
            var repo = new RepoProducts();
            var products = repo.GetProductModels();
            return View(products);
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
            var repo = new RepoProducts();
            string message = string.Empty;
            bool result = repo.SaveProduct(productModels, out message);
            if(!result){
                TempData["ErrorResult"] = message;
                return RedirectToAction(nameof(Index), productModels);
            }
            TempData["Result"] = message;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Update(ProductModels productModels)
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
            var repo = new RepoProducts();
            string message = string.Empty;
            bool result = repo.UpdateProduct(productModels, out message);
            if(!result){
                TempData["ErrorResult"] = message;
                return RedirectToAction(nameof(Edit), productModels );
            }
            TempData["Result"] = message;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string key)
        {
            var repo = new RepoProducts();
            string message = string.Empty;
            int id = key.ConvertToNumber();
            bool result = repo.DeleteProduct(id, out message);
            if(!result){
                return Content(message);
            }
            TempData["Result"] = message;
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Edit(string key)
        {
            var repo = new RepoProducts();
            int id = key.ConvertToNumber();
            var product = repo.GetProduct(id);
            if(product == null){
                return Content("This product is not found!");
            }
            return View(product);
        }
    }
}