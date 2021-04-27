using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using System.Text;
using System.Linq;


namespace PizzaBox.Client.Singletons
{

    public class CrustSingleton
    {
        private readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"data/crusts.xml";

        public List<Crust> Crusts;
        private readonly PizzaBoxContext _context;

        private static CrustSingleton _instance;
 
        public static CrustSingleton Instance(PizzaBoxContext context)
        {
            if (_instance == null)
            {
                _instance = new CrustSingleton(context);
            }
            return _instance;
        }

        private CrustSingleton(PizzaBoxContext context)
        {
            _context = context;
            Crusts = _context.Crust.ToList();
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