using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{

    public class CustomPizza : APizza
    {       
        protected override void AddName()
        {
            Name = "Custom Pizza";
        }
        protected override void AddCrust()
        {
            Crust = new Crust() {
                Name="Thin"
            };
        }

        protected override void AddSize()
        {
            Size = new Size() {
                Name="Medium"
            };
        }

        protected override void AddToppings()
        {            
            Toppings = new List<Topping> 
            {
                new Topping() {Name = "Cheese"},
                new Topping() {Name = "Marinara"},
            };
        }

    }
}
