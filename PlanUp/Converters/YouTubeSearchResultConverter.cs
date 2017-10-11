using System;
using Google.Apis.YouTube.v3.Data;
using PlanUp.Models;
using PlanUp.Models.YouTubePropositions;

namespace PlanUp.Converters
{
    public class YouTubeSearchResultConverter
    {
        public AbstractYouTubeVideoProposition[] propositions; 
        private YouTubePropositionsFactory _factory;
        private Random _random;
        private const int Quantity = 50; //NOT COOL - TO CHANGE;

        public YouTubeSearchResultConverter(YouTubePropositionsFactory factory)
        {
            _factory = factory;
            propositions = new AbstractYouTubeVideoProposition[3];
        }

        public void Convert(SearchListResponse searchListResponse)
        {
            for (var i = 0; i < propositions.Length; i++)
            {
                var searchResult = searchListResponse.Items[GetRandomIndex(Quantity)];
                var title = searchResult.Snippet.Title;
                if (!CheckIfPropositionInList(title))
                {
                    _factory.SearchResult = searchResult;
                    propositions[i] = _factory.Create(YoutubePropositionType.Tutorial);
                }
            }
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