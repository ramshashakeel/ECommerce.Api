namespace ECommerce.Api.Model.Product
{
    public class ProductGetAllVM
    {
        #region Properties
        
        public int CategoryId  { get; set; }
        public bool Active { get; set; }
        public string ProductName { get; set; }
        //public Nullable<bool> Active { get; set; }
        //public string? ProductName { get; set; }        
        #endregion
    }
}
