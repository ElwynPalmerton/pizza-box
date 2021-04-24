using sc = System.Console;
using PizzaBox.Domain.Abstracts;
using System.Text;

namespace PizzaBox.Domain.Models
{

    public class Order
    {
        public Customer Customer {get; set;}
        public AStore Store {get; set;}
        public APizza Pizza {get; set;}



        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var separator = ", ";   
            //Customer
            //Store
            //Pizzas    
            stringBuilder.Append(Customer.ToString() + "\n");
            stringBuilder.Append(Store.ToString() + "\n");

            //Iterate over the pizzas.

            return stringBuilder.ToString().TrimEnd(separator.ToCharArray());
    
        }  
  

        // public decimal TotalCost
        // {
        //     get
        //     {
        //         // return Pizza.Crust.Price + Pizza.size.Price + Pizza.Topping.Sum(t => t.Price);
        //     }
        // }

    }
}


//Each order must be able to modify its collection of pizzas.
//Each order must be able to compute its pricing.
//Each order must be limited to a total pricing of no more than $250.
//Each order must be limited to a collection of no more than 50 pizzas.