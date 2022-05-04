
using CleanArch.Domain.OrderAgg;
using CleanArch.Domain.OrderAgg.Repository;

namespace CleanArch.Infrastructure.Persistent.Memory.Orders;

public class OrderRepository : IOrderRepository
{
    private Context _context;
    public OrderRepository(Context context)
    {
        _context = context;
    }
    public List<Order> GetAll()
    {
        return _context.Orders;
    }

    public Order GetById(Guid id)
    {
        return _context.Orders.FirstOrDefault(f => f.Id == id);
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }

    public void Update(Order order)
    {
        var oldOrder = GetById(order.Id);
        _context.Orders.Remove(oldOrder);
        Add(order);
    }

    public void SaveChanges()
    {
        //
    }
}