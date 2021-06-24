using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public interface IProductRepository
    {
         Task<Product> GetProduct(int productId);
         Task<IEnumerable<Product>> GetAllProducts();
         Task Add(Product product);
         Task Delete(int id);
         Task Update(Product product);
    }
}