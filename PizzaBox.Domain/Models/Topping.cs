using System.Collections.Generic;
using sc = System.Console;
using PizzaBox.Domain.Abstracts;


namespace PizzaBox.Domain.Models
{
    public class Topping : AComponent
    {
        public List<APizza> Pizzas {get; set;}


    }
}