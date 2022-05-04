using CleanArch.Application.Orders.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Orders
{
    public interface IOrderService
    {
        void AddOrder(AddOrderDto command);
        void FinallyOrder(FinallyOrderDto command);
        OrderDto GetOrderById(Guid id);
        List<OrderDto> GetOrders();
    }
}
