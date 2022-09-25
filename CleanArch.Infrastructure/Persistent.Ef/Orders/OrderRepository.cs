using CleanArch.Domain.OrderAgg.Repository;
using CleanArch.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistent.Ef.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Add(order);
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _context.Orders.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Order order)
        {
            _context.Update(order);
        }
    }
}
