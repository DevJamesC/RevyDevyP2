using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockJocky.Client.Models;
using StockJocky.Domain.Factory;
using StockJocky.Domain.Models;
using StockJocky.Storing;

namespace StockJocky.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StockDbContext _db;

        public HomeController(ILogger<HomeController> logger, StockDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index(UserViewModel userViewModel)
        {
            if(userViewModel.User==null)
            {
                userViewModel.User= new UserFactory().Create();
            }
            return View(userViewModel);
        }



        public IActionResult AuthenticateUser(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {



                //userViewModel.User = GetOrAddUserByName(userViewModel.UserName);

                //remove once user constructor is in
                if(userViewModel.User==null)
                {
                    userViewModel.User= new UserFactory().Create();
                    userViewModel.User.Username=userViewModel.UserName;
                    
                }
                if (userViewModel.User.Stocks == null)
                {
                    userViewModel.User.Stocks = new List<Stock>();
                }

                //remove once stock getting logic is implimented
                    userViewModel.User.Stocks.Add(new Stock() { Symbol = "tst1", LatestPrice = 1, ChangePercent = .1, CompanyName = "Test One" });
                    userViewModel.User.Stocks.Add(new Stock() { Symbol = "tst2", LatestPrice = 2, ChangePercent = .2, CompanyName = "Test Two" });
                    userViewModel.User.Stocks.Add(new Stock() { Symbol = "tst3", LatestPrice = 3, ChangePercent = .3, CompanyName = "Test Three" });
                    //get user stocklist stocks, then...
                    return View("StockList", userViewModel);



            }
            else
            {
                return View("Index");
            }
        }


        public IActionResult AddStock(UserViewModel userViewModel)
        {
            //if(AddStockToUserByName(userViewModel.UserName,userViewModel.SymbolAdd)!)
            //{
                //ability to send some sort of notification "add failed"
           // }

            AddStockToUserByNameFromAPI(userViewModel.UserName,userViewModel.SymbolAdd);

            // rebuild user
            userViewModel.User= GetOrAddUserByName(userViewModel.UserName);

            return View("StockList", userViewModel);
        }

        public IActionResult RemoveStock(UserViewModel userViewModel)
        {

            if(userViewModel.User==null)
                {
                    userViewModel.User= new UserFactory().Create();
                    userViewModel.User.Username=userViewModel.UserName;
                    
                }
                if (userViewModel.User.Stocks == null)
                {
                    userViewModel.User.Stocks = new List<Stock>();
                }

            return View("StockList", userViewModel);
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







               //Gets user from Database (SHOULD BE IN STORING PROJECT, UNDER REPOSITORY)
        public User GetOrAddUserByName(string name)
        {

            var user = _db.Users.Where(u => u.Username == name).FirstOrDefault();
            if (user == null)
            {
                user = new User { Username = name };
                _db.Users.Add(user);
                _db.SaveChanges();
            }

            return user;
        }
        //Adds Stock to User (from database, no API interaction) (SHOULD BE IN STORING PROJECT, UNDER REPOSITORY)
        public bool AddStockToUserByName(string name, string symbol)
        {
            bool success = false;

            //get a reference to the stock with the target symbol.
            var stock = _db.Stocks.Where(s => s.Symbol == symbol).FirstOrDefault();
            //if the stock symbol entered exists, then check if the target user alreadly has a stock with the target symbol
            if (stock != null)
            {
                if (_db.Users.Where(u => u.Username == name).Where(u => u.Stocks.Contains(stock)).FirstOrDefault() == null)
                {//if the user with the target name does not have a stock with the target symbol, then add the stock to the users stocklist

                    var user = _db.Users.Where(u => u.Username == name).FirstOrDefault();
                    if (user != null)
                    {//final check to make sure uer is not null

                        if(user.Stocks==null)
                        {
                            user.Stocks=new List<Stock>();
                        }

                        user.Stocks.Add(stock);
                        _db.Update(user);
                        _db.SaveChanges();
                        success = true;
                    }
                }
            }


            return success;
        }

          public async void AddStockToUserByNameFromAPI(string name, string symbol)
        {

            //get a reference to the stock with the target symbol.
            var stock = await new StockFactory().LoadStock();

            //if the stock symbol entered exists, then check if the target user alreadly has a stock with the target symbol
            if (stock != null)
            {
                if (_db.Users.Where(u => u.Username == name).Where(u => u.Stocks.Contains(stock)).FirstOrDefault() == null)
                {//if the user with the target name does not have a stock with the target symbol, then add the stock to the users stocklist

                    var user = _db.Users.Where(u => u.Username == name).FirstOrDefault();
                    if (user != null)
                    {//final check to make sure uer is not null

                        if(user.Stocks==null)
                        {
                            user.Stocks=new List<Stock>();
                        }

                        user.Stocks.Add(stock);
                        _db.Update(user);
                        _db.SaveChanges();
                    }
                }
            }
        }
    }
}
