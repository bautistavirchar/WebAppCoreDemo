using System.ComponentModel.DataAnnotations;

namespace WebAppCoreDemo.Models.ProductModel
{
    public class ProductModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Status { get; set; }
    }

    public class ProductViewModels
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}