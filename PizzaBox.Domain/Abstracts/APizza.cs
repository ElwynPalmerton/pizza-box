using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using sc = System.Console;
//using PizzaBox.Domain.Models.Pizzas;


namespace PizzaBox.Domain.Abstracts{

  public abstract class APizza : AModel 
  {

    public string Name;

    public Crust Crust {get; set;}
    public Size Size {get; set;}
    public List<Topping> Toppings {get; set;}

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

      return $"{Crust} - {Size} -  {stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
   
    }  
  }
}