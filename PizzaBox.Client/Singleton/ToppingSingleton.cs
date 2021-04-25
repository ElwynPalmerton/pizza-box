using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using System.Text;


namespace PizzaBox.Client.Singletons
{

    public class ToppingSingleton
    {
        private readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"data/toppings.xml";

        public List<Topping> Toppings;

        // public List<string> ToppingStringList = new List<string>();

        private static ToppingSingleton _instance;
 
        public static ToppingSingleton Instance
        {
            get{

                if (_instance == null)
                {
                    _instance = new ToppingSingleton();
                }
                return _instance;
            }
        }

        private ToppingSingleton()
        {
            if (Toppings == null)
            {

//                 Toppings = new List<Topping>{
//                     new Topping(){Name="Pepperoni", Price=4.00M},
//                     new Topping(){Name="Peppers", Price=2.00M},
//                     new Topping(){Name="Spinach", Price=2.00M},
//                     new Topping(){Name="Anchovies", Price=2.00M},
//                     new Topping(){Name="Pinapple", Price=2.00M},
//                     new Topping(){Name="Ham", Price=4.00M},
//                     new Topping(){Name="Mushrooms", Price=2.00M},
//                     new Topping(){Name="Sausage", Price=2.00M},
//                 };
// 
//                 _fileRepository.WriteToFile<List<Topping>>(_path, Toppings);
                Toppings = _fileRepository.ReadFromFile<List<Topping>>(_path);
            }
        }    

        public string ViewAll()
        {
            var stringBuilder = new StringBuilder();
            var separator = "\n";

            foreach (var item in Toppings)
            {
                stringBuilder.Append($"{item.MenuString()} {separator}");
            }

            return stringBuilder.ToString();
        }

        public List<string> ToStringList()
        {
            List<string> ToppingStringList = new List<string>();
            
            foreach (Topping t in Toppings)
            {
                ToppingStringList.Add(t.Name);
                System.Console.WriteLine(t.Name);
            }
        
            return ToppingStringList;
        }
    }
}