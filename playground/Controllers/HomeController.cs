using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using playground.Models;

namespace playground.Controllers
{
    public class HomeController : Controller
    {
        public static string key;

        public ViewResult Index()
        {
            return View("StartPage");
        }

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
                var tmp = ListUsers.users.Find(x => x.nickname == r.nickname);
                if (tmp != null)
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
                var tmp = ListUsers.users.Find(x => x.nickname == r.nickname);
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

        [HttpGet]
        public ViewResult Insertion()
        {
            return View("~/Views/Home/AddingData/Insertion.cshtml");
        }

        [HttpPost]
        public ViewResult Insertion(Models.Task t)
        {
            if (ModelState.IsValid)
            {
                var tmp = ListUsers.users.Find(x => x.nickname == key);
                tmp.tasks.Add(t);
                return View("~/Views/Home/AddingData/Added.cshtml", t);
            }
            else
            {
                return View("~/Views/Home/AddingData/Insertion.cshtml");
            }
            
        }

        public ViewResult ListAdded()
        {
            var tmp = ListUsers.users.Find(x => x.nickname == key);
            return View(tmp.Tasks);
        }

        


        //[HttpGet]
        //public ViewResult Deletion()
        //{
        //    return View();
        //}

        public ViewResult Deletion(Models.Task t)
        {
            var tmp = ListUsers.users.Find(x => x.nickname == key);
            tmp.Destroy(t.name);
            return View("~Views/Home/DeletingData/Deleted.cshtml",t);
        }

        //[HttpGet]
        //public ViewResult Edition()
        //{
        //    return View();
        //}



    }
}
