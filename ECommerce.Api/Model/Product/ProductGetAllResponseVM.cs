namespace ECommerce.Api.Model.Product
{
    public class ProductGetAllResponseVM
    {
        #region Properties
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal SalesPrice { get; set; }
        public bool Active { get; set; }
        #endregion
    }
}
