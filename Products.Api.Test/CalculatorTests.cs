using Category.Api;
using Xunit;

namespace Products.Api.Test
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            var calc = new Calculator();
            var result = calc.Add(5, 3);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Multiply_ReturnsCorrectProduct()
        {
            var calc = new Calculator();
            var result = calc.Multiply(4, 6);
            Assert.Equal(24, result);
        }

        [Fact]
        public void Divide_ByNonZero_ReturnsQuotient()
        {
            var calc = new Calculator();
            var result = calc.Divide(10, 2);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowsException()
        {
            var calc = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
        }
    }
}
