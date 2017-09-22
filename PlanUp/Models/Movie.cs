namespace PlanUp.Models
{
    public class Movie : AbstractHomeEvent
    {
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }

        public Movie(string title, string year, string imagePath)
        {
            Title = title;
            Year = year;
            ImagePath = "https://image.tmdb.org/t/p/w320" + imagePath;
        }
    }
}