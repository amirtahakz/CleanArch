using CleanArch.Application.Orders.Dtos;
using CleanArch.Contracts;
using CleanArch.Domain.OrderAgg;
using CleanArch.Domain.OrderAgg.Repository;
using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly ISmsService _smsService;

        public OrderService(IOrderRepository repository, ISmsService smsService)
        {
            _repository = repository;
            _smsService = smsService;
        }

        public void AddOrder(AddOrderDto command)
        {
            var order = new Order(command.ProductId);
            _repository.Add(order);
            _repository.SaveChanges();
        }

        public void FinallyOrder(FinallyOrderDto command)
        {
            var order = _repository.GetById(command.OrderId);
            order.Finally();
            _repository.Update(order);
            _smsService.SendSms(new SmsBody()
            {
                Message = "Test",
                PhoneNumber = "0917000000"
            });
            _repository.SaveChanges();
        }

        public OrderDto GetOrderById(Guid id)
        {
            var order = _repository.GetById(id);
            return new OrderDto()
            {
                Id = order.Id,
                UserId = order.UserId,
            };
        }

        public List<OrderDto> GetOrders()
        {
            return _repository.GetAll().Select(order => new OrderDto()
            {
                Id = order.Id,
                UserId = order.UserId,
                //ProductId = order.ProductId
            }).ToList();
        }
    }
}
