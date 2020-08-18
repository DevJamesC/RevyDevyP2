using StockJocky.Domain.Factory;
using StockJocky.Domain.Models;

namespace StockJocky.Client.Models
{
    public class UserViewModel
    {
       public User User { get; set; }

       public UserViewModel()
       {
           User = new UserFactory().Create();
       }

       public UserViewModel(User user)
       {
           User = user;
       }
    }
}