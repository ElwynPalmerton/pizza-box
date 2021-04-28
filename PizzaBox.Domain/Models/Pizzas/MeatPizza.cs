using System.Collections.Generic;
using sc = System.Console;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{

    public class MeatPizza : APizza
    {       
        protected override void AddName()
        {
            Name = "Meat Pizza";
        }
        protected override void AddCrust()
        {
            Crust = new Crust() {};
        }

        protected override void AddSize()
        {
            Size = new Size() {};
        }

        protected override void AddToppings()
        {
            Toppings = new List<Topping> 
            {
                // new Topping() {Name = "Pepperoni", Price=4.00M},
                // new Topping() {Name = "Sausage", Price=5.00M},
            };
        }
    }
}
