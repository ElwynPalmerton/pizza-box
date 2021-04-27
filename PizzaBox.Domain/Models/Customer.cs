using PizzaBox.Domain.Abstracts;    //What do the dots mean?
using sc = System.Console;
using PizzaBox.ConsoleDisplay;

namespace PizzaBox.Domain.Models

{
    public class Customer : AModel 
    {

        public string Name {get; set;}
        public string Address {get; set;}
        public string PhoneNumber {get; set;}

        public Customer(string name, string address, string phoneNumber)
        {
            // this.GetName();
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public Customer()
        {

        }
        public void GetCustomerInfo()
        {
            sc.Clear();
            UIDisplay.MenuTitle("Customer information: ");
            this.Name = UIDisplay.GetUserInfo("Please enter your name: ");
            this.Address = UIDisplay.GetUserInfo("Please enter your address: ");
            this.PhoneNumber = UIDisplay.GetUserInfo("Please enter your phone#: ");
        }

        public override string ToString()
        {
            return $"{Name} - {Address} -  {PhoneNumber}";
        }  
    }
}

