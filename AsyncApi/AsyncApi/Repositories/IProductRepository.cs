using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncApi.Models;

namespace AsyncApi.Repositories
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<Product> GetProduct(long prodId);
        Task<IEnumerable<Product>> GetProducts();
        Task DeleteProduct(long prodId);
        Task UpdateProduct(Product product);
    }
}
