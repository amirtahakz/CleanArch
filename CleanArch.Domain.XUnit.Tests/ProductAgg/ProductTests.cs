using CleanArch.Domain.Shared;
using CleanArch.Domain.Shared.Exceptions;
using CleanArch.Domain.XUnit.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace CleanArch.Domain.XUnit.Tests.ProductAgg
{
    public class ProductTests
    {
        private ProductBuilder _productBuilder;
        public ProductTests()
        {
            _productBuilder = new ProductBuilder();
        }


        [Fact]
        public void Constructor_Should_Create_Product_When_Data_Is_Ok()
        {
            //Arrange
            _productBuilder.SetTitle("test1").SetMoney(100);

            //Act
            var result = _productBuilder.Build();

            //Assert

            result.Title.Should().Be("test1");

        }

        [Fact]
        public void Constructor_Should_Throw_NullOrEmptyDomainDataException_When_Title_IsNull()
        {

            //Act
            var result = () => _productBuilder.SetTitle("").Build();


            //Assert
            result.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("title is null or empty");

        }

        [Fact]
        public void Edit_Should_Update_Product_When_Data_Is_Ok()
        {
            //Arrange
            var result = _productBuilder.SetTitle("test1").SetMoney(100).Build();

            //Act
            result.Edit("edited", new Money(1000) ,"dedd");

            //Assert

            result.Title.Should().Be("edited");
            result.Money.Value.Should().Be(1000);

        }

        [Fact]
        public void Edit_Should_Throw_NullOrEmptyDomainDataException_When_Title_IsNull()
        {
            //Arrange
            var result = _productBuilder.SetTitle("test1").SetMoney(100).Build();

            //Act
            var action = () => result.Edit("", new Money(100) , "");


            //Assert
            action.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("title is null or empty");

        }

        [Fact]
        public void AddImage_Should_Add_New_Image_To_Product()
        {
            //Arrange
            var result = _productBuilder.SetTitle("test1").SetMoney(100).Build();

            //Act
            result.AddImage("test.png");


            //Assert
            result.Images.Should().HaveCount(1);

        }

        //[Fact]
        //public void RemoveImage_Should_Remove_Image_When_Image_Is_Exist()
        //{
        //    //Arrange
        //    var result = _productBuilder.SetTitle("test1").SetMoney(100).Build();
        //    result.AddImage("test.png");

        //    //Act
        //    result.RemoveImage(new Guid());


        //    //Assert
        //    result.Images.Should().HaveCount(1);

        //}

        [Fact]
        public void RemoveImage_Should_Throw_NullOrEmptyDomainDataException_When_Image_Is_Not_Exist()
        {
            //Arrange
            var result = _productBuilder.SetTitle("test1").SetMoney(100).Build();
            result.AddImage("test.png");

            //Act
            var action = () => result.RemoveImage(new Guid());


            //Assert
            action.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("image mot found");

        }
    }
}