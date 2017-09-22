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
                switch (opt)
                {
                    case 0:
                        return RedirectToAction("Index", "Music");
                    case 1:
                        return RedirectToAction("Index", "Movie");
                    case 2:
                        return RedirectToAction("Index", "HomeEvents");
                }

                return null;


            }
       }
}