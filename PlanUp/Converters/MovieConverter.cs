using System;
using PlanUp.Models;
using DatabaseMovie = TMDbLib.Objects.Movies.Movie;

namespace PlanUp.Converters
{
    public class MovieConverter
    {
        public Movie Convert(DatabaseMovie movieToConvert)
        {
            if (movieToConvert.Runtime != null)
            {
                var resultMovie =
                    new Movie(movieToConvert.Title,
                        movieToConvert.ReleaseDate.ToString(),
                        movieToConvert.PosterPath, (int) movieToConvert.Runtime);

                return resultMovie;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}