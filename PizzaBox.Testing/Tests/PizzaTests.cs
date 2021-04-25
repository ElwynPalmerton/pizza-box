using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.Tests

{

    public class PizzaTests
    {
        [Fact]
        public void Test_Pizza_ComputePrice()
        {
            // arrange
            var sut = new CustomPizza();

            // act
            var actual = sut.ComputePrice();
        
            // assert
            Assert.IsType<decimal>(actual);
        }

        public void Test_Pizza_Headings()
        {
            



        }
    }
}