using System.Collections.Generic;
using sc = System.Console;


namespace PizzaBox.Domain.Models
{

    public class Pizza{

        private static List<string> toppings = new List<string>{"Cheese", "sauce"};
        public Pizza() 
        {
           sc.WriteLine("Toppings: ");
           foreach (string topping in toppings)
           {
               sc.WriteLine(topping);
           }
                      
        }

        public List<string> Toppings { get => toppings; set => toppings = value; }
    }
}

//Each pizza must be able to have a crust.
//Each pizza must be able to have a size.
//Each pizza must be able to have toppings.
//Each pizza must be able to compute its pricing.
//Each pizza must have no less than 2 default toppings.
//Each pizza must have no more than 5 total toppings.