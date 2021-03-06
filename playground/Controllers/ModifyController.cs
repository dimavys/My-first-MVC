using System.Linq;
using Microsoft.AspNetCore.Mvc;
using playground.Data;
using playground.Models;

namespace playground.Controllers
{
	public class ModifyController : Controller
	{
        private AppDbContext appDbContext;

        public ModifyController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpPost]
        [Route("Modify/Deletion")]
        public ViewResult Deletion(int id)
        {
            var tmp = appDbContext.Tasks.Where(x => x.Id == id).FirstOrDefault();
            appDbContext.Tasks.Remove(tmp);
            appDbContext.SaveChanges();
            return View("~/Views/Home/DeletingData/Deleted.cshtml");
        }

        [HttpGet]
        [Route("Modify/Edition/{id}")]
        public ViewResult Edition(int id)
        {
            var tmp = appDbContext.Tasks.Where(x => x.Id == id).FirstOrDefault();
            return View("~/Views/Home/EditingData/Edition.cshtml", tmp);
        }

        [HttpPost]
        [Route("Modify/Edited")]
        public ViewResult Edited(Models.Task t)
        {
            var tmp = appDbContext.Tasks.Where(x => x.Id == t.Id).FirstOrDefault();
            tmp.Name = t.Name;
            tmp.Desc = t.Desc;
            tmp.Deadline = t.Deadline;
            tmp.StartDate = t.StartDate;
            tmp.Prior = t.Prior;
            appDbContext.SaveChanges();
            return View("~/Views/Home/EditingData/Edited.cshtml");
        }
    }
}

