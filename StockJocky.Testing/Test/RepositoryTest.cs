using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockJocky.Domain.Factory;
using StockJocky.Domain.Models;
using StockJocky.Storing;
using StockJocky.Storing.Repositories;
using Xunit;

namespace StockJocky.Testing
{
	public class RepositoryTest
	{
		 StockFactory sf = new StockFactory();

		public StockDbContext InitDbContext()
		{
			DbContextOptionsBuilder OptionsBuilder = new DbContextOptionsBuilder<StockDbContext>();
			OptionsBuilder.UseSqlServer("Server=stockjockydb.database.windows.net;database=StockJockey;User ID=sadmin;Password=Password123;");
			return new StockDbContext(OptionsBuilder.Options);
		}

		[Fact]
        public void StockRepoTest()
        {
            var init =  InitDbContext();
			var sut = new StockRepository(init);
            Assert.NotNull(sut);
        }

		[Fact]
        public void UserRepoTest()
        {
            var init =  InitDbContext();
			var sut = new UserRepository(init);
            Assert.NotNull(sut);
        }

		// [Fact]
        // public void LoginUserTest()
        // {
        //     var init =  InitDbContext();
		// 	var sut = new UserRepository(init);
		// 	var actual = sut.LoginUser("testuser", "p123");
        //     Assert.Equal("testuser", actual.Username);
        // }
		
		// [Fact]
		// public void AddUserTest()
        // {
        //     var init =  InitDbContext();
		// 	var sut = new UserRepository(init);
		// 	var UserToRemove = sut.LoginUser("testuser", "p123");
		// 	init.Users.Remove(UserToRemove);
		// 	init.SaveChanges(); //Delete current test user.

		// 	var actual = sut.LoginUser("testuser", "p123"); //Since testuser does not exist, it will be created.
        //     Assert.Equal("testuser", actual.Username); //Test to see if user is created.
        // }

		// [Fact]
		// public async Task AddStockTest()
		// {
		// 	ApiHelper.InitializeClient();

		// 	var init =  InitDbContext();
		// 	var ur = new UserRepository(init);
		// 	var sr = new StockRepository(init);

		// 	var user = ur.LoginUser("testuser", "p123");
		// 	Stock stock = await sf.LoadStock("amzn");
		// 	sr.AddStock(user, stock); //sut, Add Stock

		// 	var newuser = ur.LoginUser("testuser", "p123");
		// 	var newstock = newuser.Stocks.Find(s => s.Symbol == "AMZN");
			

		// 	Assert.Equal("AMZN", newstock.Symbol);
		// }

		// [Fact]
		// public async Task RemoveStockTest()
		// {
		// 	ApiHelper.InitializeClient();

		// 	var init =  InitDbContext();
		// 	var ur = new UserRepository(init);
		// 	var sr = new StockRepository(init);

		// 	var user = ur.LoginUser("testuser", "p123");
		// 	Stock stock = await sf.LoadStock("amzn");
		// 	sr.AddStock(user, stock); 

		// 	var newuser = ur.LoginUser("testuser", "p123");
		// 	sr.RemoveStock(newuser, stock);

		// 	newuser = ur.LoginUser("testuser", "p123");
		// 	var newstock = newuser.Stocks.Find(s => s.Symbol == "AMZN");
		// 	Assert.Null(newstock);
		// }
	}	
}