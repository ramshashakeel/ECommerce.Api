using ECommerce.Api.Model.Product;
using ECommerce.Model;
using ECommerce.Sercive.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService ProductService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            ProductService = productService;
            _logger = logger;
        }

        #region Public Methods

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            _logger.LogInformation("ProductController GetProducts executing...");
            return this.ProductService.GetProducts();
        }

        
        [HttpGet(Name = "GetAllProducts")]
        public IEnumerable<ProductGetAllResponseVM> GetAllProducts([FromQuery] ProductGetAllVM productVM)
        {
            var product = new Product
            {
                CategoryId = productVM.CategoryId,
                ProductName = productVM.ProductName,
                Active = productVM.Active
            };
            var result = this.ProductService.GetAllProducts(product);

            var resultVM = new List<ProductGetAllResponseVM>();
            if (result != null)
            {
                foreach (var prod in result)
                {
                    resultVM.Add(new ProductGetAllResponseVM
                    {
                        ProductId = prod.ProductId,
                        ProductName = prod.ProductName,
                        ProductDescription = prod.ProductDescription,
                        SalesPrice = prod.SalesPrice,
                        Active = prod.Active
                    });
                }
            }

            return resultVM;
        }


        [HttpGet(Name = "GetProduct/{id}")]
        public Product GetProduct(int id)
        {
            return this.ProductService.GetProduct(id);
        }


        [HttpPost(Name = "AddProduct")]
        public int AddProduct([FromBody] ProductAddVM productVM)
        {
            var product = new Product
            {
                CategoryId = productVM.CategoryId,
                ProductName = productVM.ProductName,
                ProductDescription = productVM.ProductDescription,
                SalesPrice = productVM.SalesPrice,
                PurchasePrice = productVM.PurchasePrice,
                Active = productVM.Active
            };
            return this.ProductService.AddProduct(product);
        }


        [HttpPut(Name = "UpdateProduct")]
        public bool UpdateProduct([FromBody] ProductUpdateVM productVM)
        {
            var product = new Product
            {
                ProductId = productVM.ProductId,
                CategoryId = productVM.CategoryId,
                ProductName = productVM.ProductName,
                ProductDescription = productVM.ProductDescription,
                SalesPrice = productVM.SalesPrice,
                PurchasePrice = productVM.PurchasePrice,
                Active = productVM.Active
            };

            return this.ProductService.UpdateProduct(product);
        }


        [HttpDelete(Name = "DeleteProduct")]
        public bool DeleteProduct(ProductDeleteVM productVM)
        {
            var product = new Product
            {
                ProductId = productVM.ProductId
            };

            return this.ProductService.DeleteProduct(product);
        }
        #endregion
    }
}
