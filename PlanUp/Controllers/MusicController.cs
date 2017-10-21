using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using PlanUp.Models;
using PlanUp.RejectedPropositionModel;


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

        [HttpPost]
        public void SaveRejectedToDatabase(Song[] modelData)
        {
            foreach (var item in modelData)
            {
                var rejected = new RejectedProposition
                {
                    Title = item.Title,
                    Tag = item.Etag
                };
                _context.RejectedPropositions.Add(rejected);
                _context.SaveChanges();
            }                        
        }
    }
}
