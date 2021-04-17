using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{

    public class StoreSingleton
    {
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
                Stores = new List<AStore>
                {
                    new ChicagoStore(),
                    new NewYorkStore(),
                };
            }
        }
    }
}








