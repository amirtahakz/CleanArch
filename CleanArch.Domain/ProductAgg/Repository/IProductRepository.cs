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
        Task<Product> GetById(Guid id);
        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);
        Task SaveChanges();
        bool IsProductExist(Guid id);
    }
}
