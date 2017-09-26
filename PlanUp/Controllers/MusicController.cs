using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using PlanUp.Models;

namespace PlanUp.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music
        public async Task<ActionResult> Index()
        {
            try
            {
                Task<MusicModel> task = RunAsync();
                MusicModel result = await task;
                return View(result);
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            return Redirect("Index");

        }

        private async Task<MusicModel> RunAsync()
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDkMyIyaZSKaBdaKhbdCt1YSPxGG2ewoII",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            
            searchListRequest.Q = ChooseGenre(); // Replace with your search term.
            searchListRequest.MaxResults = 3;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<PlayList> playlists = new List<PlayList>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                var playlist = new PlayList(searchResult.Snippet.Title,
                    searchResult.Id.VideoId,
                    searchResult.ETag);
                playlists.Add(playlist);
            }
            return new MusicModel(playlists);
//
//            Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
//            Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
//            Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));            
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
