﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PlanUp.Converters;
using PlanUp.Factories;
using PlanUp.Models;
using PlanUp.Models.YouTubePropositions;

namespace PlanUp.Controllers
{
    public class YouTubePropositionsController : Controller
    {
        private YouTubePropositionsFactory _factory;
        private YouTubeSearchResultConverter _converter;
        private YoutubeApiController _apiController;

        public YouTubePropositionsController()
        {
            _factory = new YouTubePropositionsFactory();
            _converter = new YouTubeSearchResultConverter(_factory);
            _apiController = new YoutubeApiController(_converter);
        }
    }
}