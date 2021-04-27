using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using System.Linq;
using PizzaBox.Storing.Repositories;
using sc = System.Console;
using System.Text;


namespace PizzaBox.Client.Singletons
{

    public class CustomerSingleton
    {
        private readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"data/customers.xml";

        public List<Customer> Customers;


        private static CustomerSingleton _instance;
        private readonly PizzaBoxContext _context;
 
        public static CustomerSingleton Instance (PizzaBoxContext context)
        {
            if (_instance == null)
                {
                    _instance = new CustomerSingleton(context);
                }
                return _instance;

        }

        private CustomerSingleton(PizzaBoxContext context)
        {
            _context = context;
            Customers = _context.Customers.ToList();
        }    

        // public bool AddCustomer(Customer customer, List<Customer> customers)
        public bool AddCustomer(Customer customer)
        {
            Customers.Add(customer);

                _context.Customers.Add(customer);
                _context.SaveChanges();
              
                // _fileRepository.WriteToFile<List<Customer>>(_path, Customers);

            return true;

        }

        public string ViewAll()
        {
            var stringBuilder = new StringBuilder();
            var separator = "\n";

            foreach (var item in Customers)
            {
                stringBuilder.Append($"{item.ToString()} {separator}");
            }

            return stringBuilder.ToString();
        }
    }
}