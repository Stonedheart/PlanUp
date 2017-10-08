using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace PlanUp.Controllers
{
    public class YoutubeApiController : ApiController
    {

        public void SetConnection(string apiKey = "AIzaSyDkMyIyaZSKaBdaKhbdCt1YSPxGG2ewoII")
        {
            YouTubeService youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = this.GetType().ToString()
            });
        }
    }
}