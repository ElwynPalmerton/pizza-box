using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using System.Text;

namespace PizzaBox.Client.Singletons
{

    public class StoreSingleton
    {
        private const string _path = @"data/stores.xml";
        private readonly FileRepository _fileRepository = new FileRepository();
        
        private readonly PizzaBoxContext _context;
        public List<AStore> Stores {get;}

        public List<string> StoreStrings = new List<string>();
        private static StoreSingleton _instance;
        public static StoreSingleton Instance(PizzaBoxContext context)
        {
            if (_instance == null)
            {
                _instance = new StoreSingleton(context);
            }
            return _instance;
        }

        private StoreSingleton(PizzaBoxContext context)
        {
            if (Stores == null)
            {
                _context = context;
                Stores = _context.Stores.ToList();
            }
        }

        public List<string> ToStringList()
        {
            foreach (AStore s in Stores)
            {
                StoreStrings.Add(s.Name);
            }
            return StoreStrings;
        }
    }
}








