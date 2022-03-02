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
    public class HomeController : Controller
    {
        public static string key;
       
        //private AppDbContext appDbContext;

        //public HomeController(AppDbContext appDbContext)
        //{
        //    this.appDbContext = appDbContext;
        //}

        public ViewResult Index()
        {
            //appDbContext.Tasks.Add
            return View("StartPage");
        }
    }
}
