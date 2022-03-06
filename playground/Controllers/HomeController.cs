using System.Linq;
using Microsoft.AspNetCore.Mvc;
using playground.Data;
using playground.Models;

namespace playground.Controllers
{
    public class HomeController : Controller
    {
        public static string key;
       
        private AppDbContext appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public ViewResult Index()
        {
            return View("StartPage");
        }
    }
}
