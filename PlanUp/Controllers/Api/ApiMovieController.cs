﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PlanUp.Models;
using TMDbLib.Client;
using TMDbLib.Objects.Search;

namespace PlanUp.Controllers.Api
{
    public class ApiMovieController : IApi
    {
        internal string ApiKey;
        internal static TMDbClient Client;
        internal Movie PickedMovie;

        public ApiMovieController(string apiKey, TMDbClient client)
        {
            ApiKey = apiKey;
            Client = new TMDbClient("e7a445aaa97ddc684c2404b990fb7087");
        }

        public static IEnumerable<SearchMovie> MovieList = Client.GetMovieTopRatedListAsync().Result.Results;

        
        public void SetConnection()
        {
        }

        public void Convert()
        {
            throw new System.NotImplementedException();
        }

        public object GetPropostition()
        {
            throw new System.NotImplementedException();
        }
        

        internal static Movie[] Converter()
        {
            var movieArray = new Movie[3];
            var random = new Random();


            for (var i = 0; i < 3; i++)
            {
                var slotMovie = MovieList[random.Next(MovieList.Count)];
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