using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing
{

    public class PizzaBoxContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<AStore> Stores {get; set;}
        public DbSet<APizza> Pizzas {get; set;}
        
        //same as the serialization line: 
        //var xml = new XmlSerializer(typeof(T));

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("");
            //Same as the line with path in FileRepo-...
        }  

        public PizzaBoxContext()
        {
         _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
         //Do I need to configure the Secret.
        }

        //https://docs.microsoft.com/en-us/ef/core/modeling/
        
            protected override void OnModelCreating(ModelBuilder builder)
        {
            //Anything that we save to a database needs an index.
            builder.Entity<AStore>().HasKey(e => e.EntityId);
            builder.Entity<APizza>().HasKey(e => e.EntityId);
            // builder.Entity<Crust>().HasKey(e => e.EntityId);
            // builder.Entity<Customer>().HasKey(e => e.EntityId);
            // builder.Entity<Order>().HasKey(e => e.EntityId);
        }
    }
}

