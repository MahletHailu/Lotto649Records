using BusinessLogic.Services;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Services
{
    public class ResultFixture
    {
        [Test]
        public void CanCreateInstance()
        {
            var sut = new Result();

            sut.Should().NotBeNull();
        }

        [Test]
        public void SettingTotalCostChangesTotalCost()
        {
            var totalCost = 1245;

            var sut = new Result
            {
                TotalCost = totalCost
            };

            sut.TotalCost.Should().Be(totalCost);
        }

        [Test]
        public void TotalWonShouldBeSumOfAllWon()
        {

            // $85
            var match2 = new MatchedDraw
            {
                DrawNumber = 3,
                DrawDate = new DateTime(),
                matchCount = 4
            };

            // $250,000
            var match1 = new MatchedDraw
            {
                DrawNumber = 1,
                DrawDate = new DateTime(),
                matchCount = 5
            };

            // $3000
            var match3 = new MatchedDraw
            {
                DrawNumber = 10,
                DrawDate = new DateTime(),
                matchCount = 6
            };

            var matches = new List<MatchedDraw>();

            matches.Add(match1);
            matches.Add(match2);
            matches.Add(match3);

            var sut = new Result
            {
                MatchedDraws = matches
            };

            sut.TotalWon.Should().Be(5003085.0);
        }
    }
}
