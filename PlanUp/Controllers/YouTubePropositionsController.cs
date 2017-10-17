using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PlanUp.Converters;
using PlanUp.Factories;
using PlanUp.Models;
using PlanUp.Models.YouTubePropositions;

namespace PlanUp.Controllers
{
    public class YouTubePropositionsController : Controller
    {
        private YouTubePropositionsFactory _factory;
        private YouTubeSearchResultConverter _converter;
        private YoutubeApiController _apiController;

        public YouTubePropositionsController()
        {
            _factory = new YouTubePropositionsFactory();
            _converter = new YouTubeSearchResultConverter();
            _apiController = new YoutubeApiController();
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                _apiController.SetConnection();

                //NOT COOL - ABSTRACT GENERATING RANDOM HIGHER AND FOR WIDER USAGE
                Array propositionTypes = Enum.GetValues(typeof(YoutubePropositionType));
                Random random = new Random();
                YoutubePropositionType randomPropositionType = (YoutubePropositionType)propositionTypes.GetValue(random.Next(propositionTypes.Length));


                var query = randomPropositionType;
                var model = await _apiController.GetPropositionFromYouTube(query.ToString().ToLower());
 
                return View(model);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return Redirect("Index");
        }
    }
}