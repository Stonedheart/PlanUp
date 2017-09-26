using System.Collections.Generic;
using Google.Apis.YouTube.v3.Data;
using PlanUp.Models;

namespace PlanUp.Controllers
{
    class MusicConverter
    {
        public Song[] Convert(SearchListResponse searchListResponse)
        {
            Song[] songs = new Song[3];

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            var index = 0;
            foreach (var searchResult in searchListResponse.Items)
            {
                
                var song = new Song(searchResult.Snippet.Title,
                    searchResult.Id.VideoId,
                    searchResult.Snippet.Description);
                songs[index] = song;
                index++;
            }
            return songs;
        }
    }
}