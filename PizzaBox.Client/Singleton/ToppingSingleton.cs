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
    }
}