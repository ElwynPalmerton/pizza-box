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

        // private readonly PizzaBoxContext _context;
        public List<APizza> Pizzas;

        public List<string> PizzaStrings = new List<string>();

        private PizzaSingleton(PizzaBoxContext context)
        {
            // _context = context;
            // Pizzas = _context.Pizzas.ToList();
            if (Pizzas == null)
            {            
                Pizzas = _fileRepository.ReadFromFile<List<APizza>>(_path);
            }
            // return Pizzas;
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
            PizzaStrings.Clear();
            foreach(APizza p in Pizzas)
            {
                PizzaStrings.Add(p.Name);
            }
            return PizzaStrings;
        }
    }
}
