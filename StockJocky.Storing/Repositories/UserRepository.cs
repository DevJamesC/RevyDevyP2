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

		public User LoginUser(string username, string password)
		{
			var user = _db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
			if (user.Username == username && user.Password == password)
			{
				return user;
			}
			else
			{
				AddUser(username, password);
				var newuser = _db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
				return newuser;
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