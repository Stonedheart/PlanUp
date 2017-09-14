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
        private TMDbClient _client;
        private DatabaseMovie _tmdbMovie;

        public ApiMovieController(string apiKey = "e7a445aaa97ddc684c2404b990fb7087")
        {
            SetConnection(apiKey);
        }

        public void SetConnection(string newKey)
        {
            _client = new TMDbClient(newKey);
        }

        private int GetRandomNumber()
        {
            var random = new Random(99999);

            return random.Next();
        }

        internal DatabaseMovie GetDatabaseMovie(int? id)
        {
            var movieId = id ?? GetRandomNumber();
            if (id > 99999)
            {
                throw new InvalidOperationException("Id should not be greater than 99999!");
            }
            var result = _client.GetMovieAsync(movieId).Result;

            return result;
        }

        internal void SetDatabaseMovie()
        {
            var movie = GetDatabaseMovie(GetRandomNumber());
            _tmdbMovie = movie;
        }

        internal DatabaseMovie GetNextMovie()
        {
            SetDatabaseMovie();
            return _tmdbMovie;
        }
    }
}