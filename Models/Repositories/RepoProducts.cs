using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAppCoreDemo.Data;
using WebAppCoreDemo.Models.ProductModel;

namespace WebAppCoreDemo.Models.Repositories
{
    public class RepoProducts
    {
        public bool SaveProduct(ProductModels model, out string message){
            message = string.Empty;
            using(var db = new DbDemoContext()){
                if(!db.Status.Where(x => x.Id == model.Status).Any()){
                    message = "Opss!? something went wrong!";
                    return false;
                }
                if(db.Products.Where(x => x.Name == model.Name).Any()){
                    message = "Opss!? this product is already exists!";
                    return false;
                }

                var newProduct = new Products
                {
                    Name = model.Name,
                    Status = model.Status
                };
                db.Entry(newProduct).State = EntityState.Added;
                bool status = db.SaveChanges() > 0;
                message = status ? "Successfully added!" : "Save failed!";
                return status;
            }
        }

        public bool UpdateProduct(ProductModels model, out string message){
            message = string.Empty;
            using(var db = new DbDemoContext()){
                if(!db.Status.Where(x => x.Id == model.Status).Any()){
                    message = "Opss!? something went wrong!";
                    return false;
                }
                if(db.Products.Where(x => x.Id != model.Id && x.Name == model.Name).Any()){
                    message = "Opss!? this product is already exists!";
                    return false;
                }

                if(!db.Products.Where(x => x.Id == model.Id).Any())
                {
                    message = "Opss!? this product is not exists!";
                    return false;
                }

                var prod = db.Products.Find(model.Id);
                prod.Name = model.Name;
                prod.Status = model.Status;

                db.Entry(prod).State = EntityState.Modified;
                bool status = db.SaveChanges() > 0;
                message = status ? "Successfully updated!" : "Update failed!";
                return status;
            }
        }

        public bool DeleteProduct(int id, out string message){
            message = string.Empty;
            using(var db = new DbDemoContext()){

                if(!db.Products.Where(x => x.Id ==id).Any())
                {
                    message = "Opss!? this product is not exists!";
                    return false;
                }

                var prod = db.Products.Find(id);
                db.Entry(prod).State = EntityState.Deleted;
                bool status = db.SaveChanges() > 0;
                message = status ? "Successfully deleted!" : "Delete failed!";
                return status;
            }
        }

        public ProductModels GetProduct(int id)
        {
            using(var db = new DbDemoContext())
            {
                if(!db.Products.Where(x => x.Id == id).Any()){
                    return null;
                }

                var row = db.Products.Find(id);
                return new ProductModels
                {
                    Id = row.Id,
                    Name = row.Name,
                    Status = row.Status
                };
            }
        }

        public List<ProductViewModels> GetProductModels()
        {
            using(var db = new DbDemoContext()){
                var rows = from p in db.Products
                            join s in db.Status on p.Status equals s.Id into gpProducts
                            from pro in gpProducts.DefaultIfEmpty()
                            
                            select new
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Status = pro.Name
                            };
                var result = new List<ProductViewModels>();
                foreach(var prod in rows){
                    result.Add(new ProductViewModels{
                        Key = prod.Id.ToString(),
                        Name = prod.Name,
                        Status = prod.Status
                    });
                }
                return result;
            }
        }
    }
}