namespace PlanUp.Models
{
    public class Movie : AbstractHomeEvent
    {
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public string PosterPath { get; }
        public int Duration { get; set; }

        public Movie(string title, string year, string posterPath, int duration)
        {
            Title = title;
            Year = year;
            PosterPath = "https://image.tmdb.org/t/p/w320" + posterPath;
            Duration = duration;
        }
    }
}