using System.Collections.Generic;
using PlanUp.Controllers.Api;
using PlanUp.Converters;
using PlanUp.Models;
using TMDbLib.Objects.Lists;

namespace PlanUp.Controllers
{
    public class PropositionController
    {
        private ApiMovieController apiController;
        private MovieConverter _converter;
        public AbstractHomeEvent FirstProposition { get; set; }
        public AbstractHomeEvent SecondPropostion { get; set; }
        public AbstractHomeEvent ThirdProposition { get; set; }
        public List<AbstractHomeEvent> listOfPropositions { get; set; }

        public PropositionController()
        {
            apiController = new ApiMovieController();
            listOfPropositions = 
                new List<AbstractHomeEvent>() {FirstProposition, SecondPropostion, ThirdProposition};
        }

        void SetAll()
        {
            for (int i = 0; i < listOfPropositions.Count; i++)
            {
                _converter = new MovieConverter(apiController.GetNextMovie());
                listOfPropositions[i] = _converter.Convert();
            }
        }
    }
}