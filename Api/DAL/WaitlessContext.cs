using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL
{
    public class WaitlessContext : DbContext
    {
        public DbSet<Call> Call { get; set; }
        public DbSet<Configuration> Configuration { get; set; }
        public DbSet<ConfigurationValue> ConfigurationValue { get; set; }
        public DbSet<Itemtyp> Itemtyp { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderPos> OrderPos { get; set; }
        public DbSet<Submenu> Submenu { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Tablet> Tablet { get; set; }
    }
}
