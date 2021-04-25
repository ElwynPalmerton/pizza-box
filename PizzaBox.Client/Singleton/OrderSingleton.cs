using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using sc = System.Console;
using System.Text;


namespace PizzaBox.Client.Singletons
{

    public class OrderSingleton
    {
        private readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"data/orders.xml";

        public List<Order> Orders;

        private static OrderSingleton _instance;
 
        public static OrderSingleton Instance
        {
            get{

                if (_instance == null)
                {
                    _instance = new OrderSingleton();
                }
                return _instance;
            }
        }

        private OrderSingleton()
        {
            if (Orders == null)

        //Order includes:
        // public Customer Customer {get; set;}
        // public AStore Store {get; set;}
        // public APizza Pizza {get; set;}




            {
                var loc = new ChicagoStore();
                var jim = new Customer("Jim", "1 Jim Street", "111-222-3333");
                var jimsPizza = new CustomPizza();

                Orders = new List<Order>{
                    new Order(){Customer=jim, Store=loc, Pizza=jimsPizza},
                };

                _fileRepository.WriteToFile<List<Order>>(_path, Orders);

                Orders = _fileRepository.ReadFromFile<List<Order>>(_path);
            }
        }    

        // public bool AddCustomer(Customer customer, List<Customer> customers)
//         public bool AddOrder(Order order)
//         {
//             Orders.Add(order);
//           
//             _fileRepository.WriteToFile<List<Customer>>(_path, Orders);
// 
//             return true;
// 
//         }

        public string ViewAll()
        {
            var stringBuilder = new StringBuilder();
            var separator = "\n";

            foreach (var item in Orders)
            {
                stringBuilder.Append($"{item.ToString()} {separator}");
            }

            return stringBuilder.ToString();
        }
    }
}