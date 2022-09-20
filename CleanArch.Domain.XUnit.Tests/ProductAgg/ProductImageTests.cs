using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.Shared.Exceptions;
using CleanArch.Domain.XUnit.Tests.Builders;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArch.Domain.XUnit.Tests.ProductAgg
{
    public class ProductImageTests
    {
        [Fact]
        public void Constructor_Should_Create_ProductImage_When_Data_Is_Ok()
        {
            //Arrange
            var result = new ProductImage(new Guid(), "test.png");


            //Assert
            result.ImageName.Should().Be("test.png");

        }

        [Fact]
        public void Constructor_Should_Throw_NullOrEmptyDomainDataException_When_ImageName_Is_null()
        {
            //Arrange
            var result =()=> new ProductImage(new Guid(), "");



            //Assert
            result.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("imageName is null or empty");

        }
    }
}
