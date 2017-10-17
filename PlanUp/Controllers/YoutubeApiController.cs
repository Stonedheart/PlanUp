using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using PlanUp.Converters;
using PlanUp.Models;
using PlanUp.Models.YouTubePropositions;

namespace PlanUp.Controllers
{
    public class YoutubeApiController : Controller
    {
        private const string ApiKey = "AIzaSyDkMyIyaZSKaBdaKhbdCt1YSPxGG2ewoII";
        private YouTubeService _youTubeService;
        private readonly YouTubeSearchResultConverter _youTubeSearchResultConverter = new YouTubeSearchResultConverter();

        public void SetConnection()
        {
            _youTubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = ApiKey,
                ApplicationName = this.GetType().ToString()
            });
        }


        public async Task<AbstractYouTubeVideoProposition[]> GetPropositionFromYouTube(string query, int maxResults = 50)
        {
            var searchListRequest = _youTubeService.Search.List("snippet");
            searchListRequest.Q = query;
            searchListRequest.MaxResults = maxResults;
            var searchListResponse = await searchListRequest.ExecuteAsync();
            _youTubeSearchResultConverter.Convert(searchListResponse);
            return _youTubeSearchResultConverter.propositions;
        }
    }
}