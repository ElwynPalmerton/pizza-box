using System;
using System.Collections.Generic;
using sc = System.Console;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Client.Helpers;

namespace PizzaBox.Client 
{
    public class Program 
    {   

        private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
        private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
        private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
        private static readonly ToppingSingleton _toppingSingleton = ToppingSingleton.Instance;
        private static readonly SizeSingleton _sizeSingleton = SizeSingleton.Instance;
        private static readonly CrustSingleton _crustSingleton = CrustSingleton.Instance;
        private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;
     
        private static void Main() 
        {
            // Run();
            Dev();
        }

        private static void Dev()
        {
            var order = new Order();

            // order.Store = SelectStore();

            order.Pizzas = TakeOrder();  
        }

        private static void Run()
        {
              sc.WriteLine("run");
              SelectPortal();
        }

        private static void RunCustomerPortal() 
        {
            UserInterface.WelcomeToPizzaBox(); 

            var order = new Order();

            order.Store = SelectStore();
            order.Customer = GetCustomer();    

            order.Pizzas = TakeOrder();       
        }

        private static void RunOwnerPortal()
        {
            UserInterface.MenuTitle("Welcome to the PizzaBox manager portal!");
        }

        private static void SelectPortal()
        {
            UserInterface.MenuTitle("Welcome to the PizzaBox portal!");

            List<string> PortalOptions = new List<string> {"Customer Portal.", "Owner Portal."};

            int portalSelection = Selector("Select an option: ", 2, PortalOptions);

            if (portalSelection == 0)
            {
                RunCustomerPortal();
            }
            else
            {
                RunOwnerPortal();
            }
        }

        private static int Selector(string optionString, int numberOfOptions, List<string> options)
        {
            bool validEntry = false;
            int optionNumber = -1;
            string selection;

            while (!validEntry)
            {
                UserInterface.MenuTitle(optionString);
                PrintOptionsList(options);
                selection = UserInterface.GetUserInfo("Please make a selection: ");

                validEntry = UserInterface.CheckValidNumber(selection, numberOfOptions); 
                sc.WriteLine();

                if (!validEntry)
                {
                    UserInterface.InvalidEntry(selection);
                } else {
                    optionNumber = int.Parse(selection);
                    optionNumber--;
                    validEntry = true;   
                }
            }    
            return optionNumber;   
        }
        private static AStore SelectStore()
        {
            AStore newStore;

            int count = _storeSingleton.Stores.Count;
            List<string> storeList = _storeSingleton.ToStringList();

            int storeNumber = Selector("Enter the number of the nearest store: ", count, storeList);

            newStore = _storeSingleton.Stores[storeNumber];
            sc.WriteLine(newStore.Name);
            return newStore;
        }

        private static void PrintOptionsList(List<string> options)
        {
            // UserInterface.MenuTitle("Please make a selection: ");
            // sc.WriteLine("Please select a valid option: ");
            int index = 1;
            foreach(string option in options)
            {
                sc.WriteLine(index + ". " + option);
                index++;
            }
            sc.WriteLine();

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
                List<string> options = new List<string>{"Add a pizza", "Modify your order", "Complete order"};

                int option = Selector("Select an option: ", options.Count, options);

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

        private static List<APizza> ModifyOrder(List<APizza> pizzas)
        {
            if (pizzas.Count > 0) ShowCurrentOrder(pizzas);
            //List all the pizza in the order to modify.
            //Pass the pizza into 
            sc.WriteLine("Inside modify order: ");
            List<string> options = new List<string>{"Add/remove toppings.", "Remove a pizza from your order", "Nevermind, don't make any changes."};
            
            int optionNumber = Selector("Would you like to...", options.Count, options);

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

            int pizzaNumber = Selector(message, pizzas.Count, pizzaList);
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

        private static APizza ModifyPizza(APizza newPizza)
        {
            bool completePizza = false;
            List<string> options = new List<string>{"Add a topping.", "Remove a topping", "Add this pizza to your order."};
            
            do{
                sc.WriteLine(APizza.Headings());
                sc.WriteLine(newPizza.ToString());
                sc.WriteLine();

                int optionNumber = Selector("Would you like to...", options.Count, options);
                
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
        private static APizza BuildYourPizza()
        { 
      
            var newPizza = SelectPizza();
            var modifiedPizza = ModifyPizza(newPizza);
            return modifiedPizza;

        }

        private static void PrintToppingList()
        {
            int index = 0;                        
            UserInterface.MenuTitle("Available Toppings: ");

            foreach (Topping topping in _toppingSingleton.Toppings)
            {
                index++;
                sc.WriteLine($"{index} {topping.Name}");
            }
            sc.WriteLine();
        }

        private static APizza AddATopping(APizza currentPizza)
        {
            sc.WriteLine("AddATopping");

            bool validEntry = false;
            int toppingNumber = -1;
            // string toppingSelected;
            Topping newTopping = new Topping();
  
            while (!validEntry)
            {
                int count = _toppingSingleton.Toppings.Count;
                List<string> toppingList = _toppingSingleton.ToStringList();
                toppingNumber = Selector("Select a topping to add: ", count, toppingList);

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

            //Cannot have fewer than two toppings!!!3

            bool validEntry = false;
            int toppingNumber = -1;
            string toppingSelected;
            Topping newTopping = new Topping();

            while (!validEntry)
            {
                UserInterface.MenuTitle("Which topping would you like to remove?");
                sc.WriteLine();
                int index = 1 ;

                foreach(Topping top in currentPizza.Toppings)
                {
                    sc.WriteLine(index + ". " + top.Name);
                    index++;
                }
                sc.WriteLine();

                toppingSelected = UserInterface.GetUserInfo("Enter a number: ");
                validEntry = UserInterface.CheckValidNumber(toppingSelected, _toppingSingleton.Toppings.Count);

                if (!validEntry)
                {             
                    UserInterface.InvalidEntry(toppingSelected);
                } else {
                    toppingNumber = int.Parse(toppingSelected);
                    validEntry = true;   
                    toppingNumber--;
                }
            }

            currentPizza.Toppings.RemoveAt(toppingNumber);

            sc.WriteLine("After topping removal: " + currentPizza.ToString());


            return currentPizza;
        }
        private static APizza SelectPizza()    //Need to change void to APizza
        {
            APizza newPizza;

            int count = _pizzaSingleton.Pizzas.Count;
            List<string> pizzaList = _pizzaSingleton.ToStringList();

            int pizzaNumber = Selector("Please select a pizza: ", count, pizzaList);

// 
//             bool validEntry = false;
//             int pizzaNumber = -1;
//             string pizzaSelection;
//   
//             while (!validEntry)
//             {
//                
//                 PrintPizzaList();
//                 pizzaSelection = UserInterface.GetUserInfo("Enter a number: ");
// 
//                 validEntry = UserInterface.CheckValidNumber(pizzaSelection, _pizzaSingleton.Pizzas.Count);
// 
//                 if (!validEntry)
//                 {             
//                     UserInterface.InvalidEntry(pizzaSelection);
//                 } else {
//                     pizzaNumber = int.Parse(pizzaSelection);
//                     validEntry = true;   
//                     pizzaNumber--;
//                 }
//             }   




                newPizza = _pizzaSingleton.Pizzas[pizzaNumber];
                return newPizza;    
        }
        private static void PrintPizzaList(string message = "What kind of pizza would you like? ")
        {
            int index = 0;                        
            UserInterface.MenuTitle(message);

            foreach (var pizza in _pizzaSingleton.Pizzas)
            {
                index++;
                sc.WriteLine($"{index} {pizza.Name}");
            }
            sc.WriteLine();
        }
 
    }   
}
