using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{

    public class PizzaBoxContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<AStore> Stores {get; set;}
        public DbSet<APizza> Pizzas {get; set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Size> Size {get; set;}

        public DbSet<Order> Orders {get; set;}
        
        //same as the serialization line: 
        //var xml = new XmlSerializer(typeof(T));

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_configuration["mssql"]);
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
            builder.Entity<ChicagoStore>().HasBaseType<AStore>();
            builder.Entity<NewYorkStore>().HasBaseType<AStore>();

            builder.Entity<APizza>().HasKey(e => e.EntityId);
            builder.Entity<CustomPizza>().HasBaseType<APizza>();
            builder.Entity<MeatPizza>().HasBaseType<APizza>();
            builder.Entity<VeggiePizza>().HasBaseType<APizza>();

            builder.Entity<Crust>().HasKey(e => e.EntityId);
            builder.Entity<Size>().HasKey(e => e.EntityId);
            builder.Entity<Topping>().HasKey(e => e.EntityId);

            builder.Entity<Order>().HasKey(e => e.EntityId);
            builder.Entity<Customer>().HasKey(e => e.EntityId);

            builder.Entity<ChicagoStore>().HasData(new ChicagoStore[]
            {
                new ChicagoStore() {EntityId = 1, Name = "Chitown Main Street"} 
            });

            builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
            {
                new NewYorkStore() {EntityId = 2, Name= "Big Apple"}
            });

            builder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer(){
                    EntityId = 1, 
                    Name = "Uncle John",
                    Address = "100 Uncle John Street",
                    PhoneNumber = "888-888-JOHN"
                }
            });

            builder.Entity<Crust>().HasData(new Crust[]{
                new Crust(){
                    EntityId=1,
                    Name="Thin",
                    Price=1.00M,
                },
                new Crust(){
                    EntityId=2,
                    Name="Thick",
                    Price=2.00M,
                },
                  new Crust(){
                    EntityId=3,
                    Name="Stuffed",
                    Price=4.00M,
                },
            });

            builder.Entity<Size>().HasData(new Size[]{
                new Size(){
                    EntityId=1,
                    Name="Small",
                    Price=15.00M,
                },
                new Size(){
                    EntityId=2,
                    Name="Medium",
                    Price=20.00M,
                },
                new Size(){
                    EntityId=3,
                    Name="Large",
                    Price=25.00M,
                }
            });

            builder.Entity<Topping>().HasData(new Topping[]{
                new Topping(){
                    EntityId=1,
                    Name="Pepperoni",
                    Price=4.00M,
                },  
                new Topping(){
                    EntityId=2,
                    Name="Peppers",
                    Price=2.00M,
                },
                new Topping(){
                    EntityId=3,
                    Name="Spinach",
                    Price=4.00M,
                },  
                new Topping(){
                    EntityId=4,
                    Name="Anchovies",
                    Price=3.00M,
                },

                new Topping(){
                    EntityId=5,
                    Name="Pineapple",
                    Price=3.00M,
                },  
                new Topping(){
                    EntityId=7,
                    Name="Ham",
                    Price=5.00M,
                },  
                new Topping(){
                    EntityId=8,
                    Name="Mushrooms",
                    Price=2.00M,
                },  
                new Topping(){
                    EntityId=9,
                    Name="Sausage",
                    Price=5.00M,
                },  
            });
// 
//             builder.Entity<APizza>().HasData(new APizza[]{
//                 new CustomPizza(){
//                     EntityId=1,
//                     Name="Custom Pizza",
//                     Price=4.00M,
//                 },  
//                 new MeatPizza(){
//                     EntityId=2,
//                     Name="Meat Lover's Extravaganza",
//                     Price=4.00M,
//                 },  
//                 new VeggiePizza(){
//                     EntityId=1,
//                     Name="Veggie Delight",
//                     Price=4.00M,
//                 },  
//             });
        }
    }
}

