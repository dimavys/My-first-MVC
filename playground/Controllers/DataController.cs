using System.Linq;
using Microsoft.AspNetCore.Mvc;
using playground.Data;
using playground.Models;

namespace playground.Controllers
{
    public class DataController : Controller
    {
        public static int RepKey;

        private AppDbContext appDbContext;

        public DataController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("Data/Insertion")]
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
                t.RepositoryId = RepKey;
                appDbContext.Tasks.Add(t);
                appDbContext.SaveChanges();
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
            var check = appDbContext.Tasks.Where(x => x.RepositoryId == RepKey && x.Id >= 1).FirstOrDefault();
            if (check != null)
            {
                var tmp = appDbContext.Tasks.Where(x => x.RepositoryId == RepKey).ToList();  
                return View("~/Views/Home/ListAdded.cshtml", tmp); // value cannot be null
            }
            else
                return View("~/Views/Home/AddingData/Insertion.cshtml");
        }


        [HttpGet]
        [Route("Data/Transfer")]
        public ViewResult Transfer(int id)
        {
            RepKey = id;
            var check = appDbContext.Tasks.Where(x => x.RepositoryId == id && x.Id >= 1).FirstOrDefault();
            if (check != null)
            {
                return View("~/Views/Home/AddingData/ToList.cshtml"); 
            }
            else
                return View("~/Views/Home/MyView.cshtml");
        }

    }

}