using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstAppMVC.Models;
using Microsoft.AspNetCore.Http;
namespace FirstAppMVC.Controllers
{
    public class HomeController : Controller
    {


        public static List<User> users = new List<User>(){
            new User(){UserId=1,Username="Admin",Password="123",RoleId=1}
           ,new User(){UserId=1,Username="User",Password="123",RoleId=2}
        };

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ViewBag.Username = null;
            if (HttpContext.Session.GetString("Username")!=null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
            }
            
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

         public IActionResult LoginForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (user == null)
            {
                return RedirectToAction("LoginForm"); 
            }

            if (CheckLogin(user) == null)
            {
                 return RedirectToAction("LoginForm"); 
            }

            AddUserToSession(CheckLogin(user));

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("RoleId");
            
            return RedirectToAction("Index");
        }

        void AddUserToSession(User user){
            HttpContext.Session.SetString("Username",user.Username);
            HttpContext.Session.SetString("RoleId",user.RoleId.ToString());
        }  

        User CheckLogin(User user){
            foreach (var item in users)
            {
                if (user.Username == item.Username && user.Password== item.Password)
                {
                    return item;
                }
            }
            return null;
        }
        public IActionResult TestService()
        {
            
            return View();
        }
    }
}
