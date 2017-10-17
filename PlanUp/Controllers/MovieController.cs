using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PlanUp.Models;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace PlanUp.Controllers
{
    public class MovieController : Controller
    {
        public static TMDbClient Client = new TMDbClient("e7a445aaa97ddc684c2404b990fb7087");
        public static List<SearchMovie> MovieList = Client.GetMovieTopRatedListAsync().Result.Results;

        // GET: Movie
        public ActionResult Index()
        {
            var model = Converter();

            return View(model);
        }

        internal static Movie[] Converter()
        {
            Movie[] movieArray = new Movie[3];
            var randomNumber = HomeActivityController.GenerateRandom(MovieList.Count);


            for (int i = 0; i < 3; i++)
            {
                var slotMovie = MovieList[randomNumber];
                Movie movie;
                try
                {
                    var release = (DateTime) slotMovie.ReleaseDate;
                    movie = new Movie(slotMovie.Title, release.ToString("MMMM dd, yyyy"), slotMovie.PosterPath);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    movie = new Movie(slotMovie.Title, null, slotMovie.PosterPath);
                }
                movieArray[i] = movie;
            }

            return movieArray;
        }
    }
}