using sc = System.Console;

namespace PizzaBox.Domain.Models
{

    public class Order
    {
        //Order has customer.
        //and a store.
        public string CustomerName;
        public string StoreName;

         public Order(string Store, string Customer) //This needs to be refactored to be the object.
        {
            this.CustomerName = Customer;
            this.StoreName = Store;

            sc.WriteLine("");
            sc.WriteLine("Your order so far: ");
            sc.WriteLine("customer name: " + this.CustomerName);
            sc.WriteLine("store name: " + this.StoreName);

        }
    }
}

//Each order must be able to modify its collection of pizzas.
//Each order must be able to compute its pricing.
//Each order must be limited to a total pricing of no more than $250.
//Each order must be limited to a collection of no more than 50 pizzas.