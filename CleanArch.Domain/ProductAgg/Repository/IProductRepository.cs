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
        Product GetById(Guid id);
        void Add(Product order);
        void Update(Product order);
        void Remove(Product order);
        bool IsProductService(Guid id);
    }
}
