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
                // Name="Thin",
                // Price=0.00M
            };
        }

        protected override void AddSize()
        {
            Size = new Size() {
                // Name="Medium",
                // Price=21.00M
            };
        }

        protected override void AddToppings()
        {            
            Toppings = new List<Topping> 
            {
                // new Topping() {Name = "Cheese", Price=2.00M},
                // new Topping() {Name = "Marinara", Price=0.00M},
            };
        }

    }
}
