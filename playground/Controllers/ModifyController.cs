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
	public class ModifyController : Controller
	{
        public static string key = AuthenticationController.key;

        [HttpPost]
        [Route("Modify/Deletion")]
        public ViewResult Deletion(int id)
        {
            var tmp = ListUsers.UserFinder(key);
            var name = tmp.Finder(id);
            string nm = name.name;
            tmp.Destroy(id);
            var task = new Models.Task
            {
                name = nm
            };
            return View("~/Views/Home/DeletingData/Deleted.cshtml", task);
        }

        [HttpGet]
        [Route("Modify/Edition`")]
        public ViewResult Edition(int id)
        {
            var tmp = ListUsers.UserFinder(key);
            var task = tmp.Finder(id);
            return View("~/Views/Home/EditingData/Edition.cshtml", task);
        }

        [HttpPost]
        [Route("Modify/Edited")]
        public ViewResult Edited(Models.Task t)
        {
            var tmp = ListUsers.UserFinder(key);
            var task = tmp.Finder(t.id);
            tmp.FillUp(t, task);
            return View("~/Views/Home/ListAdded.cshtml", tmp.Tasks);
        }
    }
}

