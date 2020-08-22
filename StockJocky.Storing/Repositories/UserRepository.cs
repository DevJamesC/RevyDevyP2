using StockJocky.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StockJocky.Storing.Repositories
{
	public class UserRepository
	{
		private StockDbContext _db;

		public UserRepository(StockDbContext context) 
		{
      		_db = context;
    	}

		public User LoginUser(string username, string password) //General Purpose to get user information or register.
		{
			var user = _db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
			if (user == null) //If user does not exist.
			{
				AddUser(username, password);
				var newuser = _db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
				return newuser;
			}
			else //User exist
			{
				List<Stock> stocks = new List<Stock>();
				stocks = _db.Stocks.Where(s => s.Userid == user).ToList();
				if (stocks != null) //User has stocks .
				{
					user.Stocks = stocks; //Load user stocks.
				}
				return user;
			}		
		}

		public void AddUser(string username, string password)
		{
			User user = new User();
			user.Username = username;
			user.Password = password;

			_db.Users.Add(user);
			_db.SaveChanges();
		}
	}
}