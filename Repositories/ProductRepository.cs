using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext _context;
        public ProductRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Product toDelete = await GetProduct(id);
            _context.Products.Remove(toDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int productId)
        {
            Product findResult = await _context.Products.FindAsync(productId);
            if(findResult == null){
                throw new NullReferenceException();
            }
            return findResult;
        }

        public async Task Update(Product product)
        {
            Product toUpdate = await GetProduct(product.ProductId);
            toUpdate.Name = product.Name;
            toUpdate.Price = product.Price;
            _context.Products.Update(toUpdate);
            await _context.SaveChangesAsync();
        }
    }
}