using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using PlanUp.Models;


namespace PlanUp.Controllers
{
    public class MusicController : Controller
    {
        private MusicSetupController msc;

        public MusicController()
        {
            
        }

        //private string getQuery()
        //{
        //    return Request["genre"];
        //}
        
        // GET: Music
        public async Task<ActionResult> Index()
        {
            try
            {
                var query = Request["genre"];
                msc = new MusicSetupController(query);
                var task = msc.RunAsync();
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
