using PizzaBox.Domain.Abstracts;    //What do the dots mean?

namespace PizzaBox.Domain.Models

{


    public class Customer
    {

        public string Name {get; protected set;}
        public Customer(string Name)
        {
            this.Name = Name;
        }
    }
}


//Customer should be able to:
//Launch the application.
//View all the stores.
//Select a store.
//Place an order.
//Choose from custom or preset pizzas.
//  custom: choose crust, size, and toppings.
//  preset:  Choose the pizza and size.
//Should be able to view a preview of the order in progress.
//Should be able to modify the order in progress.
//Should be able to place/checkout the order in progress.
//Should be able to view the order history.
//Should be able to make a new order.

//REQUIREMENTS:
//
//Each customer must be able to view their order history.
//Each customer must be able to only order from 1 location in a 24-hour period with no reset.
//Each customer can only order once in a 2-hour period.


// [ ] Launch the application. Create an if-then for 1. Customer 2. Owner.
// [x] view all the stores.
// [x] Select a store
// [ ] Create a while-do loop for placing an order. (Where does this go?)
//      -Uses a flag and asks the user if they want another pizza after each pizza is determined.
// [ ]      Prompt inside the loop to ask if they want a custom or preset pizza.
// [ ]      Create at least two CustomPizzas by extending the Pizza class and giving it preset toppings in the constructor.
// [ ]      Create a while-loop for determining this particular pizza.
// [ ]      Ask the user if they would like to add or remove any toppings.
// [ ]          For ADD: 
// [ ]              -Create a method on pizza for AddToppings.
// [ ]              -Show the listing of available toppings.
// [ ]              -Create an enum type for the available toppings.
// [ ]          For REMOVE:
// [ ]              -Show the list of included toppings.          
// [ ]              -Create a method on the pizza for RemoveToppings.
// [ ]      Ask the user if they would like to VIEW, CHECKOUT, ADD, or EDIT.
// [ ]              -For edit, list the current pizzas if there are more than one.
// [ ]                  -Ask if they would like to remove to edit the selected pizza.
// [ ]                  -Go back into the CreatePizza while-loop. (?)
// [ ]      Ask the customer if they would like to view their order history (before/after ordering.);
//
// [ ]Write checklist for AS STORE




//MISCELLANEOUS clean-ups
// [ ] Refactor so that the order takes the actual Customer and Store objects instead of the string.
// [ ] Move WelcomeToPizzaBox into its own file.
//
// RE: Thursday class
// [ ] Add tests.
// [ ] Create the Store and Pizza Singletons and get these working.
// [ ] Test the Singletons.
// [ ] Create a separate project space for saving.
//          -This can be called "Storing."  (See Fred's code.)