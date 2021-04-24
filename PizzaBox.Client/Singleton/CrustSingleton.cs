using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using System.Text;


namespace PizzaBox.Client.Singletons
{

    public class CrustSingleton
    {
        private readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"data/crusts.xml";

        public List<Crust> Crusts;

        private static CrustSingleton _instance;
 
        public static CrustSingleton Instance
        {
            get{

                if (_instance == null)
                {
                    _instance = new CrustSingleton();
                }
                return _instance;
            }
        }

        private CrustSingleton()
        {
            if (Crusts == null)
            {
                Crusts = new List<Crust>{
                    new Crust(){Name="Thin", Price=0.00M},
                    new Crust(){Name="Sicilian", Price=4.00M},
                    new Crust(){Name="Stuffed Crust", Price=5.50M},
                };

                _fileRepository.WriteToFile<List<Crust>>(_path, Crusts);

                // Crusts = _fileRepository.ReadFromFile<List<Crust>>(_path);
            }
        }    

        public string ViewAll()
        {
            var stringBuilder = new StringBuilder();
            var separator = "\n";

            foreach (var item in Crusts)
            {
                stringBuilder.Append($"{item.MenuString()} {separator}");
            }

            return stringBuilder.ToString();
        }
    }
}