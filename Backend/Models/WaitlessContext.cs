using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
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

    public WaitlessContext(DbContextOptions<WaitlessContext> options) 
      :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Call>();
      modelBuilder.Entity<Configuration>();
      modelBuilder.Entity<ConfigurationValue>();
      modelBuilder.Entity<Itemtyp>();
      modelBuilder.Entity<Order>();
      modelBuilder.Entity<OrderPos>();
      modelBuilder.Entity<Submenu>();
      modelBuilder.Entity<Table>();
      modelBuilder.Entity<Tablet>();
    }
  }
}
