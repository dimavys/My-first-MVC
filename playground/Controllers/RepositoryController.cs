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
	public class RepositoryController : Controller
	{
        private AppDbContext appDbContext;

        public RepositoryController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public static int UserKey = AuthenticationController.UserKey;

        public static int RepKey;

        [HttpGet]
        [Route("Repository/ListRepository")]
        public ViewResult ListRepository()
        {
            UserKey = AuthenticationController.UserKey;
            var check = appDbContext.Repositories.Where(x => x.UserId == UserKey && x.Id >= 1).FirstOrDefault();
            if (check != null)
            {
                var tmp = appDbContext.Repositories.Where(x => x.UserId == UserKey).ToList();
                return View("~/Views/Home/Repository/ListRepository.cshtml", tmp);
            }
            else
                return View("~/Views/Home/Repository/InsertionRep.cshtml");
        }

        [HttpGet]
        public ViewResult Insertion()
        {
            return View("~/Views/Home/Repository/InsertionRep.cshtml");
        }

        [HttpPost]
        [Route("Repository/Insertion")]
        public ViewResult Insertion(Repository r)
        {
            UserKey = AuthenticationController.UserKey;
            if (ModelState.IsValid)
            {
                r.UserId = UserKey;
                appDbContext.Repositories.Add(r);
                appDbContext.SaveChanges();
                return View("~/Views/Home/Repository/InsertedRep.cshtml");
            }
            else
            {
                return View("~/Views/Home/Repository/InsertionRep.cshtml");
            }

        }

        [HttpPost]
        [Route("Repository/Deleted")]
        public ViewResult Deletion(int id)
        {
            var temp = appDbContext.Repositories.Where(x => x.Id == id).FirstOrDefault();
            appDbContext.Repositories.Remove(temp);
            var tmp = appDbContext.Tasks.Where(x => x.RepositoryId == id).ToList();
            appDbContext.Tasks.RemoveRange(tmp);
            appDbContext.SaveChanges();
            return View("~/Views/Home/Repository/DeletedRepository.cshtml");
        }

        [HttpGet]
        [Route("Repository/Edition")]
        public ViewResult Edition(int id)
        {
            var temp = appDbContext.Repositories.Where(x => x.Id == id).FirstOrDefault();
            return View("~/Views/Home/Repository/EditRepository.cshtml",temp);
        }

        [HttpPost]
        [Route("Repository/Edited")]
        public ViewResult Edited(Repository r)
        {
            var temp = appDbContext.Repositories.Where(x => x.Id == r.Id).FirstOrDefault();
            temp.Name = r.Name;
            appDbContext.SaveChanges();
            var tmp = appDbContext.Users.Where(x => x.Id == UserKey).FirstOrDefault();
            return View("~/Views/Home/Repository/EditedRepository.cshtml");
        }
    }
}

