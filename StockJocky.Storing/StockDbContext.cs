using Microsoft.EntityFrameworkCore;
using StockJocky.Domain.Models;

namespace StockJocky.Storing
{
  public class StockDbContext : DbContext
  {
    public DbSet<User> Users { get; set; } //create table
    public DbSet<Stock> Stocks { get; set; }

    public StockDbContext(DbContextOptions options) : base(options){} //dependency injection

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Stock>().HasKey(e => e.Id); //primary constraint
	  
  	  builder.Entity<User>().HasKey(e => e.Id);
      builder.Entity<User>().HasIndex(e => e.Username).IsUnique();
    }
  }
}