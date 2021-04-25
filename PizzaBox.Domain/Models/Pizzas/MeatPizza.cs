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
            Crust = new Crust() {Name = "Thin"};
        }

        protected override void AddSize()
        {
            Size = new Size() {Name = "Medium"};
        }

        protected override void AddToppings()
        {
            Toppings = new List<Topping> 
            {
                // new Topping() {Name = "Pepperoni"},
                // new Topping() {Name = "Sausage"},
            };
        }
    }
}
