using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.Tests

{

    public class ComponentTests
    {
        [Fact]
        public void Test_Size()
        {
            var sut = new Size(){Name="Medium", Price=15.00M};

            var actual = sut.Name;

            Assert.IsType<string>(actual);
            
        }
    }
}

