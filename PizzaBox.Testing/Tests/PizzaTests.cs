using Xunit;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;

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

        [Fact]
        public void Test_Pizza_Headings()
        {
            // var sut = new CustomPizza();
            var actual = APizza.Headings();
         
            Assert.IsType<string>(actual);
        }

        [Fact]
        public void Test_ToppingsStrings ()
        {
            var sut = new CustomPizza();

            List<string> actual = sut.ToppingStrings();

            Assert.IsType<List<string>>(actual);
        }

        [Fact]
        public void Test_MeatPizza_ToString()
        {
            var sut = new MeatPizza(){Name="Meat Pizza"};

            string actual = sut.ToString();

            Assert.IsType<string>(actual);
        }

        [Fact]
        public void Test_Veggie_ToString()
        {
            var sut = new VeggiePizza();

            string actual = sut.ToString();

            Assert.IsType<string>(actual);
        }

        [Fact]
        public void Test_CustomPizza()
        {
            var sut = new CustomPizza();

            string actual = sut.ToString();

            Assert.NotNull(actual);
        }
    }
}