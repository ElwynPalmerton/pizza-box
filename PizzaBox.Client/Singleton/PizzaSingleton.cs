using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{

    public class PizzaSingleton
    {
        //Create the list of pizzas.
        //Create the variable for the instance.
        //Create the constructor.
        //Create the Instance method.

        public List<APizza> Pizzas;

        private static PizzaSingleton _instance;

        private PizzaSingleton()
        {
            if (Pizzas == null)
            {
                Pizzas = new List<APizza>{
                    new CustomPizza(),
                    new MeatPizza(),
                    new VeggiePizza(),
                };
            }
        }        

        public static PizzaSingleton Instance
        {
            get{

                if (_instance == null)
                {
                    _instance = new PizzaSingleton();
                }
                return _instance;
            }
        }
    }
}