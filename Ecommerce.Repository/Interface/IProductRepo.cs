using ECommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Interface
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        int AddProduct(Product product);

        bool UpdateProduct(Product product);

        bool DeleteProduct(Product product);
        IEnumerable<Product> GetAllProducts(Product product);
    }
}

