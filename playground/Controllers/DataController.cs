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
	public class DataController : Controller
	{
        public static string key = AuthenticationController.key;

        [HttpGet]
        public ViewResult Insertion()
        {
            return View("~/Views/Home/AddingData/Insertion.cshtml");
        }

        [HttpPost]
        [Route("Data/Insertion")]
        public ViewResult Insertion(Models.Task t)
        {
            if (ModelState.IsValid)
            {
                var tmp = ListUsers.UserFinder(key);
                tmp.AddTask(t);
                return View("~/Views/Home/AddingData/Added.cshtml", t);
            }
            else
            {
                return View("~/Views/Home/AddingData/Insertion.cshtml");
            }

        }

        [HttpGet]
        [Route("Data/ListAdded")]
        public ViewResult ListAdded()
        {
            var tmp = ListUsers.UserFinder(key);
            return View("~/Views/Home/ListAdded.cshtml", tmp.Tasks);
        }
    }
}

