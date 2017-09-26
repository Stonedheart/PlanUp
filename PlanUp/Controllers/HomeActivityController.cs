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

        private static int GenerateRandom()
        {
            var random = new Random();
            var ans = random.Next(0, 3);
            return ans;
        }
            // GET: HomeActivity
            public ActionResult Index()
            {
            var opt = GenerateRandom();
            if (opt == 0)
            {
                return RedirectToAction("Index", "Music");
            }
            if (opt == 1)

                return RedirectToAction("Index", "Movie");

            if (opt == 2)

                return RedirectToAction("Index", "HomeEvents");

            return null;
        }
       }
}