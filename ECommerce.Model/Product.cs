using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Model
{
    public class Product
    {
        #region Fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public bool Active { get; set; }
        #endregion
    }
}