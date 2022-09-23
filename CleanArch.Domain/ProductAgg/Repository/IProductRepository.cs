using CleanArch.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.ProductAgg.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Task<Product> GetById(Guid id);
        void Add(Product order);
        Task Update(Product order);
        void Remove(Product order);
        Task SaveChanges();
        bool IsProductService(Guid id);
    }
}
