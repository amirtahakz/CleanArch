using CleanArch.Domain.OrderAgg;
using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.Shared;

namespace CleanArch.Infrastructure.Persistent.Memory;

public class Context
{
    public List<Product> Products { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>() { new Order(Guid.NewGuid()) };
}