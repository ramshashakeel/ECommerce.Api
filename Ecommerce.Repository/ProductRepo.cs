using ECommerce.Repository;
using ECommerce.Model;
using ECommerce.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository
{
    public class ProductRepo : IProductRepo
    {
        #region Properties
        //private readonly ILogger<ProductRepository> Logger;
        private readonly ApplicationDbContext ApplicationDbContext;
        private static List<Product> Products = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    ProductName="Dell Laptop",
                    ProductDescription = "Dell Laptop E6410",
                    PurchasePrice = 1000.50m,
                    SalesPrice = 1200.00m,
                    Active = true,
                    CategoryId = 1
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName="HP Laptop",
                    ProductDescription = "HP Laptop E6410",
                    PurchasePrice = 1000.50m,
                    SalesPrice = 1200.00m,
                    Active = false,
                    CategoryId = 1
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName="Lenovo Laptop",
                    ProductDescription = "Lenovo Laptop E6410",
                    PurchasePrice = 1000.50m,
                    SalesPrice = 1200.00m,
                    Active = true,
                    CategoryId = 2
                }
            };
        #endregion

        #region Constructor
        public ProductRepo(ApplicationDbContext ApplicationDbContext)
        {
            this.ApplicationDbContext = ApplicationDbContext;
        }
        #endregion

        #region Public Methods
        public IEnumerable<Product> GetProducts()
        {
            return ApplicationDbContext.Products.ToList();
        }
        
        public Product GetProduct(int id)
        {
            return ApplicationDbContext.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public IEnumerable<Product> GetAllProducts(Product product)
        {
            var products = this.ApplicationDbContext.Products.ToList();

            if (product != null)
            {
                if (product.CategoryId > 0)
                {
                    products = products.Where(x => x.CategoryId == product.CategoryId).ToList();
                }

                if (!string.IsNullOrWhiteSpace(product.ProductName) && !string.IsNullOrEmpty(product.ProductName))
                {
                    products = products.Where(x => x.ProductName == product.ProductName).ToList();
                }

                products = products.Where(p => p.Active == product.Active).ToList();
            }

            return products;
        }

        public int AddProduct(Product product)
        {
            var res = this.ApplicationDbContext.Products.Add(product);

            var result = this.ApplicationDbContext.SaveChanges();

            return res.Entity.ProductId;
        }

        public bool UpdateProduct(Product product)
        {
            var existingProduct = this.ApplicationDbContext.Products.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductDescription = product.ProductDescription;
                existingProduct.PurchasePrice = product.PurchasePrice;
                existingProduct.SalesPrice = product.SalesPrice;
                existingProduct.Active = product.Active;
                existingProduct.CategoryId = product.CategoryId;

                var result = this.ApplicationDbContext.SaveChanges();

                return result > 0;
            }
            else
            {
                return false;
            }
        }


        public bool DeleteProduct(Product product)
        {
            var existingProduct = this.ApplicationDbContext.Products.Remove(product);

            var result = this.ApplicationDbContext.SaveChanges();

            return result > 0;
        }

        #endregion
    }
}
