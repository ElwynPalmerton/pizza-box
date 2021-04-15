using System;
using System.Collections.Generic;
using sc = System.Console;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client 
{

    public class Controller {

        private static List<AStore> stores = new List<AStore>{new ChicagoStore(), new NewYorkStore()};

        private static AStore SelectedStore;
        private static Customer NewCustomer;
        public Controller() 
        {            
        }

        public static List<AStore> Stores { get => stores; private set => stores = value; }

        // public static Customer NewCustomer1 { get => NewCustomer; set => NewCustomer = value; }

        public static void FindStore()
        {
            sc.WriteLine("");
            for (var x = 0; x < Stores.Count; x += 1)
            {
                sc.WriteLine($"{x} {Stores[x]}");
            }
            
            sc.WriteLine("");
            sc.Write("Make a selection: ");

            string input = sc.ReadLine();

            int entry = int.Parse(input);

            SelectedStore = Stores[entry];

            sc.WriteLine($"You entered: {SelectedStore}");
        }

        

        public static void GetCustomer() 
        {
        
            sc.WriteLine("");
            sc.Write("Please enter your name: ");
            string CustomerName = sc.ReadLine();

//             sc.WriteLine("Please enter your phone number: ");
//             string StreetAddress = sc.ReadLine();
// 
//             sc.WriteLine("Please enter your phone number");
//             string PhoneNumber = sc.ReadLine();

            NewCustomer = new Customer(CustomerName);

            sc.WriteLine("Customer name: " + NewCustomer.Name);

        }

        public static void CreateOrder() 
        {
            var order = new Order(NewCustomer.Name, SelectedStore.Name);   //This needs to be a public static var..

            var pizza = new Pizza();

            //Put the loop here for ordering pizzas.

        }

        public static void TakeOrder()
        {
            // WelcomeToPizzaBox();
            FindStore();
            GetCustomer();
            CreateOrder();
        }

    public static void WelcomeToPizzaBox()
        {
                   var arr = new[]
            {
                @"       Welcome to...",
                @"       ",
                @"        _______   ______  ________  ________   ______   _______    ______   __    __ ",
                @"       /       \ /      |/        |/        | /      \ /       \  /      \ /  |  /  |",
                @"       $$$$$$$  |$$$$$$/ $$$$$$$$/ $$$$$$$$/ /$$$$$$  |$$$$$$$  |/$$$$$$  |$$ |  $$ |",
                @"       $$ |__$$ |  $$ |      /$$/      /$$/  $$ |__$$ |$$ |__$$ |$$ |  $$ |$$  \/$$/ ",
                @"       $$    $$/   $$ |     /$$/      /$$/   $$    $$ |$$    $$< $$ |  $$ | $$  $$<  ",
                @"       $$$$$$$/    $$ |    /$$/      /$$/    $$$$$$$$ |$$$$$$$  |$$ |  $$ |  $$$$  \ ",
                @"       $$ |       _$$ |_  /$$/____  /$$/____ $$ |  $$ |$$ |__$$ |$$ \__$$ | $$ /$$  |",
                @"       $$ |      / $$   |/$$      |/$$      |$$ |  $$ |$$    $$/ $$    $$/ $$ |  $$ |",
                @"       $$/       $$$$$$/ $$$$$$$$/ $$$$$$$$/ $$/   $$/ $$$$$$$/   $$$$$$/  $$/   $$/ ",
                @"       ",
                @"                                       ___",
                @"                                        |  ~~--.",
                @"                                        |%=@%%/",
                @"                                        |o%%%/",
                @"                                     __ |%%o/",
                @"                               _,--~~ | |(_/ ._",
                @"                            ,/'  m%%%%| |o/ /  `\.",
                @"                           /' m%%o(_)%| |/ /o%%m `\",
                @"                         /' %%@=%o%%%o|   /(_)o%%% `\",
                @"                        /  %o%%%%%=@%%|  /%%o%%@=%%  \",
                @"                       |  (_)%(_)%%o%%| /%%%=@(_)%%%  |",
                @"                       | %%o%%%%o%%%(_|/%o%%o%%%%o%%% |",
                @"                       | %%o%(_)%%%%%o%(_)%%%o%%o%o%% |",
                @"                       |  (_)%%=@%(_)%o%o%%(_)%o(_)%  |",
                @"                        \ ~%%o%%%%%o%o%=@%%o%%@%%o%~ /",
                @"                         \. ~o%%(_)%%%o%(_)%%(_)o~ ,/",
                @"                           \_ ~o%=@%(_)%o%%(_)%~ _/",
                @"                             `\_~~o%%%o%%%%%~~_/'",
                @"                                `--..____,,--'",
                @"       ",
                @"       ",
                @"       "
                
            };

            sc.BackgroundColor = ConsoleColor.DarkRed;
            sc.ForegroundColor = ConsoleColor.Yellow;
            sc.WriteLine("\n\n");
            foreach(string line in arr )
                sc.WriteLine(line);
            sc.WriteLine("Press any key to begin.");
            sc.WriteLine("");
            sc.ReadKey();
        }
    }
}

