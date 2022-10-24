using Microsoft.EntityFrameworkCore;

namespace CRM_Task_API.Models
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
        { 
        
        }
        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Order>().Property(p => p.GrandTotal).HasComputedColumnSql("[subtotal] - [tax] ");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set; }
        public DbSet<CustomerProduct> CustomerProducts  { get; set; }


    }
}
