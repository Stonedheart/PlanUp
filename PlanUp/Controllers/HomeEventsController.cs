using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using PlanUp.Models;

namespace PlanUp.Controllers
{
    public class HomeEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            int dbSize = db.HomeEvents.Count();
            int randomNumber = HomeActivityController.GenerateRandom(dbSize);
            var model = from m in db.HomeEvents
                where m.Id.Equals(randomNumber)
                        select m;
            return View(model);
        }
    }
}
