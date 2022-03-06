using System.Linq;
using Microsoft.AspNetCore.Mvc;
using playground.Data;
using playground.Models;

namespace playground.Controllers
{ 
    public class AuthenticationController : Controller
	{
        public static int UserKey;

        private AppDbContext appDbContext;

        public AuthenticationController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("Authentication/SignUp")]
        public ViewResult SignUp()
        {
            return View("~/Views/Home/SignUp/SignUp.cshtml");
        }

        [HttpPost]
        [Route("Authentication/SignUp")]
        public ViewResult SignUp(User r)
        {
            if (ModelState.IsValid)
            {
                var tmp = appDbContext.Users.Where(x => x.Nickname == r.Nickname).FirstOrDefault();
                if (tmp != null)
                {
                    return View("~/Views/Home/SignUp/Wrong.cshtml", r);
                }
                else
                {
                    appDbContext.Users.Add(r);
                    appDbContext.SaveChanges();
                    UserKey = r.Id;
                    return View("~/Views/Home/SignUp/SignedUp.cshtml", r);
                }
            }
            else
            {
                return View("~/Views/Home/SignUp/SignUp.cshtml");
            }

        }

        [HttpGet]
        [Route("Authentication/LogIn")]
        public ViewResult LogIn()
        {
            return View("Views/Home/LogIn/LogIn.cshtml");
        }

        [HttpPost]
        [Route("Authentication/LogIn")]
        public ViewResult LogIn(User r)
        {
            if (ModelState.IsValid)
            {
                var tmp = appDbContext.Users.Where(x => x.Nickname == r.Nickname).FirstOrDefault();
                if (tmp != null && tmp.Password == r.Password)
                {
                    UserKey = tmp.Id;
                    return View("Views/Home/Login/LoggedIn.cshtml", r);
                }
                else
                    return View("~/Views/Home/Login/NoUser.cshtml");
            }
            else
            {
                return View("Views/Home/LogIn/LogIn.cshtml");
            }
        }
    }
}

