using System;
using NUnit.Framework;
using PlanUp.Controllers;

namespace PlanUp.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestIfArrayExist()
        {
            var movieArray = MovieController.Converter();
            Assert.True(movieArray.Length == 3);
        }

        [Test]
        public void TestIfThirdMovieIsInArray()
        {
            var movieArray = MovieController.Converter();
            Assert.AreNotEqual(movieArray[2].Title, null);
        }
        
    }
}