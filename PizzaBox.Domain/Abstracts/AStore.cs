using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{

    [XmlInclude(typeof(ChicagoStore))]   
    [XmlInclude(typeof(NewYorkStore))]

    public abstract class AStore : AModel 
    {
        public string Name {get; set;} 

        public List<Order> Orders { get; set;}
     

        public override string ToString()

        {
            return Name;
        }   
    }
}



//As a store
//Should be able to launch the application.
//Should be able to select options for:
//      -order history.
//          -Should be able to view all orders(including pizza count and total cost);
//          -Should be able to view orders by customer.
//      -for sales
//          -should be able to view revenue by week (including pizza type and count).
//          -should be able to view revenue by month (including pizza type and count).


//There should exist at least 2 stores for a customer to choose from.
// each store should be able to view any and all of their place orders.
//Each store should be able to view any and all of their sales (weekly, monthly quarterly);


// [ ] Menu for Select store.
// [ ] Put this in a while-loop with a flag.
// [ ] Menu for ORDER history or SALES.
// [ ]  -Select TOTAL or by CUSTOMER.
// [ ]      -Show all the customers.
// [ ]      -Select by customer.
// [ ]  -Select by WEEK or by MONTH.
// [ ]      -Select by pizza TYPE or COUNT.
// [ ] Ask if they would like to see more sales or order information.