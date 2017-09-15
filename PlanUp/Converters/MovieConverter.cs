using System;
using System.Linq;
using PlanUp.Models;
using DatabaseMovie = TMDbLib.Objects.Movies.Movie;

namespace PlanUp.Converters
{
    public class MovieConverter
    {
        private DatabaseMovie _movieToConvert;

        public MovieConverter(DatabaseMovie movieToConvert)
        {
            if (movieToConvert.Title == null)
            {
                throw new NullReferenceException("Movie to convert wasn't initialized properly.");
            }

            _movieToConvert = movieToConvert;
        }

        private Movie SetBaseMovie()
        {
            var resultMovie =
                new Movie(_movieToConvert.Title,
                    _movieToConvert.ReleaseDate.ToString(),
                    _movieToConvert.PosterPath);
            return resultMovie;
        }

        private void SetAdditionalInfo(Movie movieToSet)
        {
            if (_movieToConvert.Runtime != null)
            {
                var director = _movieToConvert.Credits.Crew.SingleOrDefault(i => i.Job.ToLower() == "director");
                movieToSet.Director = director.ToString();
                movieToSet.Genre = _movieToConvert.Genres[0].Name;
                movieToSet.Year = _movieToConvert.ReleaseDate.ToString();
            }
            else
            {
                throw new NullReferenceException("There's not runtime!");
            }
        }

        public Movie Convert()
        {
            var movie = SetBaseMovie();
            SetAdditionalInfo(movie);

            return movie;
        }
    }
}