using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using sc = System.Console;
using System.Text;
using System.Linq;


namespace PizzaBox.Client.Singletons
{

    public class OrderSingleton
    {
        private readonly PizzaBoxContext _context;
        private readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"data/orders.xml";

        public List<Order> Orders;

        private static OrderSingleton _instance;
 
        public static OrderSingleton Instance(PizzaBoxContext context)
        {
            if (_instance == null)
            {
                _instance = new OrderSingleton(context);
            }
            return _instance;
        }

        private OrderSingleton(PizzaBoxContext context)
        {
            
            _context = context;
            Orders = _context.Orders.ToList();
            
            Orders = _fileRepository.ReadFromFile<List<Order>>(_path);

        }    

        // public bool AddCustomer(Customer customer, List<Customer> customers)
        public bool AddOrder(Order order, PizzaBoxContext _context)    //???????
        {
            // _context = context;
            // Orders.Add(order);
            _context.Orders.Add(order);
            _context.SaveChanges();
              
                // _fileRepository.WriteToFile<List<Customer>>(_path, Customers);

            return true;

        }

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