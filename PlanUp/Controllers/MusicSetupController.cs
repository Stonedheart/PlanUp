using System;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using PlanUp.Converters;
using PlanUp.Models;


namespace PlanUp.Controllers
{
    public class MusicSetupController
    {
        private string Genre { get; set; }
        private YouTubeService YoutubeService { get; set; }
        private const string ApiKey = "AIzaSyDkMyIyaZSKaBdaKhbdCt1YSPxGG2ewoII";
        private readonly MusicConverter _musicConverter;
        private static Random _random;
        private const int Seed = 3;
        private const int SongsQuantity = 50;

        public MusicSetupController(string genre="")
        {
            if (genre == "")
                genre = ChooseGenre();
            Genre = genre;
            _musicConverter = new MusicConverter();
        }

        public void SetConnection()
        {
            YoutubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = ApiKey,
                ApplicationName = this.GetType().ToString()
            });
        }

        public async Task<Song[]> RunAsync()
        {
            SetConnection();
            var searchListRequest = YoutubeService.Search.List("snippet");
            searchListRequest.Q = Genre; 
            searchListRequest.MaxResults = SongsQuantity;
            var searchListResponse = await searchListRequest.ExecuteAsync();
            return _musicConverter.Convert(searchListResponse);
        }


        private static string ChooseGenre()
        {
            var musicGenres = MusicViewModel.GetGenreList();
            if (_random == null)
                _random = new Random(Seed);
            var index = _random.Next(musicGenres.Count);
            return musicGenres[index];
        }
    }
}