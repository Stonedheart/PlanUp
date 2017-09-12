namespace PlanUp.Models
{
    public class Movie
    {
        public string Title { get; }
        public string Director { get;}
        public string Genre { get; }
        public string Year { get; }
        public string PosterPath { get; }
        public int Duration { get; }

        public Movie(string title, string year, string posterPath)
        {
            Title = title;
            Year = year;
            PosterPath = "https://image.tmdb.org/t/p/w320" + posterPath;
        }

    }
}