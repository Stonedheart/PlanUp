using System.Collections.Generic;
using PlanUp.Models;
using TMDbLib.Objects.Lists;

namespace PlanUp.Controllers
{
    public class PropositionController
    {
        public AbstractHomeEvent FirstProposition;
        public AbstractHomeEvent SecondPropostion;
        public AbstractHomeEvent ThirdProposition;
        public List<AbstractHomeEvent> listOfPropositions;
    }
}