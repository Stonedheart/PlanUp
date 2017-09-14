using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Configuration;
using System.Web.Mvc;
using PlanUp.Models;
using TMDbLib.Client;
using TMDbLib.Objects.Search;
using DatabaseMovie = TMDbLib.Objects.Movies.Movie;

namespace PlanUp.Controllers.Api
{
    public class ApiMovieController : IApi
    {
        internal string ApiKey {get;set;}
        internal TMDbClient Client;
        internal DatabaseMovie TmdbMovie;
        internal Movie Proposition { get; set; }

        public ApiMovieController(string apiKey="e7a445aaa97ddc684c2404b990fb7087")
        {
            ApiKey = apiKey;
            SetConnection(apiKey);
        }

        public void  SetConnection(string newKey)
        {
            Client = new TMDbClient(newKey);
        }

        public void Convert()
        {
            throw new NotImplementedException();
        }

        public object GetPropostition()
        {
            SetDefaultProposition();
            return Proposition;
        }

        public int GetRandomNumber()
        {
            var random = new Random(99999);

            return random.Next();

        }

        public DatabaseMovie GetDatabaseMovie(int? id)
        {
            var movieId = id ?? GetRandomNumber();
            if (id > 99999)
            {
                throw new InvalidOperationException("Id should not be greater than 99999!");
            }
            var result = Client.GetMovieAsync(movieId).Result;

            return result;
        }

        public void SetDatabaseMovie()
        {
            var movie = GetDatabaseMovie(GetRandomNumber());
            TmdbMovie = movie;
        }

        public Movie Convert(DatabaseMovie tmdbMovie)
        {
            var resultMovie = new Movie(tmdbMovie.Title, tmdbMovie.ReleaseDate.ToString(), tmdbMovie.PosterPath);

            return resultMovie;
        }

        public void SetDefaultProposition()
        {
            Proposition = Convert(GetDatabaseMovie(GetRandomNumber()));
        }


//        internal static Movie[] Converter()
//        {
//            var movieArray = new Movie[3];
//            var random = new Random();
//
//
//            for (var i = 0; i < 3; i++)
//            {
//                var slotMovie = MovieList[random.Next(MovieList.Count)];
//                Movie movie;
//                try
//                {
//                    var release = (DateTime) slotMovie.ReleaseDate;
//                    movie = new Movie(slotMovie.Title, release.ToString("MMMM dd, yyyy"), slotMovie.PosterPath);
//                }
//                catch (InvalidOperationException e)
//                {
//                    Console.WriteLine(e.Message);
//                    movie = new Movie(slotMovie.Title, null, slotMovie.PosterPath);
//                }
//                movieArray[i] = movie;
//            }
//
//            return movieArray;
//        }
    }
}