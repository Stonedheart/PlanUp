using Google.Apis.YouTube.v3.Data;
using PlanUp.Models;
using PlanUp.Models.YouTubePropositions;

namespace PlanUp.Factories
{
    public class YouTubePropositionsFactory
    {
        public SearchResult SearchResult { get; set; } 

        public AbstractYouTubeVideoProposition Create(YoutubePropositionType type)
        {
            switch (type)
            {
                case YoutubePropositionType.Aerobic:
                    return new Aerobic(SearchResult.Snippet.Title, SearchResult.Id.VideoId, SearchResult.Snippet.Description);

                case YoutubePropositionType.Audiobook:
                    return new Audiobook(SearchResult.Snippet.Title, SearchResult.Id.VideoId, SearchResult.Snippet.Description);

                case YoutubePropositionType.Cardio:
                    return new Cardio(SearchResult.Snippet.Title, SearchResult.Id.VideoId, SearchResult.Snippet.Description);

                case YoutubePropositionType.Concert:
                    return new Concert(SearchResult.Snippet.Title, SearchResult.Id.VideoId, SearchResult.Snippet.Description);

                case YoutubePropositionType.Festival:
                    return new Festival(SearchResult.Snippet.Title, SearchResult.Id.VideoId, SearchResult.Snippet.Description);

                case YoutubePropositionType.Tutorial:
                    return new Tutorial(SearchResult.Snippet.Title, SearchResult.Id.VideoId, SearchResult.Snippet.Description);
            }
            return null;
        }
    }
}