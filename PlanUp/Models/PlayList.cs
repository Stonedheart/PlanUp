using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;

namespace PlanUp.Models
{
    public class PlayList
    {
        public string Title { get; set; }
        public string PlayListId { get; set; }
        public string Etag { get; set; }

        public PlayList(string title, string playListId, string etag)
        {
            Title = title;
            PlayListId = playListId;
            Etag = GetEtag(playListId);
        }

      

        private string GetEtag(string etag)
        {
            return "https://www.youtube.com/embed/"+etag + "?controls=0";
        }
    }
}