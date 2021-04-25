using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{

    public class VeggiePizza : APizza
    {       
        
        protected override void AddName()
        {
            Name = "Veggie Pizza";
        }
        protected override void AddCrust()
        {
            Crust = new Crust() {Name = "Gluten Free"};
        }

        protected override void AddSize()
        {
            Size = new Size() {Name = "Medium"};
        }

        protected override void AddToppings()
        {
            Toppings = new List<Topping> 
            {
                // new Topping() {Name = "Peppers"},
                // new Topping() {Name = "Mushrooms"},
            };
        }
    }
}
