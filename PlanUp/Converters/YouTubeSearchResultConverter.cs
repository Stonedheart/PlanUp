using System;
using Google.Apis.YouTube.v3.Data;
using PlanUp.Models;

namespace PlanUp.Converters
{
    public class YouTubeSearchResultConverter
    {
        public AbstractYouTubeVideoProposition[] propositions = new AbstractYouTubeVideoProposition[3];
        private YouTubePropositionsFactory factory = new YouTubePropositionsFactory();
        private Random _random;
        private const int Quantity = 50;

        public void Convert(SearchListResponse searchListResponse)
        {
            for (var i = 0; i < propositions.Length; i++)
            {
                var searchResult = searchListResponse.Items[GetRandomIndex(Quantity)];
                var title = searchResult.Snippet.Title;
                if (!CheckIfPropositionInList(title))
                {
                    factory.SearchResult = searchResult;
                    propositions[i] = factory.Create(YoutubePropositionType.Tutorial);
                }
            }
//            return propositions;
        }

        private bool CheckIfPropositionInList(string title)
        {
            foreach (var proposition in propositions)
            {
                if (proposition != null && proposition.Title == title)
                {
                    return true;
                }
            }
            return false;
        }
    
        private int GetRandomIndex(int count)
        {
            if (_random == null)
                _random = new Random();
            return _random.Next(count);
        }
    }
}