using Calculator.Tests.Unit.ClassFixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Tests.Unit
{
    public class ComputingTests : IClassFixture<ComputingClassFixture>
    {
        Computing computing;
        public ComputingTests(ComputingClassFixture c)
        {
            computing = c.computing;
        }

        [Fact]
        public void OddOrEven_Should_Return_Odd_when_Input_is_OddValue()
        {
            //Act
            var result = computing.OddOrEven(11);


            //Assert
            result.Should().Be("Odd");
        }
        [Theory]
        [InlineData(10)]
        public void OddOrEven_Should_Return_Even_when_Input_is_EvenValue(int value)
        {
            //Act
            var result = computing.OddOrEven(value);


            //Assert
            result.Should().Be("Even");
        }

        [Fact]
        public void CalculateAge_Should_Return_Zero_when_BirthDate_LessThan_Zero()
        {
            //Act
            var result = computing.CalculateAge(-1 , 2022);


            //Assert
            result.Should().Be(0);
        }

        [Fact]
        public void CalculateAge_Should_Throw_ArgumentException_when_BirthDate_Or_CurrentDate_Is_Zero()
        {
            //Act
            var result = new Action(() =>
            {
                computing.CalculateAge(0, 0);
            });


            //Assert
            result.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CalculateAge_Should_ReturnTrueAge_when_Inputs_Are_Valid()
        {
            //Act
            var result = computing.CalculateAge(2002, 2022);


            //Assert
            result.Should().Be(20);
        }

        [Fact]
        public void IsPrime_Should_Return_False_when_Input_LessThan_2()
        {
            //Act
            var result = computing.IsPrime(1);


            //Assert
            result.Should().Be(false);
        }

        [Fact]
        public void IsPrime_Should_Return_False_when_Input_Is_Less_Than_Ten()
        {
            //Act
            var result = computing.IsPrime(10);


            //Assert
            result.Should().Be(false);

        }
        [Fact]
        public void IsPrime_Should_Return_False_when_Input_Is_More_Than_Ten()
        {
            //Act
            var result = computing.IsPrime(11);


            //Assert
            result.Should().Be(true);

        }
    }
}
