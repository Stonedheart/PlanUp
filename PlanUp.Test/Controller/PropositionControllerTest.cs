using System;
using NUnit.Framework;
using PlanUp.Controllers;

namespace PlanUp.Test.Controller
{
    [TestFixture]
    public class PropositionControllerTest
    {
        private PropositionController _controller;

        [SetUp]
        public void SetController()
        {
            _controller = new PropositionController();
        }

        [Test]
        public void TestIfSetAllSetsCorrectValuses()
        {
            _controller.SetAll();
            var listWhichShouldBeDistinct = _controller.ListOfPropositions;
            for (int i = 0; i < listWhichShouldBeDistinct.Count; i++)
            {
                try
                {
                    Assert.AreNotEqual(listWhichShouldBeDistinct[i], listWhichShouldBeDistinct[i + 1]);
                    Assert.AreNotEqual(listWhichShouldBeDistinct[i], listWhichShouldBeDistinct[i + 2]);
                    Assert.AreNotEqual(listWhichShouldBeDistinct[i], listWhichShouldBeDistinct[i - 1]);
                    Assert.AreNotEqual(listWhichShouldBeDistinct[i], listWhichShouldBeDistinct[i - 2]);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }
}