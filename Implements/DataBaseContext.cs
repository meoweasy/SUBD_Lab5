using Implements.Models;
using Microsoft.EntityFrameworkCore;

namespace Implements
{
   public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-O76UPIGE\SQLEXPRESS01;Initial Catalog=laba5BDItog;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<City> Citys { set; get; }
        public virtual DbSet<Shop> Shops { set; get; }
        public virtual DbSet<Warehouses> Warehouses { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<Orders> Orders { set; get; }
    }
}
