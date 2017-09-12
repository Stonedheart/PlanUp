using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanUp.Controllers
{
    public class HomeActivityController : Controller
    {

        private static bool GenerateRandom()
        {
            var random = new Random();
            var ans = random.Next(0, 2);
            return ans == 0;
        }
            // GET: HomeActivity
            public ActionResult Index()
        {
            if (GenerateRandom())
                return RedirectToAction("Index", "Music");
            return RedirectToAction("Index", "Movie");
            
            
            
        }
    }
}