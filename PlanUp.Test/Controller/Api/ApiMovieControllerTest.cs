using System;
using NUnit.Framework;
using PlanUp.Controllers;
using PlanUp.Controllers.Api;

namespace PlanUp.Test
{
    [TestFixture]
    public class ApiMovieControllerTests
    {
        private ApiMovieController _testController;
        
        [Test]
        public void TestIfConstructorSetsProperly()
        {
            _testController = new ApiMovieController();
            Assert.NotNull(_testController.Client.ApiKey);
        }

        [Test]
        [Repeat(5)]
        public void TestIfControllerSpitsOutMovie()
        {
            _testController = new ApiMovieController();
            Assert.NotNull(_testController.GetNextMovie().Title);
        }

        [Test]
        public void TestIfControllerSetsRuntime()
        {
            _testController = new ApiMovieController();
            var runtime = _testController.GetNextMovie().Runtime.Value;
            Assert.True(runtime.Equals(0));
        }
    }
}