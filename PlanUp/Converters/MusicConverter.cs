using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.YouTube.v3.Data;
using PlanUp.Controllers;
using PlanUp.Models;

namespace PlanUp.Converters
{
    internal class MusicConverter
    {
        private const int SongsQuantity = 50;
        private bool _isSongInList;

        public Song[] Convert(SearchListResponse searchListResponse)
        {
            var songs = new Song[3];
            for(var i=0; i<songs.Length; i++)
            {
                var randomNumber = HomeActivityController.GenerateRandom(SongsQuantity);
                var searchResult = searchListResponse
                    .Items[randomNumber];
                var title = searchResult.Snippet.Title;
                CheckTitleInSongList(songs, title);
                if (_isSongInList)
                    continue;
                songs[i] = new Song(title, searchResult.Id.VideoId,
                searchResult.Snippet.Description);
            }
            return songs;
        }

        private void CheckTitleInSongList(Song[]songs, string title)
        {
            foreach (var song in songs)
            {
                if (song != null)
                {
                    if (song.Title == title)
                        _isSongInList = true;
                    else
                    {
                        _isSongInList = false;
                    }
                }
            }
            
        }
    }
}