using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using System.Text;


namespace PizzaBox.Client.Singletons
{

    public class SizeSingleton
    {
        private readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"data/sizes.xml";

        public List<Size> Sizes;

        private static SizeSingleton _instance;
 
        public static SizeSingleton Instance
        {
            get{

                if (_instance == null)
                {
                    _instance = new SizeSingleton();
                }
                return _instance;
            }
        }

        private SizeSingleton()
        {
            if (Sizes == null)
            {
//                 Sizes = new List<Size>{
//                     new Size(){Name="Small", Price=15.00M},
//                     new Size(){Name="Medium", Price=20.00M},
//                     new Size(){Name="Large", Price=25.00M},
//                 };
// 
//                 _fileRepository.WriteToFile<List<Size>>(_path, Sizes);

                Sizes = _fileRepository.ReadFromFile<List<Size>>(_path);
            }
        }    

//         public string ViewAll()
//         {
//             var stringBuilder = new StringBuilder();
//             var separator = "\n";
// 
//             foreach (var item in Sizes)
//             {
//                 stringBuilder.Append($"{item.MenuString()} {separator}");
//             }
// 
//             return stringBuilder.ToString();
//         }
    }
}