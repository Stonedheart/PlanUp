using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanUp.Models
{
    public class MusicModel
    {
//        public List<string> Videos { get; set; }
//        public List<string> Channels { get; set; }
        public List<PlayList> Playlists { get; set; }

        public MusicModel(List<PlayList> Playlists)
        {
            this.Playlists = Playlists;
        }

        public static List<string> GetGenreList()
        {
            return new List<string>
            {
                "metal",
                "industrial",
                "heavy metal",
                "hard rock",
                "classic rock",
                "rock",
                "indie",
                "funk",
                "punk",
                "hardcore",
                "metalcore",
                "post-punk",
                "80's synthpop",
                "country",
                "grunge",
                "Indie pop"
            };
        }
    }
}