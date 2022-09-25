using CleanArch.Domain.ProductAgg.Repository;
using CleanArch.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistent.Ef.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Add(product);
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(f => f.Id == id);
        }

        public bool IsProductExist(Guid id)
        {
            return _context.Products.Any(f => f.Id == id);
        }

        public void Remove(Product product)
        {
            _context.Remove(product);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }
    }
}
