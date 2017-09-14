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
        private ApiMovieController _movieController = new ApiMovieController();
        private MovieConverter _movieConverter;

        public ActionResult Index()
        {
            var movieArray = new Movie[3];
                
            for (var i = 0; i < movieArray.Length; i++)
            {
                var databaseMovie = _movieController.GetNextMovie();
                _movieConverter = new MovieConverter(databaseMovie);
                movieArray[i] = _movieConverter.Convert();

            }
            
            return View(movieArray);
        }
       
    }
}