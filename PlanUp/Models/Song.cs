using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;

namespace PlanUp.Models
{
    public class Song : AbstractYouTubeVideoProposition
    {
        public Song(string title, string etag, string description) : base(title, etag, description)
        {
        }
    }
}