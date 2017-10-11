using Google.Apis.YouTube.v3.Data;

namespace PlanUp.Models
{
    public class YouTubePropositionsFactory
    {
        public SearchResult SearchResult { get; set; }

        public AbstractYouTubeVideoProposition Create(YoutubePropositionType type)
        {
            switch (type)
            {
                case YoutubePropositionType.Tutorial:
                    return new Tutorial(SearchResult.Snippet.Title, SearchResult.Id.VideoId, SearchResult.Snippet.Description);
            }
            return null;
        }
    }
}