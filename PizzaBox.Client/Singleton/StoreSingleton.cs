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
            }

            return _instance;
        }

         private StoreSingleton() {
            if (Stores == null)
            {
                Stores = Stores(){

                }
            }
        }



  }



//Then in the program file call StoreSingleton.stores in the foreach loop.

// foreach (AStore item in StoreSingleton.stores)



// 
// // serialize data to a file.
// 
// //1. Need a file to access.
// 
// var path = @"store.xml";
// 
// //2. Open the file3. 
// 
// var writer = new StreamWriter(path);
// 
// // 3. Convert the object to text
// 
// var xml = new XmlSerializer(typeof(List<AStore>));
// 
// // 4. Write text to the file.
// 
// xml.Serialize(writer, Stores);
//   
// // 5. Close the file.
// 
// writer.Close();

}