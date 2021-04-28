using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.Tests

{

    public class StoreTests
    {
        [Fact]
        public void Test_ChicagoStore_Name()
        {
            // arrange
            var sut = new ChicagoStore();

            // act
            var actual = sut.Name;
            
            // assert
            Assert.IsType<string>(actual);
        }

        [Fact]
        public void Test_NewYorktore_Name()
        {
            // arrange
            var sut = new NewYorkStore();

            // act
            var actual = sut.Name;
            
            // assert
            Assert.IsType<string>(actual);
        }

        [Fact]
        public void Test_NewYorkStore_NotNull()
        {
            // arrange
            var sut = new NewYorkStore();

            // act
            var actual = sut;
            
            // assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void Test_ChicagoStore_NotNull()
        {
            // arrange
            var sut = new NewYorkStore();

            // act
            var actual = sut;
            
            // assert
            Assert.NotNull(actual);
        }
    }
}

