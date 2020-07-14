using Microsoft.EntityFrameworkCore;
using server.Model;

namespace server.Entity
{
    public interface IOrderDbContext
    {
        DbSet<LinkOrder> LinkOrder { get; set; }

        DbSet<Order> Order { get; set; }
        int SaveChanges();
    }
}
