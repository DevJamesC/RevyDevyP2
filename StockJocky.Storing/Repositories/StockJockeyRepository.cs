using StockJocky.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StockJocky.Storing.Repositories
{
	public class StockJockyRepository
	{
		private StockDbContext _db;

		public StockJockyRepository(StockDbContext context) 
		{
      		_db = context;
    	}
	}
}