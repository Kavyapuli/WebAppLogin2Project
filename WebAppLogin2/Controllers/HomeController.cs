using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppLogin2.Models;

namespace WebAppLogin2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        List<User> userlist = new List<User>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            userlist.Add(new User { Username = "Kavya", Password = "kavya@123" });
            userlist.Add(new User { Username = "Kiran", Password = "kiran@123" });
            userlist.Add(new User { Username = "Kusuma", Password = "kusuma@123" });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User u)
        {
            var found = userlist.Find(f => ((f.Username == u.Username) && (f.Password == u.Password)));

            if (found != null)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            else
            {
                return View();
            }
        }


        public IActionResult Dashboard()
        {

            return View();
        }
        //[HttpPost]
        //public IActionResult Dashboard(FormCollection f)
        //{

        //    return RedirectToAction("Index");
        //}


        public IActionResult Privacy()
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
