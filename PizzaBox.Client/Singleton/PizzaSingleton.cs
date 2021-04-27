using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using System.Linq;
using PizzaBox.Storing.Repositories;


namespace PizzaBox.Client.Singletons
{

    public class PizzaSingleton
    {
        private readonly FileRepository _fileRepository = new FileRepository();
        private static PizzaSingleton _instance;
        private const string _path = @"data/pizzas.xml";

        private readonly PizzaBoxContext _context = new PizzaBoxContext();
        public List<APizza> Pizzas;

        public List<string> PizzaStrings = new List<string>();

        private PizzaSingleton(PizzaBoxContext context)
        {

            
//             _context = context;
//             Pizzas = _context.Pizzas.ToList();

            //Using the XML so it just gives the 3 base types.

            if (Pizzas == null)
            {
               Pizzas = _fileRepository.ReadFromFile<List<APizza>>(_path);
            }          
        }

        public static PizzaSingleton Instance(PizzaBoxContext context)
        {
            if (_instance == null)
                {
                    _instance = new PizzaSingleton(context);
                }
            return _instance;            
            
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


//        private PizzaSingleton(PizzaBoxContext context)
//         {
// //             _context = context;
// //             Pizzas = _context.Pizzas.ToList();
// 
//             //Using the XML so it just gives the 3 base types.
// 
//             if (Pizzas == null)
//             {
//                 // Pizzas = new List<APizza>{
//                 //     new CustomPizza(),
//                 //     new MeatPizza(),
//                 //     new VeggiePizza(),
//                 // };
//                 // _fileRepository.WriteToFile<List<APizza>>(_path, Pizzas);
//                Pizzas = _fileRepository.ReadFromFile<List<APizza>>(_path);
//             }          
//         }
