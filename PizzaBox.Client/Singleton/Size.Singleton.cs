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
        private const string _path = @"data/toppings.xml";

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
                // Sizes = new List<Size>{
                //     new Size(){Name="Teensy-weensy", Price=0.01M},
                //     new Size(){Name="Teeny-tiny", Price=1.00M},
                //     new Size(){Name="Tiny", Price=1.00M},
                //     new Size(){Name="Very Small", Price=1.00M},
                //     new Size(){Name="Small", Price=15.00M},
                //     new Size(){Name="Medium Small", Price=17.50M},
                //     new Size(){Name="Medium", Price=20.00M},
                //     new Size(){Name="Medium Large", Price=22.00M},
                //     new Size(){Name="Large", Price=25.00M},
                //     new Size(){Name="Extra Large", Price=25.00M},
                //     new Size(){Name="Extra Extra Large", Price=30.00M},
                //     new Size(){Name="Huge", Price=40.00M},
                //     new Size(){Name="Giant", Price=50.00M},
                //     new Size(){Name="Ginormo", Price=75.00M},
                //     new Size(){Name="Collossal", Price=100.00M},
                //     new Size(){Name="Gigundo", Price=200.00M},
                //     new Size(){Name="Preposterously Ginormous", Price=500.00M},
                //     new Size(){Name="Guiness Book of World Records Record Setter", Price=100000.00M},
                // };

                // _fileRepository.WriteToFile<List<Size>>(_path, Sizes);

                Sizes = _fileRepository.ReadFromFile<List<Size>>(_path);
            }
        }    

        public string ViewAll()
        {
            var stringBuilder = new StringBuilder();
            var separator = "\n";

            foreach (var item in Sizes)
            {
                stringBuilder.Append($"{item.MenuString()} {separator}");
            }

            return stringBuilder.ToString();
        }
    }
}