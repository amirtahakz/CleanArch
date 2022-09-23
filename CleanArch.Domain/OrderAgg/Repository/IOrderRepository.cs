using CleanArch.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.OrderAgg.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetById(Guid id);
        void Add(Order order);
        void Update(Order order);
        void SaveChanges();

    }
}
