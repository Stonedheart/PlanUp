using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using PlanUp.Models;
using TMDbLib.Objects.Lists;

namespace PlanUp.Controllers
{
    public class MusicSetupController
    {
        private string _genre { get; set; }

        public MusicSetupController(string genre="")
        {
            if (genre == "")
                genre = ChooseGenre();
            _genre = genre;

        }

        private YouTubeService _youtubeService { get; set; }
        private string _apiKey = "AIzaSyDkMyIyaZSKaBdaKhbdCt1YSPxGG2ewoII";
        private MusicConverter musicConverter = new MusicConverter();

        public void SetConnection()
        {
            _youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _apiKey,
                ApplicationName = this.GetType().ToString()
            });
        }

        

        public object GetPropostition()
        {
            throw new NotImplementedException();
        }

        public async Task<MusicModel> RunAsync()
        {
            SetConnection();
            var searchListRequest = _youtubeService.Search.List("snippet");
            searchListRequest.Q = _genre; // Replace with your search term.
            searchListRequest.MaxResults = 3;
            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();
            
            return musicConverter.Convert(searchListResponse);
        }


        private static string ChooseGenre()
        {
            var MusicGenres = MusicModel.GetGenreList();
            Random rnd = new Random();
            int index = rnd.Next(MusicGenres.Count);
            return MusicGenres[index];
        }
    }
}