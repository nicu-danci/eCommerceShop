using System.ComponentModel.DataAnnotations;

namespace eCommerceShop.Models
{
    public class ProductTypes
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Product type")]

        public string ProductType { get; set; }
    }
}
