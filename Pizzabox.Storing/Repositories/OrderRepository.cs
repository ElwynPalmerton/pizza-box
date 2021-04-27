using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
    //Instantiated and called in Program
    //_orderRepository.Create(order);       //After creating the order.
    public class OrderRepository
    {
        
        private readonly PizzaBoxContext _context;

        public OrderRepository(PizzaBoxContext context)
        {
            _context = context;
        }

        
        public void Create(Order order)
        {   
            // order.Store = _context.Stores.FirstOrDefault(s => s.Name == order.Store.Name);

            _context.Orders.Add(order);
            _context.SaveChanges();
        }

    }
}
