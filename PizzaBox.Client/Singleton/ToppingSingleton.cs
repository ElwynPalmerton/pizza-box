using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using System.Text;
using System.Linq;


namespace PizzaBox.Client.Singletons
{
    public class ToppingSingleton
    {
        private readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"data/toppings.xml";

        public List<Topping> Toppings;

        // public List<string> ToppingStringList = new List<string>();

        private static ToppingSingleton _instance;
        private readonly PizzaBoxContext _context;
 
        public static ToppingSingleton Instance(PizzaBoxContext context)
        {
                if (_instance == null)
                {
                    _instance = new ToppingSingleton(context);
                }
                return _instance;
        }

        private ToppingSingleton(PizzaBoxContext context)
        {
                _context = context;
                Toppings = _context.Toppings.ToList();
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
            }
            return ToppingStringList;
        }
    }
}