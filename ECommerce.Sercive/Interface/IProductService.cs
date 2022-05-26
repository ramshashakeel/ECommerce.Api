using ECommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Sercive.Interface
{
    public interface IProductService
    {
        #region Public Methods
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetAllProducts(Product productVM);
        Product GetProduct(int id);
        int AddProduct(Product product);
        bool UpdateProduct(Product product);

        bool DeleteProduct(Product product);
        #endregion

    }
}
