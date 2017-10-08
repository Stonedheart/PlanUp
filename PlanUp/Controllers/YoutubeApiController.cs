using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using TMDbLib.Objects.General;

namespace PlanUp.Controllers
{
    public class YoutubeApiController : ApiController
    {
        private YouTubeService _youTubeService;


        public void SetConnection(string apiKey = "AIzaSyDkMyIyaZSKaBdaKhbdCt1YSPxGG2ewoII")
        {
            _youTubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = this.GetType().ToString()
            });
        }


        public async Task<YouTubeProposition[]> GetPropositionFromYouTube(string q, int maxResults = 50)
        {
            var searchListRequest = _youTubeService.Search.List("snippet");
            searchListRequest.Q = q;
            searchListRequest.MaxResults = maxResults;
            var searchListResponse = await searchListRequest.ExecuteAsync();
            return _youTubeSearchResultConverter.Convert(searchListResponse);
        }
    }
}