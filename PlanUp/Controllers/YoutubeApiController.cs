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
        private YouTubeService _youTubeService;
        private readonly YouTubeSearchResultConverter _youTubeSearchResultConverter;

        public YoutubeApiController(YouTubeSearchResultConverter youTubeSearchResultConverter)
        {
            _youTubeSearchResultConverter = youTubeSearchResultConverter;
        }


        public void SetConnection(string apiKey = "AIzaSyDkMyIyaZSKaBdaKhbdCt1YSPxGG2ewoII")
        {
            _youTubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = this.GetType().ToString()
            });
        }


        public async Task<AbstractYouTubeVideoProposition[]> GetPropositionFromYouTube(string q, int maxResults = 50)
        {
            var searchListRequest = _youTubeService.Search.List("snippet");
            searchListRequest.Q = q;
            searchListRequest.MaxResults = maxResults;
            var searchListResponse = await searchListRequest.ExecuteAsync();
            _youTubeSearchResultConverter.Convert(searchListResponse);
            return _youTubeSearchResultConverter.propositions;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                SetConnection();
                var query = YoutubePropositionType.Tutorial;
                var result = await GetPropositionFromYouTube(query.ToString());
                var model = new Tutorial[3];
                for (var i = 0; i < model.Length; i++)
                {
                    model[i] = (Tutorial) result[i];
                }
                return View(model);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return Redirect("Index");
        }
    }
}