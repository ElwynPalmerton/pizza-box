using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using sc = System.Console;
//using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Domain.Abstracts{

    [XmlInclude(typeof(CustomPizza))]   
    [XmlInclude(typeof(MeatPizza))]
    [XmlInclude(typeof(VeggiePizza))]

  public abstract class APizza : AModel 
  {
    public string Name;
    public Crust Crust {get; set;}
    public long CrustId {get; set;}
    public Size Size {get; set;}
    public long SizeId {get; set;}
    public List<Topping> Toppings {get; set;}
    public decimal Price {get; set;}

    protected APizza()
    {
      Factory();
    }

    protected void Factory()
    {
      AddName();
      AddCrust();
      AddSize();
      AddToppings();
    }

    protected abstract void AddName();
    protected abstract void AddCrust();
    protected abstract void AddSize();
    protected abstract void AddToppings();

    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      var separator = ", ";

      foreach (var item in Toppings)
      {
        stringBuilder.Append($"{item}{separator}");
      }

      decimal price = this.ComputePrice();

      return $"{Crust}\t\t- {Size} \t\t- {stringBuilder.ToString().TrimEnd(separator.ToCharArray())} - ${price}";
   
    }  

    public static string Headings()
    {
      return $"Crust\t\t- Size\t\t\t- Toppings";
    }

    public decimal ComputePrice()
    {
      decimal totalPrice = 0.00M;

      totalPrice += Size.Price;
      totalPrice += Crust.Price;

      foreach (Topping t in Toppings)
      {
        totalPrice += t.Price;
      }
      
      return totalPrice;
    }

    public List<string> ToppingStrings()
    {
      List<string> toppingStrings = new List<string>();

      foreach (Topping t in Toppings)
      {
        toppingStrings.Add(t.Name);
      }
      // sc.WriteLine("ToppingStrings - length: " + toppingStrings.Count);


      return toppingStrings;

      
    }
  }
}