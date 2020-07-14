using Microsoft.EntityFrameworkCore;
using server.Model;

namespace server.Entity
{
    public class OrderDbContext : DbContext, IOrderDbContext
    {
        public OrderDbContext()
        { }

        public OrderDbContext(DbContextOptions<OrderDbContext> contextOptions) :base(contextOptions)
        {
        
            Database.EnsureCreated();
        }

        public DbSet<LinkOrder> LinkOrder { get; set; }

        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(new Order { OrderId = 1, CategoryId = 1 },
                new Order { OrderId = 2, CategoryId = 2 },
                new Order { OrderId = 3, CategoryId = 1 },
                new Order { OrderId = 4, CategoryId = 3 },
                new Order { OrderId = 5, CategoryId = 2 });
           
            

        }

    }

   
}
