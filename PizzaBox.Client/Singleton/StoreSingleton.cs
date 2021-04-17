using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{

    public class StoreSingleton
    {


        private static readonly List<AStore> _stores = new List<AStore>()
        {
            new ChicagoStore(),
            new NewYorkStore(),
        };
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