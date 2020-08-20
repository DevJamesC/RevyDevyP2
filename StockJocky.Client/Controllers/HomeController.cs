using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockJocky.Client.Models;
using StockJocky.Domain.Models;

namespace StockJocky.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(UserViewModel userViewModel)
        {
            //remove once user constructor is in
            userViewModel.User = new User();
            userViewModel.User.Stocks = new List<Stock>();


            return View(userViewModel);
        }


            
        public IActionResult AuthenticateUser(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                //perform some logic in domain to confirm user exists and get the relevent info
                if (true) //if user exists
                {
                    userViewModel.User.Username=userViewModel.UserName;
                    //remove once stock getting logic is implimented
                    userViewModel.User.Stocks.Add(new Stock() { Symbol = "tst1", Price = 1, PercentChange = .1, Name = "Test One" });
                    userViewModel.User.Stocks.Add(new Stock() { Symbol = "tst2", Price = 2, PercentChange = .2, Name = "Test Two" });
                    userViewModel.User.Stocks.Add(new Stock() { Symbol = "tst3", Price = 3, PercentChange = .3, Name = "Test Three" });
                    //get user stocklist stocks, then...
                    return View("StockList", userViewModel);
                }
                else // if user does not exist
                {
                    return View("Index");
                }

            }
            else
            {
                return View("Index");
            }
        }

        public IActionResult AddStock(UserViewModel userViewModel)
        {
            //perform logic to find SymbolAdd as a stock, and add it to User's Stocklist
            userViewModel.User.Username=userViewModel.UserName;
            return View("StockList",userViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult StockList()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
