using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;


namespace PizzaBox.Client.Singletons
{

    public class PizzaSingleton
    {
        private readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"data/pizzas.xml";

        public List<APizza> Pizzas;

        public List<string> PizzaStrings = new List<string>();

        private static PizzaSingleton _instance;
 
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

        private PizzaSingleton()
        {
            if (Pizzas == null)
            {
                // Pizzas = new List<APizza>{
                //     new CustomPizza(),
                //     new MeatPizza(),
                //     new VeggiePizza(),
                // };

                // _fileRepository.WriteToFile<List<APizza>>(_path, Pizzas);
                Pizzas = _fileRepository.ReadFromFile<List<APizza>>(_path);

            }
        }    

        public List<string> ToStringList()
        {
            foreach(APizza p in Pizzas)
            {
                PizzaStrings.Add(p.Name);
            }
            return PizzaStrings;
        }
    }
}