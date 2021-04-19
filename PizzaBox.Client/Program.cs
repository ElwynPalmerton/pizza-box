using System;
using System.Collections.Generic;
using sc = System.Console;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Client.Helpers;
using PizzaBox.Client.Test;

namespace PizzaBox.Client 
{
    public class Program 
    {   
        private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
        private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
       
        private static Customer GetCustomer()
        {    
            string CustomerName = UserInterface.GetUserInfo("Please enter your name: ");
            string StreetAddress = UserInterface.GetUserInfo("Please enter your address: ");
            string PhoneNumber = UserInterface.GetUserInfo("Please enter your phone#: ");

            var newCustomer = new Customer(CustomerName, StreetAddress, PhoneNumber);

            return newCustomer;
        }

        private static void PrintStoreList()
        {
            int index = 0;
                        
            sc.WriteLine();
            sc.WriteLine("Please select a store near you: ");
            sc.WriteLine();

            foreach (var store in _storeSingleton.Stores)
            {
                index++;
                sc.WriteLine($"{index} {store.Name}");
            }
        }

        private static void PrintPizzaList()
        {
            int index = 0;
                        
            sc.WriteLine();
            sc.WriteLine("What kind of pizza would you like? ");
    
            sc.WriteLine();

            foreach (var pizza in _pizzaSingleton.Pizzas)
            {
                index++;
                sc.WriteLine($"{index} {pizza.Name}");
            }
        }

        private static AStore SelectStore()
        {
            // sc.BackgroundColor = ConsoleColor.DarkRed;
            // sc.ForegroundColor = ConsoleColor.Yellow;

            bool validEntry = false;
            int storeNumber = -1;
            AStore newStore;
            string storeSelection;

            while (!validEntry)
            {
                PrintStoreList();
                storeSelection = UserInterface.GetUserInfo("Enter the number of your store: ");


                validEntry = UserInterface.CheckValidNumber(storeSelection, _storeSingleton.Stores.Count); 

                if (!validEntry)
                {             
                    UserInterface.InvalidEntry(storeSelection);
                } else {
                    storeNumber = int.Parse(storeSelection);
                    validEntry = true;   
                    storeNumber--;
                }
            }       
                newStore = _storeSingleton.Stores[storeNumber]; 
                return newStore;           
        }

        private static APizza SelectPizza()    //Need to change void to APizza
        {
            bool validEntry = false;
            int pizzaNumber = -1;
            APizza newPizza;
            string pizzaSelection;

  

            while (!validEntry)
            {
               
                PrintPizzaList();
                pizzaSelection = UserInterface.GetUserInfo("Enter a number: ");

                validEntry = UserInterface.CheckValidNumber(pizzaSelection, _pizzaSingleton.Pizzas.Count);

                if (!validEntry)
                {             
                    UserInterface.InvalidEntry(pizzaSelection);
                } else {
                    pizzaNumber = int.Parse(pizzaSelection);
                    validEntry = true;   
                    pizzaNumber--;
                }
            }       
                newPizza = _pizzaSingleton.Pizzas[pizzaNumber]; 
                return newPizza;    
        }

        private static APizza BuildYourPizza()
        {
            var newPizza = SelectPizza();

            return newPizza;

            //How do I add toppings and whatnot???


        }

        private static void Run() 
        {
            var order = new Order();

//             UserInterface.WelcomeToPizzaBox();
//             order.Customer = GetCustomer();
//             order.Store = SelectStore();

            order.Pizza = BuildYourPizza();

        


            // order.Pizza = SelectPizza();
            UserInterface.OutputCurrentState(order);

        }
         private static void Main() 
        {
            Run();
        }
    }   
}

///////////////////PLACING AN ORDER////////////////////////
/// // [x] Select a store
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