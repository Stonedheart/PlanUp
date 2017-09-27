using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PlanUp.Controllers.Api;
using PlanUp.Converters;
using PlanUp.Models;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace PlanUp.Controllers
{
    public class MovieController : Controller
    {
        private PropositionController _propositionController = new PropositionController();

        public ActionResult Index()
        {
            var propArray = _propositionController.ListOfPropositions;
            IEnumerable<Movie> newArray = propArray.OfType<Movie>().ToList();

            return View(newArray);
        }
    }
}