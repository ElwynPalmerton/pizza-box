using System;
using System.Collections.Generic;
using sc = System.Console;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Client.Helpers;
using PizzaBox.Storing;    
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client 
{
    public class Program 
    {   
        private static readonly PizzaBoxContext _context = new PizzaBoxContext();
        // private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance(_context);
        // Change the arguments in all of the constructors to take (PizzaBoxContext _context).

        private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance(_context);
        private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance(_context);
        private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance(_context);
        private static readonly ToppingSingleton _toppingSingleton = ToppingSingleton.Instance(_context);
        private static readonly SizeSingleton _sizeSingleton = SizeSingleton.Instance;
        private static readonly CrustSingleton _crustSingleton = CrustSingleton.Instance;
        private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance(_context);
        private static readonly OrderRepository _orderRepository = new OrderRepository(_context);
     
        private static void Main() 
        {
            Run();
        }

        private static void Run()
        {
              sc.WriteLine("run");
              SelectPortal();            
        }

        private static void RunCustomerPortal() 
        {
            var order = new Order();

            order.Store = SelectStore();
            // order.Customer = GetCustomer();
            // order.Pizza = TakeOrder();

            _orderRepository.Create(order);


            // order.Pizzas = TakeOrder();  

            // var orders = _context.Orders.Where(o => o.Customer.Name == order.Customer.Name);
        }

        private static void RunOwnerPortal()
        {
            UserInterface.MenuTitle("Welcome to the PizzaBox manager portal!");
        }

        private static void SelectPortal()
        {
            UserInterface.MenuTitle("Welcome to the PizzaBox portal!");

            List<string> PortalOptions = new List<string> {"Customer Portal.", "Owner Portal."};

            int portalSelection = UserInterface.Selector("Select an option: ", PortalOptions);

            if (portalSelection == 0)
            {
                RunCustomerPortal();
            }
            else
            {
                RunOwnerPortal();
            }
        }

        private static AStore SelectStore()
        {
            AStore newStore;

            int count = _storeSingleton.Stores.Count;
            List<string> storeList = _storeSingleton.ToStringList();

            int storeNumber = UserInterface.Selector("Enter the number of the nearest store: ", storeList);

            newStore = _storeSingleton.Stores[storeNumber];
            sc.WriteLine(newStore.Name);
            return newStore;
        }
        
        private static Customer GetCustomer()
        {   
            var newCustomer = new Customer();
            newCustomer.GetCustomerInfo();
            return newCustomer;
        }

        private static List<APizza> TakeOrder()
        {
            bool orderComplete = false;
            List<APizza> pizzaOrder = new List<APizza>();

            //I need to show the order here.
            
            while (!orderComplete)
            {
                if (pizzaOrder.Count > 0) ShowCurrentOrder(pizzaOrder);
                APizza newPizza = BuildYourPizza();

                pizzaOrder.Add(newPizza);

                sc.WriteLine("options:");
                List<string> options = new List<string>{"Add another pizza", "Modify your order", "Complete order"};

                int option = UserInterface.Selector("Select an option: ", options);

                sc.WriteLine(option + " in TakeOrder");
                switch(option)
                {
                    case 0:
                        break;
                    case 1:
                        ModifyOrder(pizzaOrder);
                        break;
                    case 2:
                        orderComplete = true;
                        break;
                }
            }
            return pizzaOrder;
        }

        private static void ShowCurrentOrder(List<APizza> pizzas)
        {
            sc.WriteLine("Current Order: ");
            APizza.Headings();
            foreach(APizza p in pizzas){
                sc.WriteLine(p.ToString());
            }      
        }

        private static APizza BuildYourPizza()
        { 
      
            var newPizza = SelectPizza();
            var modifiedPizza = ModifyPizza(newPizza);
            return modifiedPizza;
        }

        private static APizza SelectPizza()    //Need to change void to APizza
        {
            APizza newPizza;

            int count = _pizzaSingleton.Pizzas.Count;
            List<string> pizzaList = _pizzaSingleton.ToStringList();

            int pizzaNumber = UserInterface.Selector("Please select a pizza: ", pizzaList);            
            
            newPizza = _pizzaSingleton.Pizzas[pizzaNumber];
            return newPizza;    
        }

        private static APizza ModifyPizza(APizza newPizza)
        {
            bool completePizza = false;
            List<string> options = new List<string>{"Add a topping.", "Remove a topping", "Add this pizza to your order."};
            
            do{
                sc.WriteLine(APizza.Headings());
                sc.WriteLine(newPizza.ToString());
                sc.WriteLine();

                int optionNumber = UserInterface.Selector("Would you like to...", options);
                
                sc.WriteLine(optionNumber + " in BuildYourPizza");

                switch (optionNumber)
                {
                    case 0:
                        newPizza = AddATopping(newPizza);
                        break;
                    case 1:
                        newPizza = RemoveATopping(newPizza);
                        break;
                    case 2:
                        completePizza = true;
                        break;
                    default:
                        break;
                }               
            } while (!completePizza);

            return newPizza;
        }

        private static List<APizza> ModifyOrder(List<APizza> pizzas)
        {
            if (pizzas.Count > 0) ShowCurrentOrder(pizzas);
            //List all the pizza in the order to modify.
            //Pass the pizza into 
            sc.WriteLine("Inside modify order: ");
            List<string> options = new List<string>{"Add/remove toppings.", "Remove a pizza from your order", "Nevermind, don't make any changes."};
            
            int optionNumber = UserInterface.Selector("Would you like to...", options);

            switch (optionNumber)
            {
                case 0:
                    ChangeAPizza(pizzas);
                    break;
                case 1:
                    RemoveAPizza(pizzas);
                    break;
                case 2:
                    break;
            }

            return pizzas;
        }    

        private static void ShowAllPizzas (List<APizza> pizzas){
            int index = 1;
            APizza.Headings();
            foreach(APizza p in pizzas) {
                sc.WriteLine(index + ". " + p.ToString());
            }

        }
    
        private static int SelectPizzaToEditOrRemove(List<APizza> pizzas, string message)
        {  
            List<string> pizzaList = new List<string>();
            foreach (APizza p in pizzas)
            {
                pizzaList.Add(p.Name);
            }

            int pizzaNumber = UserInterface.Selector(message, pizzaList);
            return pizzaNumber;

        }
     
        private static List<APizza> ChangeAPizza(List<APizza> pizzas)
        {
            int pizzaIndex = SelectPizzaToEditOrRemove(pizzas, "Select a pizza to edit: ");
            pizzas[pizzaIndex] = ModifyPizza(pizzas[pizzaIndex]);
            return pizzas;
        }

        private static List<APizza> RemoveAPizza(List<APizza> pizzas)
        {        
            int pizzaIndex = SelectPizzaToEditOrRemove(pizzas, "Select a pizza to remove: ");
            pizzas.RemoveAt(pizzaIndex);
            return pizzas;
        }

//         private static void PrintToppingList()
//         {
//             int index = 0;                        
//             UserInterface.MenuTitle("Available Toppings: ");
// 
//             foreach (Topping topping in _toppingSingleton.Toppings)
//             {
//                 index++;
//                 sc.WriteLine($"{index} {topping.Name}");
//             }
//             sc.WriteLine();
//         }

        private static APizza AddATopping(APizza currentPizza)
        {
            sc.WriteLine("AddATopping");

            bool validEntry = false;
            int toppingNumber = -1;
            Topping newTopping = new Topping();
  
            while (!validEntry)
            {
                int count = _toppingSingleton.Toppings.Count;
                List<string> toppingList = _toppingSingleton.ToStringList();
                toppingNumber = UserInterface.Selector("Select a topping to add: ", toppingList);

                newTopping = _toppingSingleton.Toppings[toppingNumber]; 

                foreach (Topping topping in currentPizza.Toppings)
                {
                    if (topping.Name == newTopping.Name)
                    {
                        sc.ForegroundColor = ConsoleColor.Red;
                        sc.WriteLine("You already have " + topping.Name + " on your pizza.");
                        sc.WriteLine("Please make another selection");;
                        sc.ResetColor();
                        
                        validEntry = false;
                    } else {
                        validEntry = true;
                    }
                }
            }       
            currentPizza.Toppings.Add(newTopping);
            
            return currentPizza;             
        }
   
        private static APizza RemoveATopping(APizza currentPizza)
        {
            int toppingNumber = UserInterface.Selector("Which topping would you like to remove", currentPizza.ToppingStrings());
   
            currentPizza.Toppings.RemoveAt(toppingNumber);

            sc.WriteLine("After topping removal: " + currentPizza.ToString());

            return currentPizza;
        }

    }   
}
