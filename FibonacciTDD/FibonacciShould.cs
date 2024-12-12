using FluentAssertions;
using Xunit.Sdk;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FibonacciTDD
{
    public class FibonacciShould
    {
        [Theory]

        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        [InlineData(8, 21)]
        [InlineData(19, 4181)]

        public void ReturnNthFibonacci(int nthPosition, int expected)
        {
            var fibonacci = Fibonacci.CalculateFibonacci(nthPosition);
            fibonacci.Should().Be(expected);
        }

        [Theory]
        [InlineData(-1)]
        public void ReturnException(int nthPosition)
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.CalculateFibonacci(nthPosition));
        }

    }

    public class Fibonacci 
    {
        public static int CalculateFibonacci(int nthPosition) {

            if (nthPosition < 0) {
                throw new ArgumentException("nthPosition cannot be negative");
                   
            }

           if (nthPosition == 0)
                return 0;
           if (nthPosition == 1)
                return 1;

            int fibonacciValue = 0;
            int firstPosition = 0;
            int secondPosition = 1;

            for (int i = 2; i<= nthPosition; i++)
            {
                fibonacciValue = firstPosition + secondPosition;
                firstPosition = secondPosition;
                secondPosition = fibonacciValue;              

            }

            return fibonacciValue;
        }
        
    }
}