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
        public AbstractHomeEvent FirstProposition { get; }
        public AbstractHomeEvent SecondPropostion { get; }
        public AbstractHomeEvent ThirdProposition { get; }
        public List<AbstractHomeEvent> ListOfPropositions { get; set; }

        public PropositionController()
        {
            apiController = new ApiMovieController();
            ListOfPropositions = 
                new List<AbstractHomeEvent>() {FirstProposition, SecondPropostion, ThirdProposition};
            SetAll();
        }

        void SetOne(int index)
        {
            _converter = new MovieConverter(apiController.GetNextMovie());
            if (ListOfPropositions.Count > index) ListOfPropositions[index] = _converter.Convert();
        }
        
        void SetAll()
        {
            for (int i = 0; i < ListOfPropositions.Count; i++)
            {
                SetOne(i);
            }
        }
    }
}