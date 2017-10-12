using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using PlanUp.Models;

namespace PlanUp.Controllers
{
    public class MusicController : Controller
    {
        ApplicationDbContext _context;

        public MusicController()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var query = Request["genre"];
                var musicSetup = new MusicSetupController(query);
                var task = musicSetup.RunAsync();
                var result = await task;
                return View(result);
            }
            catch (AggregateException ex)
            {
                 Console.WriteLine("Error: " + ex.Message);
            }
            return Redirect("Index");
        }


    }
}
