using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Configuration;
using System.Web.Mvc;
using PlanUp.Models;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;
using DatabaseMovie = TMDbLib.Objects.Movies.Movie;

namespace PlanUp.Controllers.Api
{
    public class ApiMovieController : IApi
    {
        public TMDbClient Client { get; set; }
        private DatabaseMovie _tmdbMovie;

        public ApiMovieController(string apiKey = "e7a445aaa97ddc684c2404b990fb7087")
        {
            SetConnection(apiKey);
        }

        public void SetConnection(string newKey)
        {
            Client = new TMDbClient(newKey);
        }

        internal SearchMovie GetSearchedMovie()
        {

            var result = Client.DiscoverMoviesAsync().
                IncludeAdultMovies().Query().Result.Results;

            return result[new Random().Next(result.Count)];
        }

        internal void SetDatabaseMovie()
        {
            int movieId = GetSearchedMovie().Id;
            var movie = Client.GetMovieAsync(movieId, MovieMethods.Credits ).Result;
            _tmdbMovie = movie;
        }

        internal DatabaseMovie GetNextMovie()
        {

            SetDatabaseMovie();
            return _tmdbMovie;
        }
        }
    }