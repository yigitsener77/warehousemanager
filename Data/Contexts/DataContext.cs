using Core.Concretes.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Data.Contexts
{
    public class DataContext : IdentityDbContext<Employee>
    {
        //"name=warehouses": Bu satır bağlantı cümlesini (connectionString) web.config dosyasından okur. Bunun yerine bağlantı cümlesi direk yazılabilir.
        public DataContext() : base("server=localhost; database=warehouses; trusted_connection=true; trustservercertificate=true;")
        {
        }

        public static DataContext Instance()
        {
            return new DataContext();
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Movement> Movements { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierProduct> SupplierProducts { get; set; }
    }
}
