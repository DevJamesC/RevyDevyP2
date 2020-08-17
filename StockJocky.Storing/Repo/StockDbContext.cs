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
      builder.Entity<Stock>().Property(e => e.Price).HasColumnType("decimal(10, 2)"); //Decimal Constraint
	  builder.Entity<Stock>().Property(e => e.PriceChange).HasColumnType("decimal(10, 2)"); 
      builder.Entity<Stock>().Property(e => e.PercentChange).HasColumnType("double(10, 2)"); 
	  
	  builder.Entity<User>().HasKey(e => e.Id);
	  builder.Entity<User>().Property(e => e.Balance).HasColumnType("decimal(10, 2)");
    }
  }
}