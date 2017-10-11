namespace PlanUp.Models
{
    public class AbstractYouTubeVideoProposition
    {
        public string Title { get; }
        public string Etag { get; }
        public string Description { get; }

        public AbstractYouTubeVideoProposition(string title, string etag, string description)
        {
            Title = title;
            Etag = "https://www.youtube.com/embed/" + etag + "?controls=0";
            Description = description;
        }
    }
}