using System.Collections.Generic;
using Google.Apis.YouTube.v3.Data;
using PlanUp.Models;

namespace PlanUp.Controllers
{
    class MusicConverter
    {
        public IEnumerable<Song> Convert(SearchListResponse searchListResponse)
        {
            var songs = new Song[3];

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            
            for (var i = 0; i < songs.Length; i++)
            {
                var song = new Song(searchListResponse.Items[i].Snippet.Title,
                    searchListResponse.Items[i].Id.VideoId,
                    searchListResponse.Items[i].ETag);
                songs[i] = song;
            }
            return songs;
        }
    }
}