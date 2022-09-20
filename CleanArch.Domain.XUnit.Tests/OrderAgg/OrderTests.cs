using NSubstitute;
using CleanArch.Domain.OrderAgg;
using FluentAssertions;
using Xunit;
using CleanArch.Domain.OrderAgg.Services;
using CleanArch.Domain.ProductAgg.Exceptions;
using CleanArch.Domain.Shared.Exceptions;

namespace CleanArch.Domain.XUnit.Tests.OrderAgg
{
    public class OrderTests
    {
        [Fact]
        public void Constructor_Should_Create_Order()
        {
            //Arrange
            var id = new Guid();
            var order = new Order(id);

            //Assert

            order.UserId.Should().Be(id);
            order.IsFinally.Should().Be(false);

        }

        [Fact]
        public void Finally_Should_Finalize_Order_And_Add_DomainEvent()
        {
            //Arrange
            var id = new Guid();
            var order = new Order(id);


            //Act
            order.Finally();


            //Assert
            order.IsFinally.Should().Be(true);

        }

        [Fact]
        public void AddItem_Should_Throw_ProductNotFoundException_When_Product_Not_Exist()
        {
            //Arrange
            var id = new Guid();
            var order = new Order(id);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductExist(Arg.Any<Guid>()).Returns(false);


            //Act
            var res = ()=> order.AddItem(id , 2 , 2000 , orderDomainService);


            //Assert
            res.Should().ThrowExactly<ProductNotFoundException>();

        }

        [Fact]
        public void AddItem_Should_Add_New_Item_To_Order()
        {
            //Arrange
            var id = new Guid();
            var order = new Order(id);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductExist(Arg.Any<Guid>()).Returns(true);


            //Act
            order.AddItem(id, 2, 2000, orderDomainService);


            //Assert
            order.Items.Should().HaveCount(1);

        }

        [Fact]
        public void AddItem_Should_Not_Add_Item_To_Order_When_Product_Is_Exist_In_Order()
        {
            //Arrange
            var id = new Guid();
            var order = new Order(id);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductExist(Arg.Any<Guid>()).Returns(true);
            order.AddItem(id, 2, 2000, orderDomainService);


            //Act
            order.AddItem(id, 2, 2000, orderDomainService);


            //Assert
            order.TotalItems.Should().Be(2);

        }

        [Fact]
        public void RemoveItem_Should_Throw_InvalidDomainDataException_When_Item_Is_Not_Exist()
        {
            //Arrange
            var id = new Guid();
            var order = new Order(id);


            //Act
            var action =()=> order.RemoveItem(new Guid());


            //Assert
            action.Should().ThrowExactly<InvalidDomainDataException>();

        }
        [Fact]
        public void RemoveItem_Should_Delete_Item()
        {
            //Arrange
            var id = new Guid();
            var order = new Order(id);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductExist(Arg.Any<Guid>()).Returns(true);
            order.AddItem(id, 2, 2000, orderDomainService);


            //Act
            order.RemoveItem(id);


            //Assert
            order.TotalItems.Should().Be(0);

        }
    }
}
