using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{

    public class StoreSingleton
    {
        private const string _path = @"data/stores.xml";
        private readonly FileRepository _fileRepository = new FileRepository();
        public List<AStore> Stores {get;}
        private static StoreSingleton _instance;
        public static StoreSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StoreSingleton();
                }
                return _instance;
            }
        }

        private StoreSingleton()
        {
            if (Stores == null)
            {
                Stores = _fileRepository.ReadFromFile<List<AStore>>(_path);

                //Stores = _context.Stores.ToList();
            }
        }
    }
}








