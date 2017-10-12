using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;

namespace PlanUp.Models
{
    public class Song
    {
        public string Title { get; set; }
        public string Etag { get; set; }
        public string Description { get; set; }

        public Song() { }

        public Song(string title, string songId, string description)
        {
            Title = title;
            Etag = GetEtag(songId);
            Description = description;
        }

        private string GetEtag(string etag)
        {
            return "https://www.youtube.com/embed/"+etag + "?controls=0";
        }
    }
}