using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.Model.Product
{
    public class ProductDeleteVM
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

    }
}
