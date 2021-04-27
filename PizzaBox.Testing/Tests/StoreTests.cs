using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.Tests

{

    public class StoreTests
    {
        [Fact]
        public void Test_ChicagoStore()
        {
            // arrange
            var sut = new ChicagoStore();

            // act
            var actual = sut.Name;
            //sut.Name = "dotnet";  //Cannot be changed because it is protected.
            //actual = "dotnet"; //This should not happen
            
            // assert
            Assert.IsType<string>(actual);
        }
    }
}

