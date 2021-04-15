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
            Assert.True(actual == "ChicagoStore");



        }
    }
}



// [ ] Write additional tests for:
// [ ] Each class:
// [ ]  Customer
// [ ]  Stores
// [ ]      -Test the New York store.
// [ ]  Pizza
// [ ]  Order
//
// [ ] What needs to be tested for each one (finish list)?

