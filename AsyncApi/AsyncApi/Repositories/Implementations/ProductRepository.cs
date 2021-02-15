using AsyncApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncApi.Repositories.Implementations
{

    public class ProductRepository : IProductRepository
    {
        private AppDbContext _productContext;
        public ProductRepository(AppDbContext context)
        {
            _productContext = context;
        }

        public async Task DeleteProduct(long prodId)
        {
            Product product = await _productContext.Products.FindAsync(prodId);
            _productContext.Products.Remove(product);
            await _productContext.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(long prodId)
        {
            Product product = await _productContext.Products.FindAsync(prodId);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            IEnumerable<Product> products = await _productContext.Products.ToListAsync();
            return products;
        }

        public async Task UpdateProduct(Product product)
        {
            Product productToUpdate = await _productContext.Products.FindAsync(product.Id);
            if (productToUpdate != null)
            {
                productToUpdate = product;
                await _productContext.SaveChangesAsync();
            }
        }

        public async Task AddProduct(Product product)
        {
            await _productContext.AddAsync(product);
            await _productContext.SaveChangesAsync();

        }
    }
}
