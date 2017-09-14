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

        public Movie Convert(DatabaseMovie movieToConvert)
        {
            if (movieToConvert.Runtime != null)
            {
                var resultMovie =
                    new Movie(movieToConvert.Title,
                        movieToConvert.ReleaseDate.ToString(),
                        movieToConvert.PosterPath, (int) movieToConvert.Runtime);

                var director = movieToConvert.Credits.Crew.Where(i => i.Job.ToLower() == "director");
                resultMovie.Director = director.ToString();
                resultMovie.Genre = movieToConvert.Genres[0].Name;
                resultMovie.Year = movieToConvert.ReleaseDate.ToString();

                return resultMovie;
            }
            else
            {
                throw new NullReferenceException("There's not runtime!");
            }
        }
    }
}