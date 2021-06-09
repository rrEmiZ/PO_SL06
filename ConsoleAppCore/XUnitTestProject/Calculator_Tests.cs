using ConsoleAppCore;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class Calculator_Tests
    {
        private readonly Calculator calc;

        public Calculator_Tests()
        {
            calc = new Calculator();
        }

        [Fact]
        public void Add_For1And2_Returns3()
        {
         

            var result = calc.Add(1, 2);

            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(1,2,3)]
        [InlineData(-1, 2, 1)]
        [InlineData(-1, -2, -3)]
        [InlineData(1, -2, -1)]
        public void Add_ForAAndB_ReturnsResultExcpected(int a, int b, int resultExcpected)
        {
           // var calc = new Calculator();

            var result = calc.Add(a, b);

            Assert.Equal(resultExcpected, result);
        }


        [Fact]
        public void IsEven_For1_ReturnsFalse()
        {
          //  var calc = new Calculator();

            bool result = calc.IsEven(1);

            Assert.False(result);
        }


        [Fact]
        public void IsEven_For2_ReturnsTrue()
        {
          //  var calc = new Calculator();

            bool result = calc.IsEven(2);

            Assert.True(result);
        }

    }
}
