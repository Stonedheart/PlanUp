namespace PlanUp.Models
{
    public class AbstractYouTubeVideoProposition
    {
        public string Title { get; }
        public string Etag { get; }
        public string Description { get; }

        public AbstractYouTubeVideoProposition(string title, string id, string description)
        {
            Title = title;
            Etag = GetEtag(id);
            Description = description;
        }

        protected string GetEtag(string etag)
        {
            return "https://www.youtube.com/embed/" + etag + "?controls=0";
        }
    }
}