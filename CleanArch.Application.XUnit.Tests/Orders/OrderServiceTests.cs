using CleanArch.Application.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;
using CleanArch.Contracts;
using CleanArch.Domain.OrderAgg.Repository;
using CleanArch.Domain.OrderAgg;
using FluentAssertions;
using CleanArch.Application.Orders.Dtos;

namespace CleanArch.Application.XUnit.Tests.Orders
{
    public class OrderServiceTests
    {
        private readonly OrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private readonly ISmsService _smsService;
        public OrderServiceTests()
        {
            _orderRepository = Substitute.For<IOrderRepository>();
            _smsService = Substitute.For<ISmsService>();
            _orderService = new(_orderRepository, _smsService);
        }


        [Fact]
        public void Should_Add_Order()
        {
            //Arrange
            var id = new Guid();
            var command = new AddOrderDto(id , 2 , 20000);


            //Act
            _orderService.AddOrder(command);

            //Assert
            _orderRepository.Received(1).SaveChanges();

        }


        [Fact]
        public void Should_Return_List_Of_Order()
        {
            //Arrange
            var id = new Guid();
            _orderRepository.GetAll().Returns(new List<Order>() { new Order(new Guid()) , new Order(new Guid())});


            //Act
            var res = _orderService.GetOrders();

            //Assert
            res.Should().HaveCount(2);

        }

    }
}
