using ECommerce.Model;
using ECommerce.Repository.Interface;
using ECommerce.Sercive.Interface;

namespace ECommerce.Sercive
{
    public class ProductService : IProductService
    {
        #region Properties
        private readonly IProductRepo ProductRepository;
        #endregion

        #region Constractor
        public ProductService(IProductRepo productRepository)
        {
            this.ProductRepository = productRepository;
        }
        #endregion


        #region Public Methods
        public IEnumerable<Product> GetProducts()
        {
            return this.ProductRepository.GetProducts();

        }
        public IEnumerable<Product> GetAllProducts(Product product)
        {
            return this.ProductRepository.GetAllProducts(product);

        }

        public Product GetProduct(int id)
        {
            return this.ProductRepository.GetProduct(id);
        }

        public int AddProduct(Product product)
        {
            return this.ProductRepository.AddProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return this.ProductRepository.UpdateProduct(product);
        }
        public bool DeleteProduct(Product product)
        {
            return this.ProductRepository.DeleteProduct(product);
        }
        #endregion


    }
}