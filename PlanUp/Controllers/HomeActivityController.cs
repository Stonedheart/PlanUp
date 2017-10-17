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

        public static int GenerateRandom(int optionsAmount)
        {
            var random = new Random();
            var result = random.Next(optionsAmount);
            return result;
        }
            // GET: HomeActivity
            public ActionResult Index()
            {
                var optionsAmount = 4;
                var opt = GenerateRandom(optionsAmount);
                if (opt == 0)
                
                    return RedirectToAction("Index", "Music");
                
                if (opt == 1)

                    return RedirectToAction("Index", "Movie");

                if (opt == 2)
                
                    return RedirectToAction("Index", "HomeEvents");
                if (opt == 3)

                    return RedirectToAction("Index", "YouTubePropositions");

                return null;
            }
       }
}