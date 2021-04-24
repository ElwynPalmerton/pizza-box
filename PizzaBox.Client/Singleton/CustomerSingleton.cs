using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
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
 
        public static CustomerSingleton Instance
        {
            get{

                if (_instance == null)
                {
                    _instance = new CustomerSingleton();
                }
                return _instance;
            }
        }

        private CustomerSingleton()
        {
            if (Customers == null)
            {
                Customers = _fileRepository.ReadFromFile<List<Customer>>(_path);
            }
        }    

        // public bool AddCustomer(Customer customer, List<Customer> customers)
        public bool AddCustomer(Customer customer)
        {
            Customers.Add(customer);
          
            _fileRepository.WriteToFile<List<Customer>>(_path, Customers);

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