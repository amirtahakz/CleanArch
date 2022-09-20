using CleanArch.Domain.Shared;
using CleanArch.Domain.Shared.Exceptions;
using FluentAssertions;
using Xunit;

namespace CleanArch.Domain.XUnit.Tests.Shared
{
    public class MoneyTests
    {
        [Fact]
        public void Constructor_Should_Create_Money_When_Data_Is_Ok()
        {
            //Arrange
            var result = new Money(10000);


            //Assert
            result.Value.Should().Be(10000);

        }

        [Fact]
        public void Constructor_Should_Throw_InvalidDomainDataException_When_RialValue_LessThan_Zero()
        {
            //Arrange
            //Act
            var result =()=> new Money(-1);


            //Assert
            result.Should().ThrowExactly<InvalidDomainDataException>();

        }

        [Fact]
        public void FromRial_Should_Create_New_Money()
        {
            //Arrange
            var result = Money.FromRial(1000);


            //Assert
            result.Value.Should().Be(1000);

        }

        [Fact]
        public void FromTooman_Should_Create_New_Money_With_Tooman_Value()
        {
            //Arrange
            var result = Money.FromTooman(1000);


            //Assert
            result.Value.Should().Be(10000);

        }

        [Fact]
        public void Plus_Operator_Should_Sum_Values_And_Return_New_Money()
        {
            //Arrange
            var money1 = Money.FromRial(10000);
            var money2 = Money.FromRial(10000);

            //Act
            var result = money1 + money2;


            //Assert
            result.Value.Should().Be(20000);

        }

        [Fact]
        public void Minus_Operator_Should_Minus_Values_And_Return_New_Money()
        {
            //Arrange
            var money1 = Money.FromRial(20000);
            var money2 = Money.FromRial(10000);

            //Act
            var result = money1 - money2;


            //Assert
            result.Value.Should().Be(10000);

        }

        [Fact]
        public void ToString_Should_Convert_To_String_And_Return_New_Money()
        {
            //Arrange
            var money = Money.FromRial(20000);

            //Act
            var result = money.ToString();


            //Assert
            result.Should().Be("20,000");

        }
    }
}
