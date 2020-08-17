using System.Collections.Generic;

namespace StockJocky.Domain.Models
{
    public class User
    {
        public string DisplayName { get; set; }

        public List<Stock> SelectedStocks { get; set; }

        public User()
        {
            DisplayName ="";
            SelectedStocks = new List<Stock>();
        }
    }
}