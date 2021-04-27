using sc = System.Console;
using PizzaBox.Domain.Abstracts;
using System.Text;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{

    public class Order : AModel 
    {
        public Customer Customer {get; set;}

        // public long CustomerEntityId;
        public AStore Store {get; set;}
        
        // public long StoreEntityId;   ???

        public List<APizza> Pizzas {get; set;}
        

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var separator = ", ";   
 
            stringBuilder.Append(Customer.ToString() + "\n");
            stringBuilder.Append(Store.ToString() + "\n");


            foreach (APizza p in Pizzas) 
            {
                stringBuilder.Append(p.ToString() + "\n");
            }      

            return stringBuilder.ToString().TrimEnd(separator.ToCharArray());

            //Include price calculation.
        }  
    }
}
