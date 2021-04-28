using PizzaBox.Domain.Abstracts;    //What do the dots mean?
using sc = System.Console;
using PizzaBox.ConsoleDisplay;
using System.Text.RegularExpressions;

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
            
            Match match;
            Regex regex = new Regex(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$");
            
            do
            {
            this.PhoneNumber = UIDisplay.GetUserInfo("Please enter your phone#: ");
            match = regex.Match(this.PhoneNumber);
            
            if (!match.Success) UIDisplay.InvalidEntry(this.PhoneNumber);
            
            } while (!match.Success);
        }

        public override string ToString()
        {
            return $"{Name} - {Address} -  {PhoneNumber}";
        }  
    }
}

