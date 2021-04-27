using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using System.Text;
using System.Linq;


namespace PizzaBox.Client.Singletons
{

    public class SizeSingleton
    {
        private readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"data/sizes.xml";

        public List<Size> Sizes;

        private static SizeSingleton _instance;

        private static PizzaBoxContext _context;
 
        public static SizeSingleton Instance(PizzaBoxContext context)
        {
                if (_instance == null)
                {
                    _instance = new SizeSingleton(context);
                }
                return _instance;
        }

        private SizeSingleton(PizzaBoxContext context)
        {
            _context = context;
            Sizes = _context.Size.ToList();
        }    
    }
}