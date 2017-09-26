using System.Collections.Generic;
using System.Linq;
using Microsoft.Ajax.Utilities;
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

        private bool CheckIfUnique()
        {
            bool isUnique = ListOfPropositions.DistinctBy(s => s.Title).Count().Equals(ListOfPropositions.Count);
            return isUnique;
        }
        
        void SetOne(int index)
        {
            var movie = apiController.GetNextMovie();
            _converter = new MovieConverter(movie);
            if (ListOfPropositions.Count > index) ListOfPropositions[index] = _converter.Convert();
            if (!CheckIfUnique())
            {
                SetOne(index);
            }
        }
        
        internal void SetAll()
        {
            for (int i = 0; i < ListOfPropositions.Count; i++)
            {
                SetOne(i);
            }
        }
    }
}