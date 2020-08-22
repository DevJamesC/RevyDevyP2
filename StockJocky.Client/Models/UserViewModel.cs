using Microsoft.AspNetCore.Mvc;
using StockJocky.Domain.Factory;
using StockJocky.Domain.Models;

namespace StockJocky.Client.Models
{
    public class UserViewModel
    {
       public User User { get; set; }

        public string UserName {get; set;}
        public string Password { get; set; }
       public string SymbolAdd {get; set;}

       public string SymbolRemove{get; set;}

       public UserViewModel()
       {
           //User = new UserFactory().Create();
       }
    }
}