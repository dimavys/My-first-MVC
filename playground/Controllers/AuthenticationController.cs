using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using playground.Data;
using playground.Models;

namespace playground.Controllers
{
	public class AuthenticationController : Controller
	{
        public static string key;

        [HttpGet]
        public ViewResult SignUp()
        {
            return View("~/Views/Home/SignUp/SignUp.cshtml");
        }

        [HttpPost]
        public ViewResult SignUp(Repository r)
        {
            if (ModelState.IsValid)
            {
                if (ListUsers.UserFinder(r.nickname) != null)
                {
                    return View("~/Views/Home/SignUp/Wrong.cshtml", r);
                }
                else
                {
                    ListUsers.AddUser(r);
                    key = r.nickname;
                    return View("~/Views/Home/SignUp/SignedUp.cshtml", r);
                }
            }
            else
            {
                return View("~/Views/Home/SignUp/SignUp.cshtml");
            }

        }

        [HttpGet]
        public ViewResult LogIn()
        {
            return View("Views/Home/LogIn/LogIn.cshtml");
        }

        [HttpPost]
        public ViewResult LogIn(Repository r)
        {
            if (ModelState.IsValid)
            {
                var tmp = ListUsers.UserFinder(r.nickname);
                if (tmp != null && tmp.password == r.password)
                {
                    key = tmp.nickname;
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

